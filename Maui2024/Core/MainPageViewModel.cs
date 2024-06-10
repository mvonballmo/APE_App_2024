using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Core;

public class MainPageViewModel : ViewModelBase
{
    private readonly SettingsModel _model; 
    private string _firstName;
    private string _lastName;
    private int _count;

    public MainPageViewModel()
    {
        // For XAML types
    }
    
    public MainPageViewModel(SettingsModel model)
    {
        _model = model;
        _firstName = _model.FirstName;
        _lastName = _model.LastName;
        _count = _model.Count;
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

    public void Increment()
    {
        Count += 1;
    }

    public void Save()
    {
        _model.FirstName = FirstName;
        _model.LastName = LastName;
        _model.Count = Count;
    }
}