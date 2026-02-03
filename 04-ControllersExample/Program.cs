var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Add all controller classes as services
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers(); // Detect all Controllers and pick up all Action Methods and add Routing
app.Run();
