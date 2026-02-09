using _05_ModelBindingExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers((options) => 
{
    // Required for the Custom Model Binder Provider of the Person class
    // Execute this model provider to replace the standard Model Binder
    //options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
