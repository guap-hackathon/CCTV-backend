using CCTV_backend.Db;
using CCTV_backend.Entity;
using CCTV_backend.Extensions;
using CCTV_backend.Facades;
using CCTV_backend.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
builder.ConfigureJson();

services.AddControllers();
services
    .AddSingleton<RtspFacade>()
    .AddSingleton<RtspService>()
    .AddSingleton<MongoStore>()
    .AddSingleton<StreamingClient>()
    .AddHttpClient()
    .AddHostedService<MongoInitializer>()
    .AddHostedService<StreamService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
