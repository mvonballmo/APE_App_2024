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

    /// <inheritdoc/>
    public IEnumerable<SettingsModel> LoadAll()
    {
        var table = _connection.Table<SettingsModel>();
        return table.ToList();
    }

    /// <inheritdoc/>
    public void DeleteAll()
    {
        _connection.DeleteAll<SettingsModel>();
    }

    /// <inheritdoc/>
    public void Save(SettingsModel settingsModel)
    {
        _connection.InsertOrReplace(settingsModel);
    }

    /// <inheritdoc/>
    public bool TryLoad(int id, out SettingsModel item)
    {
        item = _connection.Find<SettingsModel>(id);

        return item != null;
    }
}