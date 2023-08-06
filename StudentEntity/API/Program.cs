using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Database;
using System.Configuration;
using AutoMapper;
using Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISchoolService, SchoolService>();

builder.Services.AddAutoMapper(typeof(AutoMapperFile));

//builder.Services.AddDbContext<StudentDbContext>(options =>
//    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<StudentDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Apply migrations on startup
//using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
//{
//    scope.ServiceProvider.GetService<StudentDbContext>().Database.Migrate();
//}
app.UseHttpsRedirection();
//// Apply migrations on startup
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
//    dbContext.Database.Migrate();
//}
app.UseAuthorization();

app.MapControllers();

app.Run();
