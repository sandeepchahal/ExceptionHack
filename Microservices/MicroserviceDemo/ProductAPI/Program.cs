using Consul;
using ProductAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHostedService, ConsulRegistrationService>();
var consulHost = builder.Configuration.GetValue<string>("ConsulConfiguration:Host");
builder.Services.AddSingleton<IConsulClient>(_ => new ConsulClient(config =>
{
    config.Address = new Uri(consulHost);
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();