using SQLite;

namespace Core.Services;

public class SqliteLocalStorage : ILocalStorage
{
    private readonly SQLiteConnection _connection;

    public SqliteLocalStorage(LocalStorageSettings settings)
    {
        var options = new SQLiteConnectionString(settings.DatabasePath);
        _connection = new SQLiteConnection(options);

        // Check whether our table already exists. If not, we're creating it here.
        if (_connection.TableMappings.All(x =>
                !x.TableName.Equals(nameof(SettingsModel), StringComparison.InvariantCultureIgnoreCase)))
        {
            _connection.CreateTable<SettingsModel>();
        }
    }

    public bool Delete(SettingsModel settingsModel)
    {
        return _connection.Delete<SettingsModel>(settingsModel.Id) == 1;
    }

    /// <inheritdoc/>
    public IList<SettingsModel> LoadAll()
    {
        return _connection.Table<SettingsModel>().ToList();
    }

    /// <inheritdoc/>
    public bool DeleteAll()
    {
        return _connection.DeleteAll<SettingsModel>() >= 0;
    }

    /// <inheritdoc/>
    public bool Save(SettingsModel settingsModel)
    {
        return _connection.InsertOrReplace(settingsModel) == 1;
    }

    /// <inheritdoc/>
    public bool TryLoad(int id, out SettingsModel item)
    {
        item = _connection.Find<SettingsModel>(id);

        return item != null;
    }
}