namespace Core.Services;

public interface ILocalStorage
{
    SettingsModel Load(int id);

    IEnumerable<SettingsModel> LoadAll();

    void Save(SettingsModel settingsModel);
}