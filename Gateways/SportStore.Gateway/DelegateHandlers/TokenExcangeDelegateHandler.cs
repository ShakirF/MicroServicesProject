using IdentityModel.Client;

namespace SportStore.Gateway.DelegateHandlers;

public class TokenExcangeDelegateHandler : DelegatingHandler
{
	private readonly HttpClient _httpClient;
	private readonly IConfiguration _configuration;
	private string? _accesstoken;

	public TokenExcangeDelegateHandler(HttpClient httpClient, IConfiguration configuration)
	{
		this._httpClient = httpClient;
		this._configuration = configuration;
	}

	private async Task<string> GetToken(string? requestToken)
	{
		if (!string.IsNullOrEmpty(_accesstoken))
		{
			return _accesstoken;
		}
		var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
		{
			Address = _configuration["IdentityServerURL"],
			Policy = new DiscoveryPolicy { RequireHttps = false }
		});

		if (disco.IsError)
		{
			throw disco.Exception;
		}

		TokenExchangeTokenRequest tokenExchangeTokenRequest = new()
		{
			Address = disco.TokenEndpoint,
			ClientId = _configuration["ClientId"],
			ClientSecret = _configuration["ClientSecret"],
			GrantType = _configuration["TokenGrantType"],
			SubjectToken = requestToken,
			SubjectTokenType = "urn:ietf:params:oauth:grant-type:access-token",
			Scope = "openid discount_fullpermission payment_fullpermission"
		};

		var tokenResponse = await _httpClient.RequestTokenExchangeTokenAsync(tokenExchangeTokenRequest);
		if (tokenResponse.IsError)
		{
			throw tokenResponse.Exception;
		}
		_accesstoken = tokenResponse.AccessToken;
		return _accesstoken;

	}



	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var requestToken = request.Headers.Authorization.Parameter;

		var newToken = await GetToken(requestToken);

		request.SetBearerToken(newToken);

		return await base.SendAsync(request, cancellationToken);
	}
}

