using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrabalhoA2.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TrabalhoA2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrabalhoA2Context") ?? throw new InvalidOperationException("Connection string 'TrabalhoA2Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Nosso Novo T?tulo do Swagger",
            Description = "Essa ? a forma de fazermos uma nova descri??o de nossa API",
            Contact = new OpenApiContact
            {
                Name = "Trabalho A2",
                Email = "kauemilhomem@gmail.com",
                Url = new Uri("https://unitins.br")
            }
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

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
