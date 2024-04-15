using AutoMapper;
using Microsoft.Extensions.Configuration;
using Sigma.Infra.CrossCutting.IoC;
using Sigma.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddApplicationContext(configuration.GetValue<string>("ConnectionStrings:Sigma")!);

MapperConfiguration mapperConfiguration = new MapperConfiguration(mapperConfig => {
    mapperConfig.AddMaps(new[] { "Sigma.Service" });
});
builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

ContainerService.AddApplicationServicesCollentions(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
