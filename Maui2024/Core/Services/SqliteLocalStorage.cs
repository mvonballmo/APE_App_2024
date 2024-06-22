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

    public IEnumerable<SettingsModel> LoadAll()
    {
        var table = _connection.Table<SettingsModel>();
        return table.ToList();
    }

    public void DeleteAll()
    {
        _connection.DeleteAll<SettingsModel>();
    }

    public void Save(SettingsModel settingsModel)
    {
        _connection.InsertOrReplace(settingsModel);
    }

    public SettingsModel Load(int id)
    {
        return _connection.Get<SettingsModel>(id);
    }
}