using AutoMapper;
using FlightPlaner.Data;
using FlightPlaner.Services;
using FlightPlaner_ASPNET;
using FlightPlaner_ASPNET.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddDbContext<FlightPlanerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlightPlaner")));
builder.Services.AddTransient<IFlightPlanerDbContext, FlightPlanerDbContext>();
builder.Services.AddSingleton<IMapper>(AutoMapperConfig.CreateMapper());

builder.Services.RegisterServices();

builder.Services.RegisterValidations();

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