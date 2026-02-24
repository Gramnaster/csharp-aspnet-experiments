using _12_DIExample_ServiceContracts;
using _12_DIExample_Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//builder.Services.Add(
//    new ServiceDescriptor(
//        typeof(ICitiesService),
//        typeof(CitiesService),
//        ServiceLifetime.Transient
//));
builder.Services.AddScoped<ICitiesService, CitiesService>();
//builder.Services.AddApplicationServices();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
