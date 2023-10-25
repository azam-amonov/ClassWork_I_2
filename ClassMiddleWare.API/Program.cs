using ClassMiddleWare.API;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<CultureMiddleware>();
app.MapGet("/", () => DateTime.Now.ToString());

app.Run();