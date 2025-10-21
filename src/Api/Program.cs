using Application.Services;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["Swagger:Title"] ?? "AuroraTrace API",
        Description = builder.Configuration["Swagger:Description"] ?? "API para gerenciamento AuroraTrace",
        Contact = new OpenApiContact
        {
            Name = builder.Configuration["Swagger:Contact:Name"],
            Email = builder.Configuration["Swagger:Contact:Email"]
        }
    });

    try
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            swagger.IncludeXmlComments(xmlPath);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Swagger XML Warning] Não foi possível carregar comentários XML: {ex.Message}");
    }
});

builder.Services.AddSingleton<AuroraMongoContext>();

builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<PatioService>();
builder.Services.AddScoped<SetorService>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<DeteccaoService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddHealthChecks()
    .AddMongoDb(builder.Configuration.GetConnectionString("MongoDB"), name: "mongodb");

var app = builder.Build();

app.MapHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuroraTrace API V1"));

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
