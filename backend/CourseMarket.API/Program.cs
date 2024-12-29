using CourseMarket.Application.Interfaces.Repositories;
using CourseMarket.Application.Interfaces.Repositories.Course;
using CourseMarket.Application.Interfaces.Services;
using CourseMarket.Application.Interfaces.UnitOfWork;
using CourseMarket.Application.Validators.Courses;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure.Concretes.Repositories;
using CourseMarket.Infrastructure.Concretes.Repositories.Course;
using CourseMarket.Infrastructure.Concretes.Services;
using CourseMarket.Infrastructure.Concretes.Services.Filters;
using CourseMarket.Infrastructure.Context;
using CourseMarket.Infrastructure.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseValidator>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
builder.Services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICourseReadRepository, CourseReadRepository>();
builder.Services.AddScoped<ICourseWriteRepository, CourseWriteRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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