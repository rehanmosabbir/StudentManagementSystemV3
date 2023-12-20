using Microsoft.AspNetCore.Hosting;
using StudentManagementSystemV3;
using StudentManagementSystemV3.Core.Interfaces;
using StudentManagementSystemV3.Core.Models;
using StudentManagementSystemV3.Infrastructure;
using StudentManagementSystemV3.Infrastructure.Repositories;
using StudentManagementSystemV3.Services;
using StudentManagementSystemV3.Services.Interfaces;
using System.Text.Json.Serialization;
using StudentManagementSystemV3.Infrastructure.ServiceExtension;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var issuerValue = builder.Configuration.GetValue<string>("Issuer");
var audienceValue = builder.Configuration.GetValue<string>("Audience");
var keyValue = builder.Configuration.GetValue<string>("Secret");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuerValue, // Replace with your actual issuer
            ValidAudience = audienceValue, // Replace with your actual audience
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue)) // Replace with your actual secret key
        };
    });

builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddCors();
//builder.Services.AddControllers().AddJsonOptions(x =>
//{
//    // serialize enums as strings in api responses (e.g. Role)
//    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

//    // ignore omitted parameters on models to enable optional params (e.g. User update)
//    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Configure JWT authentication for Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter your JWT token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // or another scheme like "api-key"
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
            {
                { securityScheme, new[] { "Bearer" } }
            };
    c.AddSecurityRequirement(securityRequirement);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMS API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
