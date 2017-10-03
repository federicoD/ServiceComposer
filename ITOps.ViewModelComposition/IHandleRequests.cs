﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ServiceComposer.ViewModelComposition
{
    public interface IHandleRequests : IInterceptRoutes
    {
        Task Handle(dynamic vm, RouteData routeData, HttpRequest request);
    }
}
