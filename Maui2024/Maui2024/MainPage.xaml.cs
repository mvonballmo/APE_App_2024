using Core;

namespace Maui2024;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        var mainPageViewModel = (MainPageViewModel)BindingContext;

        mainPageViewModel.Increment();
    }
}