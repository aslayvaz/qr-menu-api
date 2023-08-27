using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using QrMenu.Data.Repositories;
using QrMenu.Services;
using QrMenu.Utils.Auth;
using QrMenu.Utils.Database;
using QrMenu.Utils.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

//add jwt
var jwtConfig = new JwtConfig();

builder.Configuration.GetSection("Jwt").Bind(jwtConfig);//bind user-secrets to a model for usage.

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            IssuerSigningKey = new SymmetricSecurityKey
             (Encoding.UTF8.GetBytes(jwtConfig.Secret))
        };
    });

//mongo db connection
var mongoConfig = new MongoDbConfig();
builder.Configuration.GetSection("MongoDb").Bind(mongoConfig);//bind user-secrets to a model for usage.

builder.Services.AddSingleton(new MongoClient(mongoConfig.ConnectionString));
builder.Services.AddScoped(provider => provider.GetService<MongoClient>().GetDatabase(mongoConfig.DatabaseName));

// dependency injections
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IConfirmCodesRepository, ConfirmCodesRepository>();

builder.Services.AddScoped<IAuthenticatorService, AuthenticatorService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

//automapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config =>
{
    config
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

