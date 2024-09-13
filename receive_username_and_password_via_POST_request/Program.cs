using receive_username_and_password_via_POST_request.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyMiddleware>();

var app = builder.Build();

app.UseMiddleware<MyMiddleware>();

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        await context.Response.WriteAsync("No response");
    }
});

app.Run();
