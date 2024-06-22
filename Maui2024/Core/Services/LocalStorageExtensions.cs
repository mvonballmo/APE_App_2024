namespace Core.Services;

public static class LocalStorageExtensions
{
    public static SettingsModel Load(this ILocalStorage localStorage, int id)
    {
        if (localStorage.TryLoad(id, out var settingsModel))
        {
            return settingsModel;
        }

        throw new InvalidOperationException($"Could not load object of type [{typeof(SettingsModel)}] with id [{id}].");
    }
}