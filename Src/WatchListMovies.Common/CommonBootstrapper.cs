using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WatchListMovies.Common.Application.Validation;

namespace WatchListMovies.Common
{
    public class CommonBootstrapper
    {
        public static void Init(IServiceCollection service)
        {
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        }
    }
}
