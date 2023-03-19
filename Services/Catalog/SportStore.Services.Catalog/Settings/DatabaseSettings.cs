namespace SportStore.Services.Catalog.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string? ProductColletionName { get; set; }
    public string? CategoryCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}

