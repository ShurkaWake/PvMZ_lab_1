using Microsoft.AspNetCore.Mvc;
using Server.Services;

string route = "http://172.25.73.149:4612";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddSingleton<RegexService>();

var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});
app.Logger.LogInformation("Server has been started");

app.MapGet("/brackets", ([FromQuery(Name = "text")] string text,
                         [FromServices] RegexService service) 
                         =>
{
    var input = text;
    string result;

    if (text is null || string.IsNullOrEmpty(text))
    {
        return Results.BadRequest("Input cannot be empty");
    }

    try
    {
        result = service.ChangeBrackets(input);
    }
    catch (Exception ex)
    {
        app.Logger.LogError($"Error: {ex.Message}");
        return Results.BadRequest("An error occured. Try again later");
    }
    return Results.Ok(result);
});

app.Run(route);