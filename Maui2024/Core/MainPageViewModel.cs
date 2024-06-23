using CommunityToolkit.Mvvm.Input;
using Core.Services;

namespace Core;

public partial class MainPageViewModel : ViewModelBase
{
    private SettingsModel? _model;
    private readonly ILocalStorage _localStorage;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private int _count;

    public MainPageViewModel()
    {
        // throw new InvalidOperationException("This constructor is for detecting binding in XAML and should never be called.");
    }

    public MainPageViewModel(ILocalStorage localStorage)
    {
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (SetField(ref _firstName, value))
            {
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (SetField(ref _lastName, value))
            {
                OnPropertyChanged(nameof(FullName));
            }
        }
    }

    public object FullName => $"{LastName}, {FirstName}";

    public int Count
    {
        get => _count;
        set => SetField(ref _count, value);
    }

    public bool IsReady => _model != null;

    public void Increment()
    {
        Count += 1;
    }

    [RelayCommand]
    public async Task EnsureModelLoaded()
    {
        if (_model == null)
        {
            try
            {
                await _localStorage.Initialize();

                var settingsModels = await _localStorage.LoadAll();

                _model = settingsModels.FirstOrDefault() ?? new SettingsModel();

                FirstName = _model.FirstName;
                LastName = _model.LastName;
                Count = _model.Count;

                OnPropertyChanged(nameof(IsReady));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public async Task Save()
    {
        if (_model == null)
        {
            throw new InvalidOperationException("Cannot save a non-existent model");
        }

        _model.FirstName = FirstName;
        _model.LastName = LastName;
        _model.Count = Count;

        await _localStorage.Save(_model);
    }
}