namespace Kestrelancy.Bootstrappers
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.Diagnostics;
    using Nancy.Extensions;
    using Nancy.TinyIoc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultApplicationBootstrapper : DefaultNancyBootstrapper
    {

        private string _root;

        public DefaultApplicationBootstrapper(string root)
        {
            _root = root;
        }

        protected override IEnumerable<ModuleRegistration> Modules
        {
            get
            {
                var mcs = this.TypeCatalog
                     .GetTypesAssignableTo<INancyModule>(TypeResolveStrategies.All)
                     .NotOfType<DiagnosticModule>()
                     .Select(t => new ModuleRegistration(t))
                     .ToArray();
                return mcs;
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // We don't call "base" here to prevent auto-discovery of
            // types/dependencies
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions = new List<Func<NancyContext, string, Response>>
            {
                StaticContentConventionBuilder.AddDirectory("/" , System.IO.Path.Combine(_root , "wwwroot"))
            };
            base.ConfigureConventions(nancyConventions);
        }

    }
}