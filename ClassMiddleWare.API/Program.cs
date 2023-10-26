using ClassMiddleWare.API;
using ClassMiddleWare.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<TokenGeneratorService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();
// app.UseMiddleware<CultureMiddleware>();
// app.MapGet("/", () => DateTime.Now.ToString());

app.UseSwagger();
app.UseSwaggerUI();
app.Run();