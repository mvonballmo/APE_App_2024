namespace Core.Services;

public interface ILocalStorage
{
    void Save(SettingsModel settingsModel);
    SettingsModel Load(int id);
}