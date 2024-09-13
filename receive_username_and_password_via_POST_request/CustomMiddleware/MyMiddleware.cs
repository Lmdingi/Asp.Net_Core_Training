using System;

namespace receive_username_and_password_via_POST_request.CustomMiddleware;

public class MyMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string method = context.Request.Method;
        string path = context.Request.Path;
        var query = context.Request.Query;
        var headers = context.Request.Headers;
        bool isValid = false;
        string? email = null;
        string? password = null;

        if (query.ContainsKey("email") || query.ContainsKey("password"))
        {
            email = query["email"];
            password = query["password"];

            isValid = email == "admin@example.com" && password == "admin1234";
        }

        if (method == "POST" && path == "/")
        {
            if (!isValid)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                if (email == null && password == null)
                {
                    await context.Response.WriteAsync("Invalid input for: 'email'");
                    await context.Response.WriteAsync("\n");
                    await context.Response.WriteAsync("Invalid input for: 'password'");
                }
                else if (password == null)
                {
                    await context.Response.WriteAsync("Invalid input for: 'password'");
                }
                else if (email == null)
                {
                    await context.Response.WriteAsync("Invalid input for: 'email'");
                }
                else
                {
                    await context.Response.WriteAsync("Invalid login");
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync("Successful login");
            }
        }

        await next(context);
    }
}
