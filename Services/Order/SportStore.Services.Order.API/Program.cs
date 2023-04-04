using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SportStore.Services.Order.Application.Consumers;
using SportStore.Services.Order.Infrastructure;
using SportStore.Shared.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{

	x.AddConsumer<CreateOrderMessageCommandConsumer>();
	x.AddConsumer<ProductNameChangedEventConsumer>();
	// Default Port : 5672
	x.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
		{
			host.Username("guest");
			host.Password("guest");
		});


		cfg.ReceiveEndpoint("create-order-service", e =>
		{
			e.ConfigureConsumer<CreateOrderMessageCommandConsumer>(context);
		});
		cfg.ReceiveEndpoint("product-name-change-event-service", e =>
		{
			e.ConfigureConsumer<ProductNameChangedEventConsumer>(context);
		});

	});

});



var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.Authority = builder.Configuration["IdentityServerURL"];
	options.Audience = "resource_order";
	options.RequireHttpsMetadata = false;
});

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
	{
		configure.MigrationsAssembly("SportStore.Services.Order.Infrastructure");
	});
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
builder.Services.AddMediatR(typeof(SportStore.Services.Order.Application.Handlers.CreateOrderCommandHandler).Assembly);
builder.Services.AddControllers(opt =>
{
	opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	var orderDbContext = serviceProvider.GetRequiredService<OrderDbContext>();
	orderDbContext.Database.Migrate();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
