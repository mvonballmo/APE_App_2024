using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Tests;

[TestFixture]
public class LocalStorageServiceTests : TestsBase
{
    [Test]
    public void TestSave()
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
    }
}