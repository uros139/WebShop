using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Enigmatry.Shop.Handlers.Extensions;

public static class Extension
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extension));
    }
}
