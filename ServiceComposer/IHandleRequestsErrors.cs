using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace ServiceComposer
{
    public interface IHandleRequestsErrors
    {
        Task OnRequestError(Exception ex, dynamic vm, RouteData routeData, HttpRequest request);
    }
}
