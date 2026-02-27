using _14_ConfigurationExample.Options;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Supply an object of WeatherApiOptions as a service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//app.MapGet("/endpoints", async context => 
//{
//        await context.Response.WriteAsync(app.Configuration["MyKey"] + "/n");
//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "/n");
//        await context.Response.WriteAsync(app.Configuration.GetValue<int>("X", 10).ToString());
//});

app.MapControllers();

app.Run();
