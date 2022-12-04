using Enigmatry.Shop.BestValueService;
using Enigmatry.Shop.DbAccess.Shop.Command;
using Enigmatry.Shop.DbAccess.Shop.Query;
using Enigmatry.Shop.Handlers.Extensions;
using Enigmatry.Shop.Models;
using Enigmatry.Shop.VendorClient.Extensions;
using Enigmatry.Shop.WareHouseService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator();
builder.Services.AddDealerClients(builder.Configuration);
builder.Services.AddSingleton<IBestValueService, BestValueService>();
builder.Services.AddSingleton<IWareHouseService, WareHouseService>();

//cached articles
builder.Services.AddSingleton<Dictionary<int, Article>>();
//db mock
builder.Services.AddSingleton<List<Article>>();
builder.Services.AddSingleton<ArticleQuery>();
builder.Services.AddSingleton<ArticleCommand>();

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
