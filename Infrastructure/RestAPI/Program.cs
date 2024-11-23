using Doselete.Application.UserCase;
using Doselete.Domain.Entity;
using Doselete.Domain.Repository.Data;
using Doselete.Domain.Repository.Service;
using Doselete.Infrastructure.RestAPI.Middleware;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

//Add DB .. only MySQL
if (builder.Environment.EnvironmentName == Environments.Development)
{
    // MySql -> MariaDB 10.*
    builder.Services.AddScoped<IDbConnection, MySqlConnection>();
}
else
{
    //SQLServer 17.*
    //builder.Services.AddScoped<IDbConnection, SqlConnection>();
}
//Add Dependency Inyection
builder.Services.AddScoped<IMasterData, MasterData>();
builder.Services.AddScoped<IMasterManager, MasterManager>();
builder.Services.AddScoped<ITemplateData, TemplateData>();
builder.Services.AddScoped<ITemplateFieldData, TemplateFieldData>();
builder.Services.AddScoped<ITemplateAllowedChildrenData, TemplateAllowedChildrenData>();
builder.Services.AddScoped<IProductData<TvMazeProduct>, TvMazeData>();

builder.Services.AddScoped<ITvMazeService, TvMazeService>();

builder.Services.AddScoped<ITemplateManager, TemplateManager>();
builder.Services.AddScoped<INodeData, NodeData>();
builder.Services.AddScoped<INodeRelationData, NodeRelationData>();
builder.Services.AddScoped<INodeManager, NodeManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();

// Add services to the container.
builder.Services.AddHttpClient<TvMazeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("X-API-KEY", new OpenApiSecurityScheme
    {
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme",
        In = ParameterLocation.Header,
        Description = "ApiKey must appear in header"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "X-API-KEY"
                },
                In = ParameterLocation.Header
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{ 
}
app.UseMiddleware<ApiKeyMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
