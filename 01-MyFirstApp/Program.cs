using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    int? firstNumber = 0;
    int? secondNumber = 0;
    string? operation = "";
    int? result = 0;

    if (context.Request.Query.ContainsKey("firstNumber") &&
        context.Request.Query.ContainsKey("secondNumber"))
    {
        firstNumber = int.TryParse(context.Request.Query["firstNumber"], out int tempResult1) ? tempResult1 : -1;
        secondNumber = int.TryParse(context.Request.Query["secondNumber"], out int tempResult2) ? tempResult2 : -1;
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Missing either firstNumber or secondNumber");
        return;
    }

    if (context.Request.Query.ContainsKey("operation"))
    {
        operation = context.Request.Query["operation"].ToString().ToLowerInvariant();
        switch (operation)
        {
            case "add":
                result = firstNumber + secondNumber;
                break;
            case "sub":
                result = firstNumber - secondNumber;
                break;
            case "mul":
                result = firstNumber * secondNumber;
                break;
            case "div":
                result = firstNumber / secondNumber;
                break;
            case "mod":
                result = firstNumber % secondNumber;
                break;
            default:
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Missing or invalid operation");
                return;
        }
        await context.Response.WriteAsync($"The result of {firstNumber} and {secondNumber} is {result}");
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Missing or invalid operation");
        return;
    }
    //// Checks the request body
    //StreamReader reader = new(context.Request.Body);
    //string body = await reader.ReadToEndAsync();

    //// Why stringValues? There can be duplicated values in the string, but you should be able to read both values
    //Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);

    //// Checks a key within the Dictionary. Common technique in C#
    //// But too troublesome for actual projects
    //if (queryDict.ContainsKey("firstName"))
    //{
    //    string? firstName = queryDict["firstName"][0];
    //    await context.Response.WriteAsync(firstName);
    //}
});

app.Run();
