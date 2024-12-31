using CourseMarket.Application.Validators.Courses;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure;
using CourseMarket.Infrastructure.Concretes.Services.Storage.Local;
using CourseMarket.Infrastructure.Context;
using CourseMarket.Infrastructure.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// AddFluentValidation() deprecated olmus,
// asagidaki gibi herhangi bir validator ile assembly'deki tum validatory'leri register ediyoruz.
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseValidator>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddInfrastructureServices();
builder.Services.AddStorage<LocalStorage>();
// şimdilik sadece local storage destekleniyor. İleride AWS, Azure gibi storage'lar eklenebilir.

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); // wwwroot klasorundeki dosyalara erisim icin

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();