using System;
using System.Composition;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace LeightweightCompositionDotNet.Mvc
{
    /// <summary>
    ///     Provides lifetime management for the <see cref="CompositionProvider" /> type.
    ///     This module is automatically injected into the ASP.NET request processing
    ///     pipeline at startup and should not be called by user code.
    /// </summary>
    public class RequestCompositionScopeModule : IHttpModule
    {
        private static bool _isInitialized;

        /// <summary>
        ///     Release resources used by the module.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        ///     Initialize the module.
        /// </summary>
        /// <param name="context">Application in which the module is running.</param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += DisposeCompositionScope;

            CompositionProvider.PostStartDefaultInitialize();
        }

        /// <summary>
        ///     Register the module. This method is automatically called
        ///     at startup and should not be called by user code.
        /// </summary>
        public static void Register()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                DynamicModuleUtility.RegisterModule(typeof (RequestCompositionScopeModule));
            }
        }

        private static void DisposeCompositionScope(object sender, EventArgs e)
        {
            var scope = CompositionProvider.CurrentInitialisedScope;

            if (scope != null)
                scope.Dispose();
        }
    }
}