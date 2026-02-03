using _03_Routing.RouteConstraints;

var builder = WebApplication.CreateBuilder(args);

// Register your custom constraint in the services section
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});

var app = builder.Build();

app.Map("files/{filename}.{extension}", async (context) =>
{
    // These come as objects and must be converted to a string
    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"In files - {filename}.{extension}");
});

app.Map("employee/profile/{EmployeeName:length(3,7):alpha=john}", async (context) =>
{
    string? employeename = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"Employee Name - {employeename}");
});

app.Map("products/details/{id:int:range(1, 1000)?}", async (context) =>
{
    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product Id: {id}");
    }
    else
    {
        await context.Response.WriteAsync($"Product Details - Not Found");
    }
});

// E.g. daily-digest-report/{reportDate}
app.Map("daily-digest-report/{reportDate:dateTime}", async (context) =>
{
    DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);

    await context.Response.WriteAsync($"In daily-digest-report: {reportDate.ToShortDateString()}");
});

app.Map("cities/{cityid:guid}", async (context) =>
{
    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
    await context.Response.WriteAsync($"City Information - {cityId}");
});

// E.g.: sales-report/2030/apr
app.Map("sales-report/{year:int:min(1900)}/{month:months}", async (context) =>
{
    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
    string? month = Convert.ToString(context.Request.RouteValues["month"]);

    if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
    {
        await context.Response.WriteAsync($"Sales Report - {year} - {month}");
    }
    else
    {
        await context.Response.WriteAsync($"{month} month is not allowed");
    }
});

// E.g.: sales-report/2024/jan
app.Map("sales-report/2024/jan", async (context) =>
{
    await context.Response.WriteAsync($"Sales report exclusively for 2024 jan");
});

app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync($"Fallback at {context.Request.Path}");
});
// Routing is automatically enabled
// No need for app.UseRouting() anymore

// Endpoints are defined directly on the app object
// Map endpoint executes for GET, POST, and other HTTP methods
//app.MapGet("/map1", async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("In Map 1");
//});

//// First argument is the path
//app.MapPost("/map2", async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("In Map 2");
//});

//// Fallback for any other requests
//app.MapFallback(async (context) =>
//{
//    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
//});
app.Run();
