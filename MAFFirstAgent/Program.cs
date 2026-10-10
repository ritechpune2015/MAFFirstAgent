using MAFFirstAgent.Agents;
using MAFFirstAgent.Services;
using Microsoft.Agents.AI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();



var endpoint =
    builder.Configuration["Ollama:Endpoint"]
    ?? throw new InvalidOperationException(
        "Ollama:Endpoint is not configured.");

var modelName =
    builder.Configuration["Ollama:Model"]
    ?? throw new InvalidOperationException(
        "Ollama:Model is not configured.");


builder.Services.AddHttpClient("Ollama", client =>
    {
        client.BaseAddress = new Uri(
            builder.Configuration["Ollama:Endpoint"]!);
        client.Timeout = TimeSpan.FromMinutes(5);
    });

builder.Services.AddSingleton<AIAgent>(_ =>
    CustomerSupportAgentFactory.Create(
        endpoint,
        modelName));

builder.Services.AddScoped<AgentService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
