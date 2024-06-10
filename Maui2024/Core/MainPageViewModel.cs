using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Core;

public class MainPageViewModel : INotifyPropertyChanged
{
    private string _firstName = "Schweiz";
    private string _lastName = "Svizzera";
    private int _count;

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

    public event PropertyChangedEventHandler? PropertyChanged;


    public void Increment()
    {
        Count += 1;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }
        
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}