var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //adds the all controller classes as services

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.Run();
