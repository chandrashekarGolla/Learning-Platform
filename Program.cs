/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
*/

/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Repositories; // Make sure to import your repository namespace
using Models;
using Microsoft.Azure.Cosmos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Cosmos DB Configuration
*//**//*builder.Services.AddSingleton<CosmosClient>(provider =>
{
    var cosmosDbSettings = provider.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
    return new CosmosClient(cosmosDbSettings.EndpointUri, cosmosDbSettings.PrimaryKey);
});
builder.Services.AddSingleton<ICosmosDbClient, CosmosDbClient>();
builder.Services.AddSingleton<IChapterRepository, ChapterRepository>(); // Assuming you have ChapterRepository implementation
builder.Services.AddSingleton<ICourseRepository, CourseRepository>(); // Assuming you have CourseRepository implementation

// Swagger Configuration
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
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Models;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Retrieve Cosmos DB configuration from appsettings.json
var cosmosDBConfig = builder.Configuration.GetSection("CosmosDbSettings");
var endpointUri = cosmosDBConfig.GetValue<string>("EndpointUri");
var primaryKey = cosmosDBConfig.GetValue<string>("PrimaryKey");

// Validate configuration values
if (string.IsNullOrEmpty(endpointUri) || string.IsNullOrEmpty(primaryKey))
{
    throw new ArgumentNullException("Configuration values for CosmosDB are null or empty.");
}

// Create CosmosClient instance
var cosmosClient = new CosmosClient(endpointUri, primaryKey);

// Register CosmosClient instance and repositories
builder.Services.AddSingleton(cosmosClient);
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
builder.Services.AddSingleton<IChapterRepository, ChapterRepository>();

// Swagger Configuration
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
