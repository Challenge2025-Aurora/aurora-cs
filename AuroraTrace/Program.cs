using AuroraTrace.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"],
        Description = builder.Configuration["Swagger:Description"],
        Contact = new OpenApiContact
        {
            Name = builder.Configuration["Swagger:Contact:Name"],
            Email = builder.Configuration["Swagger:Contact:Email"]
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    swagger.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<AuroraTraceContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("ORACLE_CONN");
    options.UseOracle(connectionString)
           .UseLazyLoadingProxies();
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
