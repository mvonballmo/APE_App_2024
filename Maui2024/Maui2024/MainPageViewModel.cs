using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui2024;

public class MainPageViewModel : INotifyPropertyChanged
{
    private string _firstName = "Schweiz";
    private string _lastName = "Svizzera";

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}