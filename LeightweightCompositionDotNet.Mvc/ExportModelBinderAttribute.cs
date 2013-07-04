﻿using System;
using System.Composition;
using System.Web.Mvc;

namespace LeightweightCompositionDotNet.Mvc
{
    /// <summary>
    ///     Marks a type as being a model binder for a specified model type. The type decorated with
    ///     this attribute must implement the <see cref="IModelBinder" /> interface.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ExportModelBinderAttribute : ExportAttribute
    {
        /// <summary>
        ///     Construct an instance of the <see cref="ExportModelBinderAttribute" />.
        /// </summary>
        /// <param name="modelType">The model type bound by the model binder.</param>
        public ExportModelBinderAttribute(Type modelType)
            : base(CompositionScopeModelBinderProvider.GetModelBinderContractName(modelType), typeof (IModelBinder))
        {
        }
    }
}