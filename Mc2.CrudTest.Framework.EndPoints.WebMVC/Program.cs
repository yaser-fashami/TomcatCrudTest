using Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//namespace Mc2.CrudTest.Framework.EndPoints.WebMVC;
public class FrameworkProgram
{
	public WebApplicationBuilder Main(string[] args, params string[] appSettingFiles)
	{
		try
		{
			StartLog();
			return CreateHostBuilder(args, appSettingFiles);
		}
		catch (Exception ex)
		{
			FatalLog(ex);
			throw;
		}
		finally
		{
			CloseAndFlushLog();
		}
	}
	public int Main(string[] args, Type startup, params string[] appSettingFiles)
	{
		try
		{
			StartLog();
			CreateHostBuilder(args, startup, appSettingFiles);
			return 0;
		}
		catch (Exception ex)
		{
			FatalLog(ex);
			return 1;
		}
		finally
		{
			CloseAndFlushLog();
		}
	}

	private WebApplicationBuilder CreateHostBuilder(string[] args, params string[] appSettingFiles)
	{
		var builder = WebApplication.CreateBuilder(args);
		AddAppsettings(builder.Configuration, appSettingFiles);
		AddLogger(builder);
		return builder;
	}
	private IHostBuilder CreateHostBuilder(string[] args, Type startup, params string[] appSettingFiles)
	{
		return Host.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((ctx, config) =>
			{
				AddAppsettings(config, appSettingFiles);
				AddLogger(config.Build());
			})
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup(startup);
			})
			.UseSerilog();
	}
	private IConfigurationBuilder AddAppsettings(IConfigurationBuilder configurationBuilder, params string[] appSettingFiles)
	{
		if (appSettingFiles == null || !appSettingFiles.Any())
		{
			appSettingFiles = new string[] { "appsetting.json" };
		}
		foreach (var item in appSettingFiles)
		{
			configurationBuilder.AddJsonFile(item);
		}
		return configurationBuilder;
	}
	private void AddLogger(IConfiguration configuration)
	{
		Log.Logger = new LoggerConfiguration()
							.ReadFrom.Configuration(configuration)
							.CreateLogger();
	}
	private void AddLogger(WebApplicationBuilder builder)
	{
		AddLogger(builder.Configuration);
		builder.Host.UseSerilog(Log.Logger);
	}
	private void StartLog()
	{
		Log.Information("Starting web host");
	}
	private void FatalLog(Exception ex)
	{
		Log.Fatal(ex, "Host terminated unexceptedly");
	}
	private void CloseAndFlushLog()
	{
		Log.CloseAndFlush();
	}
}

