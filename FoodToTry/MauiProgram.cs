using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FoodToTry;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        var appsettingsFileName = $"{nameof(FoodToTry)}.appsettings.";
#if DEBUG
        appsettingsFileName += "Development.json";
#else
            appsettingsFileName += "Production.json";           
#endif
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MauiProgram)).Assembly;
        var stream = assembly.GetManifestResourceStream(appsettingsFileName);
        builder.Configuration.AddJsonStream(stream);
        var config = builder.Configuration.GetSection(nameof(EFCCustomConfig)).Get<EFCCustomConfig>();

        builder.Services.AddDbContext<DataBaseContext>(options =>
        {
            if (config.IsProduction)
            {
                options.UseNpgsql(config.ConnectionString);
            }
            else
            {
                options.UseSqlite(config.ConnectionString);
            }
        });
        builder.Services.AddSingleton<IEFCCustomConfig>(config);

        builder.Services.AddSingleton<MainPage>();

        

        return builder.Build();
	}
}
