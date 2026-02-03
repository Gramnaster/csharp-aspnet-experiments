using _03_RoutingCountries.Data;
using _03_RoutingCountries.RouteConstraints;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting((options) =>
{
    options.ConstraintMap.Add("countryIds", typeof(CountryIdsCustomConstraint));
});

var app = builder.Build();

app.MapGet("countries", async (context) =>
{
    foreach (var (id, country) in CountriesData.countries)
    {
        await context.Response.WriteAsync($"{id}, {country}\n");
    }
});

app.MapGet("countries/{countryID:countryIds}", async (context) =>
{
    int countryId = Convert.ToInt32(context.Request.RouteValues["countryID"]);

    if (countryId < 1 || countryId > 100)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        return;
    }

    if (CountriesData.countries.TryGetValue(countryId, out string? value))
    {
        await context.Response.WriteAsync($"Country: {value}");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("[No Country]");
    }
});

app.MapFallback(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync($"No Response");
});

app.Run();
