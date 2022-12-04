using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Enigmatry.Shop.VendorClient.Extensions;

public static class Extension
{
    public static void AddDealerClients(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddRefitClient<IDealer1Client>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://myapi.com"));

        services
            .AddRefitClient<IDealer2Client>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://myapi.com"));

    }
}