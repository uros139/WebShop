using Enigmatry.Shop.Models;
using Enigmatry.Shop.VendorClient;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Enigmatry.Shop.Dealer2Service
{
    public class Dealer2Service : IDealer2Service
    {
        private readonly IDealer2Client _client;
        private readonly ILogger<Dealer2Service> _logger;

        public Dealer2Service(IDealer2Client client, ILogger<Dealer2Service> logger)
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
                _logger.LogInformation("Trying to retrieve article from dealer 2");
                var response = await _client.GetArticle(id);

                switch (response.IsSuccessStatusCode)
                {
                    case true when response.Content != null:
                        found = true;
                        article = response.Content.Adapt<Article>();
                        break;
                    case false:
                        _logger.LogWarning($"Failed to get article from dealer 2: {response.Error}");
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get article from dealer 2:{ex.Message}");
                return (false, null);
            }

            return (found, article);
        }
    }
}