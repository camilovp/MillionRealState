using Mapster;
using Microsoft.Extensions.FileProviders;
using RealState.Api.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(options =>
{
    // título y versión
    options.SwaggerDoc("v1", new()
    {
        Title = "Million Real-Estate API",
        Version = "v1"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

});

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMongo(builder.Configuration);
builder.Services.AddUseCases();
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();


//mapers
var mapsterConfig = TypeAdapterConfig.GlobalSettings;
mapsterConfig.AddMapsterConfigs();
builder.Services.AddSingleton(mapsterConfig);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Million API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "PropertyImages")),
    RequestPath = "/PropertyImages"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
