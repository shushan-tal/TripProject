using Data;
using Dto.dtos;
using Entity.Model;
using Repository.interfaces;

using Repository.Repositories;
using Service.Interfaces;
using Service.Services;
using Sevice.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRepository<Trip>,TripRepository>();
builder.Services.AddScoped<IRepository<Commend>, CommendRepository>();
builder.Services.AddScoped<IRepository<Custumer>, CustumerRepository>();

builder.Services.AddScoped<IService<CustumerDto>, CustumerService>();
builder.Services.AddScoped<IService<CommendDto>, CommendService>();
builder.Services.AddScoped<IService<TripDto>, TripServices>();

builder.Services.AddAutoMapper(typeof(MyMapper));
builder.Services.AddDbContext<Icontext, MyData>();







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
