using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Models;
using Tracing.Services.implementation;
using Tracing.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITracingRepo, CosmosTracingRepo>();
builder.Services.AddScoped<IOwnerRegistration, OwnerRegistration>();
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddSingleton<IDocumentClient>(x =>
    new DocumentClient(new Uri(builder.Configuration["CosmosDB:AccountUrl"]), builder.Configuration["CosmosDB: PrimaryKey"]));
builder.Services.AddDbContext<TracingContext>(options => {
    options.UseCosmos(builder.Configuration.GetConnectionString("DefaultConnection"), "Tracing");
});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
