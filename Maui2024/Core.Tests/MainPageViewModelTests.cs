using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Tests;

public class MainPageViewModelTests : TestsBase
{
    [Test]
    public void TestSettingFirstName()
    {
        var viewModel = CreateMainPageViewModel();

        Assert.That(viewModel.FirstName, Is.EqualTo("Hans"));

        viewModel.FirstName = "Marco";

        Assert.That(viewModel.FirstName, Is.EqualTo("Marco"));
    }

    [Test]
    public void TestSettingLastName()
    {
        var viewModel = CreateMainPageViewModel();

        Assert.That(viewModel.LastName, Is.EqualTo("Muster"));

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
        Assert.That(notifications, Is.EquivalentTo(new[] { "Count" }));
    }

    [Test]
    public void TestFullNameOnlyTriggeredWhenChangeHappens()
    {
        var viewModel = CreateMainPageViewModel();

        var notifications = new List<string?>();

        viewModel.PropertyChanged += (_, args) => notifications.Add(args.PropertyName);

        Assert.That(viewModel.LastName, Is.EqualTo("Muster"));

        viewModel.LastName = "von Ballmoos";

        Assert.That(notifications, Is.EquivalentTo(new[] { "LastName", "FullName" }));

        notifications.Clear();

        viewModel.LastName = "von Ballmoos";

        Assert.That(notifications, Is.EquivalentTo(Array.Empty<string>()));
    }

    [Test]
    public async Task TestSave()
    {
        var serviceProvider = CreateServiceProvider();
        var viewModel = serviceProvider.GetRequiredService<MainPageViewModel>();
        var settingsModel = serviceProvider.GetRequiredService<SettingsModel>();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        Assert.That(settingsModel.Id, Is.Null);

        await viewModel.Save();

        Assert.That(settingsModel.Id, Is.Not.Null);

        var loadedSettingsModel = await localStorage.TryLoad(settingsModel.Id.Value);

        Assert.That(loadedSettingsModel, Is.Not.Null.And.Property(nameof(SettingsModel.Id)).EqualTo(settingsModel.Id));
    }

    private MainPageViewModel CreateMainPageViewModel()
    {
        return CreateServiceProvider().GetRequiredService<MainPageViewModel>();
    }
}