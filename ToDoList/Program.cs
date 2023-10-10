using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using ToDoList.Data;
using ToDoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var fileContextOptions = new FileContextOptions<AppFileContext>
{
    StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data/Storage")
};

builder.Services.AddSingleton<IFileContextOptions<IFileContext>>(fileContextOptions);
builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
{
    var options = provider.GetRequiredService<IFileContextOptions<IFileContext>>();
    var dataContext = new AppFileContext(options);
    dataContext.FetchAsync()
                    .AsTask()
                    .Wait();
    return dataContext;
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoService, TodoService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();