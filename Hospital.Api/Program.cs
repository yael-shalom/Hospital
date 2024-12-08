using Hospital.Core;
using Hospital.Core.Repositories;
using Hospital.Core.Services;
using Hospital.Data;
using Hospital.Data.Repositories;
using Hospital.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlacementRepository, PlacementRepository>();
builder.Services.AddScoped<IPlacementService, PlacementService>();

builder.Services.AddScoped<IWardRepository, WardRepository>();
builder.Services.AddScoped<IWardService, WardService>();

builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerService, WorkerService>();

builder.Services.AddSingleton<DataContext>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
