using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Web.Mvc;

namespace LightweightCompositionDotNet.Mvc
{
    internal class CompositionScopeFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        public CompositionScopeFilterAttributeFilterProvider()
            : base(false)
        {
        }

        protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetActionAttributes(controllerContext, actionDescriptor).ToArray();
            ComposeAttributes(attributes);
            return attributes;
        }

        protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetControllerAttributes(controllerContext, actionDescriptor).ToArray();
            ComposeAttributes(attributes);
            return attributes;
        }

        private void ComposeAttributes(IEnumerable<FilterAttribute> attributes)
        {
            foreach (var attribute in attributes)
                CompositionProvider.Current.SatisfyImports(attribute);
        }
    }
}