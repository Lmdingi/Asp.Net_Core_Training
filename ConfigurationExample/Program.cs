using ConfigurationExample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherOptions>(builder.Configuration.GetSection("WeatherApi"));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.Map("/config", async context =>
//     {
//         string myKey = app.Configuration["MyKey"];
//         string allowedHosts = app.Configuration.GetValue<string>("AllowedHosts");
//         string addDefault = app.Configuration.GetValue<string>("x", "add default if 'x' is not found");

//         await context.Response.WriteAsync(myKey + "\n" + allowedHosts + "\n" + addDefault);
//     });
// });
app.MapControllers();

app.Run();
