using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions()
    {
        WebRootPath = "myroot"
    });

var app = builder.Build();

// Above the map
app.UseStaticFiles(); // Works with web root path (myroot)
app.UseStaticFiles(new StaticFileOptions()
{
    // builder.Environment.ContentRootPath == 
    // c:\aspnetcore\01-MyFirstApp\StaticFilesExample
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
    )
}); // Works with 'mywebroot'

app.MapGet("/", () => "Hello World!");

app.Run();
