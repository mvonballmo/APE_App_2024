namespace Core.Services;

public interface ILocalStorage
{
    // TODO Make the methods return a value indicating success or failure
    // TODO Make the interface generic rather than SettingsModel-specifics
    // TODO Use async methods

    bool TryLoad(int id, out SettingsModel item);

    IEnumerable<SettingsModel> LoadAll();

    void DeleteAll();

    void Save(SettingsModel settingsModel);
}