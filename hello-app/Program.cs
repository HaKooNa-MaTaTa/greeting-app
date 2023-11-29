using hello_app.Services;
using Microsoft.Extensions.Options;
using Salt.RequestHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Вот тут я знатно ахуел
builder.Services.AddSingleton<IGreetingService, GreetingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestHandlerMiddleware>(Options.Create(new RequestHandlerOptions { RequestHandlerPolicy = RequestHandlerPolicy.HANDLE_ALL, LogPath = null }));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
