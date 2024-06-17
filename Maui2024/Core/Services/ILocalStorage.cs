namespace Core.Services;

public interface ILocalStorage
{
    void Save(SettingsModel settingsModel);
}