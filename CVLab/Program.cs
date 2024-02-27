using CVLab.Data;
using CVLab.Services;
using CVLab.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>(); // Register the AuthenticationService
var connectionString = "mongodb://localhost:27017";
Console.Write(connectionString);
// Inject MongoDB services
builder.Services.AddSingleton<MongoDBService>(sp => new MongoDBService(connectionString, "Skill"));
builder.Services.AddSingleton<MongoDBService3>(sp => new MongoDBService3(connectionString, "WorkExperience"));
builder.Services.AddSingleton<MongoDBService2>(sp => new MongoDBService2(connectionString, "CvMainDate"));
builder.Services.AddSingleton<MongoDBService4>(sp => new MongoDBService4(connectionString, "Project"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Enable HSTS
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
