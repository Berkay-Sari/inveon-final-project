using System.Security.Claims;
using System.Text;
using CourseMarket.API.Configurations.ColumnWriters;
using CourseMarket.Application.Validators.Courses;
using CourseMarket.Domain.Entities;
using CourseMarket.Infrastructure;
using CourseMarket.Infrastructure.Concretes.Services.Storage.Local;
using CourseMarket.Infrastructure.Context;
using CourseMarket.Infrastructure.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using Serilog.Core;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// AddFluentValidation() deprecated olmus,
// asagidaki gibi herhangi bir validator ile assembly'deki tum validatory'leri register ediyoruz.
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseValidator>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//PostgreSQL connection
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connStr));

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            ClockSkew = TimeSpan.Zero,

            NameClaimType = ClaimTypes.Name
        };
    });

var log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.PostgreSQL(connStr, "logs",
        needAutoCreateTable: true,
        columnOptions: new Dictionary<string, ColumnWriterBase>
        {
            {"message", new RenderedMessageColumnWriter()},
            {"message_template", new MessageTemplateColumnWriter()},
            {"level", new LevelColumnWriter() },
            {"time_stamp", new TimestampColumnWriter() },
            {"exception", new ExceptionColumnWriter() },
            {"log_event", new LogEventSerializedColumnWriter()},
            {"user_name", new UsernameColumnWriter()}
        })
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/json");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles(); //wwwroot klasorundeki dosyalara erisim icin

app.UseSerilogRequestLogging();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// log middleware
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated == true
        ? context.User.Identity.Name
        : null;
    LogContext.PushProperty("user_name", username);
    await next();
});


app.MapControllers();

app.Run();