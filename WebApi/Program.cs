using UniversityWebApi.Repositories;
using UniversityWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IDepartmentRepository>(s =>
    new DepartmentRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();
app.MapControllers();
app.Run();