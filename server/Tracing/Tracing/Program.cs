using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.DataContext;
using Tracing.DataAccess.Profiles;
using Tracing.Services.implementation;
using Tracing.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITracingRepo, CosmosTracingRepo>();
builder.Services.AddScoped<IOwnerRegistration, OwnerRegistration>();
builder.Services.AddSingleton<IDocumentClient>(x =>
    new DocumentClient(new Uri(builder.Configuration["CosmosDB:AccountUrl"]), builder.Configuration["CosmosDB: PrimaryKey"]));
builder.Services.AddDbContext<TracingContext>(options => {
    options.UseCosmos(builder.Configuration.GetConnectionString("DefaultConnection"), "Tracing");
}); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(typeof(TracingProfile).Assembly);

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
