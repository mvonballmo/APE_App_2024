using SQLite;

namespace Core.Services;

public class SqliteLocalStorage : ILocalStorage
{
    /// <summary>
    /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
    /// </summary>
    private static string DatabasePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Maui2024.db3");

    private readonly SQLiteConnection _connection;

    public SqliteLocalStorage()
    {
        var options = new SQLiteConnectionString(DatabasePath);
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

    public void Save(SettingsModel settingsModel)
    {
        _connection.InsertOrReplace(settingsModel);
    }

    public SettingsModel Load(int id)
    {
        return _connection.Get<SettingsModel>(id);
    }
}