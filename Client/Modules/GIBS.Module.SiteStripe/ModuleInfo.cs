using Oqtane.Models;
using Oqtane.Modules;

namespace GIBS.Module.SiteStripe
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "SiteStripe",
            Description = "GIBS Oqtane Module for Amazon Affiliates",
            Version = "1.0.4",
            ServerManagerType = "GIBS.Module.SiteStripe.Manager.SiteStripeManager, GIBS.Module.SiteStripe.Server.Oqtane",
            ReleaseVersions = "1.0.0,1.0.1,1.0.2,1.0.3,1.0.4",
            Dependencies = "GIBS.Module.SiteStripe.Shared.Oqtane",
            PackageName = "GIBS.Module.SiteStripe" 
        };
    }
}
