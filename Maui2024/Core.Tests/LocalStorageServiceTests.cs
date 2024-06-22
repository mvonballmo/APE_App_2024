using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Tests;

[TestFixture]
public class LocalStorageServiceTests : TestsBase
{
    [Test]
    public void TestSaveAndLoad()
    {
        var serviceProvider = CreateServiceProvider();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        var settingsModel = new SettingsModel
        {
            FirstName = "John",
            LastName = "Doe",
            Count = 4
        };

        Assert.That(settingsModel.Id, Is.Null);

        localStorage.Save(settingsModel);

        Assert.That(settingsModel.Id, Is.Not.Zero);

        var loadedSettingsModel = localStorage.Load(settingsModel.Id.Value);

        Assert.That(loadedSettingsModel.Id, Is.EqualTo(settingsModel.Id));
    }

    [Test]
    public void TestLoadAll()
    {
        var serviceProvider = CreateServiceProvider();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        var settingsModels = localStorage.LoadAll().ToList();
    }
}