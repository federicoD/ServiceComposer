﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ServiceComposer
{
    interface ISubscription
    {
        Task Invoke(dynamic viewModel, object @event, RouteData routeData, HttpRequest request);
    }
}
