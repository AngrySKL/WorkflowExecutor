using FastEndpoints;
using FastEndpoints.ApiExplorer;
using FastEndpoints.Security;
using FastEndpoints.Swagger.Swashbuckle;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using WorkflowExecutor.SampleProject;
using WorkflowExecutor.SampleProject.Hardware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints();
builder.Services.AddFastEndpointsApiExplorer();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("WorkflowExecutor.Core")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "Please enter in following format: Bearer <Token>",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"}
                           },new string[] { }
                        }
                    });
    c.OperationFilter<FastEndpointsOperationFilter>();
});

builder.Services.AddWorkflow();
var tokenSigningKey = builder.Configuration["TokenSigningKey"];
builder.Services.AddJWTBearerAuth(tokenSigningKey);
builder.Services.AddWorkflowDSL();

builder.Services.AddSampleProjectSteps();
builder.Services.AddSampleProjectHardwares();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();
