using Data;
using Dto.dtos;
using Entity.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.interfaces;

using Repository.Repositories;
using Service.Interfaces;
using Service.Services;
using Sevice.Services;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "securityLessonWebApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter your bearer token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
});





builder.Services.AddScoped<IRepository<Trip>, TripRepository>();
builder.Services.AddScoped<IRepository<Commend>, CommendRepository>();
builder.Services.AddScoped<IRepository<Custumer>, CustumerRepository>();
//builder.Services.AddScoped<IUserLogin, UserService>();
//builder.Services.AddScoped<Ilogin, UserRepository>();
builder.Services.AddScoped<IService<CustumerDto>, CustumerService>();
builder.Services.AddScoped<IService<CommendDto>, CommendService>();
builder.Services.AddScoped<IService<TripDto>, TripServices>();

builder.Services.AddAutoMapper(typeof(MyMapper));
builder.Services.AddDbContext<Icontext, MyData>();


//בדיקת הטוקן האם תקין 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(option =>
              option.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = builder.Configuration["Jwt:Issure"],
                  ValidAudience = builder.Configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

              });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
