namespace SportStore.Web.Models;

public class ClientSettings
{
    public Client? WebClient { get; set; }
    public Client? WebClientForUser { get; set; }

}

public class Client
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}

