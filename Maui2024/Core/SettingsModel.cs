using SQLite;

namespace Core;

public class SettingsModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FirstName { get; set; } = "Schweiz";
    public string LastName { get; set; } = "Svizzera";
    public int Count { get; set; }
}