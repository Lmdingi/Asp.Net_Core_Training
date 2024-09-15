var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async (context) =>{
        // var param1 = context.Request.RouteValues["id"];
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"Hello: {endpoint}");
    });

});

app.Run();
