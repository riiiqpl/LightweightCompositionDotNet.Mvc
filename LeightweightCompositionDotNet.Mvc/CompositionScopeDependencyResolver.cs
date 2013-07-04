using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LeightweightCompositionDotNet.Mvc
{
    internal class CompositionScopeDependencyResolver : IDependencyResolver
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
    }
}