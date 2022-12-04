using Enigmatry.Vendor.Models;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Vendor.SupplierService;

public class SupplierService : ISupplierService
{
    private ILogger<SupplierService> _logger;

    public SupplierService(ILogger<SupplierService> logger)
    {
        _logger = logger;   
    }

    public async Task<bool> ArticleInInventory(int id)
    {
        _logger.LogInformation($"Checking availability of article Id: {id}");
        return await Task.FromResult(new Random().NextDouble() >= 0.5);
    }

    public async Task<Article> GetArticle(int id)
    {
        _logger.LogInformation($"Retrieving article: {id}");

        return await Task.FromResult(new Article()
        {
            Id = id,
            Name = $"Article {id}",
            Price = new Random().Next(100, 500)
        });
    }
}