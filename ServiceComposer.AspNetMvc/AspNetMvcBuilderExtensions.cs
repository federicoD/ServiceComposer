using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ServiceComposer.AspNetMvc
{
    public static class AspNetMvcBuilderExtensions
    {
        public static IMvcBuilder AddViewModelCompositionMvcSupport(this IMvcBuilder builder)
            => AddViewModelCompositionMvcSupport(builder, "*.dll");

        public static IMvcBuilder AddViewModelCompositionMvcSupport(this IMvcBuilder builder, string assemblySearchPattern)
        {
            var fileNames = Directory.GetFiles(AppContext.BaseDirectory, assemblySearchPattern);

            var types = new List<Type>();
            foreach (var fileName in fileNames)
            {
                var temp = AssemblyLoader.Load(fileName)
                    .GetTypes()
                    .Where(t => !t.GetTypeInfo().IsAbstract && typeof(IHandleResult).IsAssignableFrom(t));

                types.AddRange(temp);
            }

            foreach (var type in types)
            {
                builder.Services.AddSingleton(typeof(IHandleResult), type);
            }

            builder.Services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(typeof(CompositionActionFilter));
            });

            return builder;
        }
    }
}
