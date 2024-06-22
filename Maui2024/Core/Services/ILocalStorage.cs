namespace Core.Services;

public interface ILocalStorage
{
    // TODO Make the database file configurable
    // TODO Make the methods return a value indicating success or failure
    // TODO Make the interface generic rather than SettingsModel-specifics

    SettingsModel Load(int id);

    IEnumerable<SettingsModel> LoadAll();

    void DeleteAll();

    void Save(SettingsModel settingsModel);
}