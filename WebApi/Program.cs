using UniversityWebApi.Repositories;
using UniversityWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IDepartmentRepository>(s =>
    new DepartmentRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IProfessorRepository>(s =>
    new ProfessorRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IProfessorService, ProfessorService>();

builder.Services.AddScoped<IStudentRepository>(s =>
    new StudentRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();
app.MapControllers();
app.Run();