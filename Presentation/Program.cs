using Microsoft.EntityFrameworkCore;
using Application;
using Infrastructure;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

//var connectionString = "Host = localhost; Database=Crud;Username=postgres;Password=1001";

//builder.Services.AddDbContext<AppDbContext>(Opt => Opt.UseNpgsql(connectionString));
builder.Services.AddDbContext<AppDbContext>(Opt => Opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var jwtsetting = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtsetting.Key);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtsetting["isuuer"],
        ValidAudience = jwtsetting["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();


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

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();