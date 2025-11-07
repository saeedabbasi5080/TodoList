using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure;
using Application;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

var connectionString = "Host = localhost; Database=Crud;Username=postgres;Password=1001";

builder.Services.AddDbContext<AppDbContext>(Opt => Opt.UseNpgsql(connectionString));


builder.Services.AddScoped<ITodoRepository, ToDoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<UserService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
       var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();