using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SportStore.Gateway.DelegateHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<TokenExcangeDelegateHandler>();

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToString().ToLower()}.json");

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
{
	options.Authority = builder.Configuration["IdentityServerURL"];
	options.Audience = "resource_gateway";
	options.RequireHttpsMetadata = false;
});

builder.Services.AddOcelot().AddDelegatingHandler<TokenExcangeDelegateHandler>();


var app = builder.Build();


await app.UseOcelot();

app.Run();
