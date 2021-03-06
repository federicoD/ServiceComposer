﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace ServiceComposer.ApiGateway
{
    public static class ApplicationBuilderExtensions
    {
        public static void RunCompositionApiGateway(this IApplicationBuilder app, Action<IRouteBuilder> routes = null)
        {
            var routeBuilder = new RouteBuilder(app);
            routes?.Invoke(routeBuilder);

            app.UseRouter(routeBuilder.Build());
        }

        public static void RunCompositionApiGatewayWithDefaultRoutes(this IApplicationBuilder app)
        {
            app.RunCompositionApiGateway(routes =>
            {
                routes.MapComposableGet( template: "{controller}/{id:int?}");
                routes.MapRoute("{*NotFound}", context =>
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return Task.CompletedTask;
                });
            });
        }
    }
}