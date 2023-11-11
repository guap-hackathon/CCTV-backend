using CCTV_backend.Db;
using CCTV_backend.Entity;

namespace CCTV_backend.Extensions;

public static class StartupExtension
{
    public static void ConfigureJson(this WebApplicationBuilder builder)
    {
        builder
            .ConfigureFromJson<MongoOptions>()
            .ConfigureFromJson<StreamClientOptions>();
    }

    private static WebApplicationBuilder ConfigureFromJson<T>(this WebApplicationBuilder builder)
        where T : class
    {
        var key = builder.Configuration.GetSection(typeof(T).Name);
        builder.Services.Configure<T>(key);
        return builder;
    }
}
