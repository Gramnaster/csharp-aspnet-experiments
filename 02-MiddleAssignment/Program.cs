using _02_MiddleAssignment.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseLoginMiddleware();

app.Run();
