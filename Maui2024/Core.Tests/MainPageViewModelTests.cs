namespace Core.Tests;

public class MainPageViewModelTests
{
    [Test]
    public void TestSettingFirstName()
    {
        var viewModel = CreateMainPageViewModel();
        
        Assert.That(viewModel.FirstName, Is.EqualTo("Schweiz"));

        viewModel.FirstName = "Marco";
        
        Assert.That(viewModel.FirstName, Is.EqualTo("Marco"));
    }

    [Test]
    public void TestSettingLastName()
    {
        var viewModel = CreateMainPageViewModel();
        
        Assert.That(viewModel.LastName, Is.EqualTo("Svizzera"));

        viewModel.LastName = "von Ballmoos";
        
        Assert.That(viewModel.LastName, Is.EqualTo("von Ballmoos"));
    }

    [Test]
    public void TestIncrementTriggersChange()
    {
        var viewModel = CreateMainPageViewModel();

        var notifications = new List<string?>();

        viewModel.PropertyChanged += (_, args) => notifications.Add(args.PropertyName);

        Assert.That(viewModel.Count, Is.EqualTo(0));

        viewModel.Increment();

        Assert.That(viewModel.Count, Is.EqualTo(1));
        Assert.That(notifications, Is.EquivalentTo(new [] {"Count"}));
    }

    [Test]
    public void TestFullNameOnlyTriggeredWhenChangeHappens()
    {
        var viewModel = CreateMainPageViewModel();

        var notifications = new List<string?>();

        viewModel.PropertyChanged += (_, args) => notifications.Add(args.PropertyName);

        Assert.That(viewModel.LastName, Is.EqualTo("Svizzera"));

        viewModel.LastName = "von Ballmoos";

        Assert.That(notifications, Is.EquivalentTo(new [] {"LastName", "FullName"}));

        notifications.Clear();
        
        viewModel.LastName = "von Ballmoos";

        Assert.That(notifications, Is.EquivalentTo(Array.Empty<string>()));
    }

    private static MainPageViewModel CreateMainPageViewModel()
    {
        return new MainPageViewModel(new SettingsModel());
    }
}