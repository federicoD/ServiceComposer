using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace ServiceComposer.ViewModelComposition
{
    class Subscription<T> : ISubscription
    {
        private Func<dynamic, T, RouteData, HttpRequest, Task> handle;

        public Subscription(Func<dynamic, T, RouteData, HttpRequest, Task> handle)
        {
            this.handle = handle;
        }

        public Task Invoke(dynamic viewModel, object @event, RouteData routeData, HttpRequest request) 
            => handle(viewModel, (T)@event, routeData, request);
    }
}
