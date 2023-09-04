using FastEndpoints;
using FastEndpoints.ApiExplorer;
using FastEndpoints.Swagger.Swashbuckle;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using WorkflowExecutor.SampleProject;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints();
builder.Services.AddFastEndpointsApiExplorer();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("WorkflowExecutor.Core")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.OperationFilter<FastEndpointsOperationFilter>();
});

builder.Services.AddSampleProjectSteps();

builder.Services.AddWorkflow();
builder.Services.AddWorkflowDSL();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SamplePolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SamplePolicy");

app.UseRouting();
app.UseFastEndpoints();

app.Run();
