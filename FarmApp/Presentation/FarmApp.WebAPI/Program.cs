using FarmApp.Application.Services;
using FarmApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AnimalRepository>();
builder.Services.AddTransient<AnimalService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomCORSPolicy",builder => {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

app.UseCors("CustomCORSPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
