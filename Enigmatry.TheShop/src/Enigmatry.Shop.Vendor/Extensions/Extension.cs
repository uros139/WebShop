using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
