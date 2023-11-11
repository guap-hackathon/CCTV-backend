using CCTV_backend.Facades;
using CCTV_backend.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services
    .AddSingleton<RtspFacade>()
    .AddSingleton<RtspService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
