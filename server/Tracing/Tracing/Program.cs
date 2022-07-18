using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.DataContext;
using Tracing.Repositories.application;
using Tracing.Repositories.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITracingRepo, CosmosTracingRepo>();
builder.Services.AddSingleton<IDocumentClient>(x =>
    new DocumentClient(new Uri(builder.Configuration["CosmosDB:AccountUrl"]), builder.Configuration["CosmosDB: PrimaryKey"]));
builder.Services.AddDbContext<TracingContext>(options => {
    options.UseCosmos(builder.Configuration.GetConnectionString("DefaultConnection"), "Owner");
}); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
