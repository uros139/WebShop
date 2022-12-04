using Enigmatry.Shop.Models;
using Enigmatry.Shop.VendorClient;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Shop.Dealer1Service
{
    public class Dealer1Service : IDealer1Service
    {
        private readonly IDealer1Client _client;
        private readonly ILogger<Dealer1Service> _logger;

        public Dealer1Service(IDealer1Client client, ILogger<Dealer1Service> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<(bool, Article)> GetArticle(int id)
        {
            var found = false;
            Article? article = new Article();
            try
            {
                _logger.LogInformation("Trying to retrieve article from dealer 1");
                var response = await _client.GetArticle(id);

                switch (response.IsSuccessStatusCode)
                {
                    case true when response.Content != null:
                        found = true;
                        article = response.Content.Adapt<Article>();
                        break;
                    case false:
                        _logger.LogWarning($"Failed to get article from dealer 1: {response.Error}");
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get article from dealer 1:{ex.Message}");
                return (false, null);
            }

            return (found, article);
        }
    }
}