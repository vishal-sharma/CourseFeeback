using Azure.Identity;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using CourseFeeback.Data;
using ProjectReview.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{Environment.GetEnvironmentVariable("AZURE_KEY_VAULT_NAME")}.vault.azure.net/"),
        new DefaultAzureCredential());
builder.Services.AddDbContext<CourseFeedbackContext>();

builder.Services.AddSingleton<ISentimentAnalysisService, SentimentAnalysisService>();
builder.Services.AddSingleton<ISentimentAnalysisClientBuillder, SentimentAnalysisClientBuillder>();

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
