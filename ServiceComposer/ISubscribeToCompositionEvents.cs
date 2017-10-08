using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ServiceComposer
{
    public interface ISubscribeToCompositionEvents : IInterceptRoutes
    {
        void Subscribe(ISubscriptionStorage subscriptionStorage, RouteData routeData, HttpRequest request);
    }
}
