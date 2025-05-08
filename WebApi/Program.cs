using Infraestructura;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
    policy =>
    {
        policy.WithOrigins("https://localhost:7243")
     .AllowAnyHeader()
     .AllowAnyMethod();
    });
});


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = "https://localhost:7005/",
            ValidAudience = "https://localhost:7005/",
            IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("GmCuH67mzPWYbb4W4uDLPprHjzLh01jTpJWmZoLy620jfTT9nWP5zg="))
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "Descripción de mi API",
        Contact = new OpenApiContact
        {
            Name = "Tu Nombre",
            Email = "tu@email.com"
        }
    });

    // Asegura que la versión de OpenAPI se establezca explícitamente
    c.AddServer(new OpenApiServer { Url = "https://localhost:7005" }); // Opcional, pero recomendado

    // Configura la versión de OpenAPI (3.0.1 en este caso)
    c.UseOneOfForPolymorphism(); // Opcional, pero puede ayudar en algunos casos
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    });
}


app.UseCors("AllowLocalhost5173");

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();