using Enigmatry.Vendor.DataAccess.Commands;
using Enigmatry.Vendor.DataAccess.Queries;
using Enigmatry.Vendor.Handlers.Extensions;
using Enigmatry.Vendor.Models;
using Enigmatry.Vendor.SupplierService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator();
builder.Services.AddSingleton<ISupplierService, SupplierService>();
builder.Services.AddSingleton<ArticleCommand>();
builder.Services.AddSingleton<ArticleQuery>();
builder.Services.AddSingleton<List<Article>>();

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
