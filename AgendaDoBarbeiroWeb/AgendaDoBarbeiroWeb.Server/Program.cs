global using AgendaDoBarbeiro.Core;
global using AgendaDoBarbeiro.Core.Service;
global using AgendaDoBarbeiro.Core.Dtos;
global using AgendaDoBarbeiro.Core.Enum;
global using AgendaDoBarbeiro.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IProfessionalService, AgendaDoBarbeiro.Service.ProfessionalService>();
builder.Services.AddTransient<IEnterpriseService, EnterpriseService>();
builder.Services.AddTransient<IAddressService, AddressService>();


builder.Services.AddDbContext<AgendaDoBarbeiroContext>(
                options =>
                {
                    options.EnableSensitiveDataLogging();
                    options.UseNpgsql(builder.Configuration.GetConnectionString("BarbeariaConnection"));
                });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaDoBarbeiroApi", Version = "v1" });
    
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();

});


builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();


app.UseDefaultFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapFallbackToFile("/index.html");

app.Run();

