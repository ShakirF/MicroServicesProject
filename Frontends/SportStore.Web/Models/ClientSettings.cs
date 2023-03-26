namespace SportStore.Web.Models;

public class ClientSettings
{
    public Client WebClient { get; set; } = null!;
    public Client WebClientForUser { get; set; } = null!;

}

public class Client
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}

