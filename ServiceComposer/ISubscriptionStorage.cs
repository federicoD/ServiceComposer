﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace ServiceComposer
{
    public interface ISubscriptionStorage
    {
        void Subscribe<T>(Func<dynamic, T, RouteData, HttpRequest, Task> subscription);
    }
}
