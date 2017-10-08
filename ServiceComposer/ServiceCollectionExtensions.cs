﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ServiceComposer
{
    public static class ServiceCollectionExtensions
    {
        public static void AddViewModelComposition(this IServiceCollection services) 
            => AddViewModelComposition(services, "*.dll");

        public static void AddViewModelComposition(this IServiceCollection services, string assemblySearchPattern)
        {
            var fileNames = Directory.GetFiles(AppContext.BaseDirectory, assemblySearchPattern);

            var types = new List<Type>();
            foreach (var fileName in fileNames)
            {
                var temp = AssemblyLoader.Load(fileName)
                    .GetTypes()
                    .Where(t => !t.GetTypeInfo().IsAbstract && typeof(IInterceptRoutes).IsAssignableFrom(t));

                types.AddRange(temp);
            }

            foreach (var type in types)
            {
                services.AddSingleton(typeof(IInterceptRoutes), type);
            }
        }
    }
}
