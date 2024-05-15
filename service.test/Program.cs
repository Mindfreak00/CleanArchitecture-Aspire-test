using System.Runtime.Loader;
using Application.Investors.Queries.GetInvestorList;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

var files = Directory.GetFiles(
    AppDomain.CurrentDomain.BaseDirectory,
    "CleanArchitecture*.dll");
var assemblies = files
    .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ensure this registers the necessary services
builder.Services.AddAdvancedDependencyInjection();

// Register services from assemblies
builder.Services.Scan(p => p.FromAssemblies(assemblies)
    .AddClasses()
    .AsMatchingInterface());

// Ensure IGetInvestorsListQuery is registered
builder.Services.AddScoped<IGetInvestorsListQuery, GetInvestorsListQuery>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAdvancedDependencyInjection();

app.Run();