using System;
using System.Web.Mvc;

namespace LeightweightCompositionDotNet.Mvc
{
    internal class CompositionScopeModelBinderProvider : IModelBinderProvider
    {
        private const string ModelBinderContractNameSuffix = "++ModelBinder";

        public IModelBinder GetBinder(Type modelType)
        {
            IModelBinder export;

            if (!CompositionProvider.Current.TryGetExport(GetModelBinderContractName(modelType), out export))
                return null;

            return export;
        }

        public static string GetModelBinderContractName(Type modelType)
        {
            return modelType.AssemblyQualifiedName + ModelBinderContractNameSuffix;
        }
    }
}