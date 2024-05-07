using Notification;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHostedService, MessageListener>();
var app = builder.Build();

app.Run();

