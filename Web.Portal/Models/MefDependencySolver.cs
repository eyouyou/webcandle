using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Portal
{
    public class MefDependencySolver : IDependencyResolver
    {
        private readonly ComposablePartCatalog _catalog;
        private const string HttpContextKey = "MefContainerKey";

        public MefDependencySolver(ComposablePartCatalog catalog)
        {
            _catalog = catalog;
        }
        public CompositionContainer Container
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(HttpContextKey))
                    HttpContext.Current.Items.Add(HttpContextKey, new CompositionContainer(_catalog));
                CompositionContainer container = (CompositionContainer)HttpContext.Current.Items[HttpContextKey];
                HttpContext.Current.Application["Container"] = container;
                return container;
            }
        }

        public object GetService(Type serviceType)
        {
            string contractName = AttributedModelServices.GetContractName(serviceType);
            return Container.GetExportedValueOrDefault<object>(contractName);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetExportedValues<object>(serviceType.FullName);
        }
    }
}