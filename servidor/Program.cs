using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servidor.services;
using servidorContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add conection to DataBase
builder.Services.AddSqlServer<UserContext>(builder.Configuration.GetConnectionString("cnUsers"));


// Add services
builder.Services.AddScoped<IUserServices, UserServices>();


var app = builder.Build();
app.MapGet("/dbConnection", async ([FromServices] UserContext dbContext) =>
{
	dbContext.Database.EnsureCreated();
	return Results.Ok("Database created" + dbContext.Database.IsSqlServer());
});

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


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