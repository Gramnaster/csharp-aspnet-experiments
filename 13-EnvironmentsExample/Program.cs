var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
} 
else if (app.Environment.IsStaging() || app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
