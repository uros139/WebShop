using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Enigmatry.Vendor.Handlers.Extensions;

public static class Extension
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extension));
    }
}
