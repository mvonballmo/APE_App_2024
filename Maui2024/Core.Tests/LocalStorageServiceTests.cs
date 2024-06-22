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

        var settingsModel = CreateSettingsModel();

        Assert.That(settingsModel.Id, Is.Null);

        localStorage.Save(settingsModel);

        Assert.That(settingsModel.Id, Is.Not.Zero);

        var loadedSettingsModel = localStorage.Load(settingsModel.Id.Value);

        Assert.That(loadedSettingsModel.Id, Is.EqualTo(settingsModel.Id));
    }

    private static SettingsModel CreateSettingsModel()
    {
        return new SettingsModel
        {
            FirstName = "John",
            LastName = "Doe",
            Count = 4
        };
    }

    [Test]
    public void TestDeleteAndLoadAll()
    {
        var serviceProvider = CreateServiceProvider();
        var localStorage = serviceProvider.GetRequiredService<ILocalStorage>();

        localStorage.DeleteAll();

        var settingsModels = localStorage.LoadAll().ToList();

        Assert.That(settingsModels.Count, Is.EqualTo(0));

        for (var i = 0; i < 5; i++)
        {
            localStorage.Save(CreateSettingsModel());
        }

        settingsModels = localStorage.LoadAll().ToList();

        Assert.That(settingsModels.Count, Is.EqualTo(5));
    }
}