﻿using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace LightweightCompositionDotNet.Mvc
{
    internal class CompositionScopeHttpDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            object export;

            if (!CompositionProvider.Current.TryGetExport(serviceType, null, out export))
                return null;

            return export;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return CompositionProvider.Current.GetExports(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}