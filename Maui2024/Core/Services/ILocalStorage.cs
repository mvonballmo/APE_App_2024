namespace Core.Services;

public interface ILocalStorage
{
    // TODO Make the interface generic rather than SettingsModel-specifics
    // TODO Use async methods

    bool TryLoad(int id, out SettingsModel item);

    bool Save(SettingsModel settingsModel);

    IEnumerable<SettingsModel> LoadAll();

    bool DeleteAll();
}