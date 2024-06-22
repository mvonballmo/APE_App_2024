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

        localStorage.Save(settingsModel);

        Assert.That(settingsModel.Id, Is.Not.Zero);

        var loadedSettingsModel = localStorage.Load(settingsModel.Id);

        Assert.That(loadedSettingsModel.Id, Is.EqualTo(settingsModel.Id));
    }
}