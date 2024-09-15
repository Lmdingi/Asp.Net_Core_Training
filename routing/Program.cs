using routing.customConstraint;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option=>{
    option.ConstraintMap.Add("months", typeof(customConstraint));
});
var app = builder.Build();

//enable routing
app.UseRouting();

//create endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/month/{id:months}", async (context) =>{
        var param1 = context.Request.RouteValues["id"];
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"In file: {endpoint} ::: {param1}");
    });

    endpoints.MapGet("/optional/{id:maxlength(3)}", async (context) =>{
        var param1 = context.Request.RouteValues["id"];
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"In file: {endpoint} ::: {param1}");
    });

    endpoints.Map("/file/{filename}.{extension}", async (context) =>{
        var param1 = context.Request.RouteValues["filename"];
        var param2 = context.Request.RouteValues["extension"];
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"In file: {endpoint} ::: {param1}.{param2}");
    });

    endpoints.MapGet("/map1", async (context) =>
    {
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"In Map 1: {endpoint}");
    });

    endpoints.MapPost("/map2", async (context) =>
    {
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"In Map 2: {endpoint}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($" <== {context.Request.Path} ==> NO MATCH");
});

app.Run();
