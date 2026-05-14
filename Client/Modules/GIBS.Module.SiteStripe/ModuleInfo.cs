using Oqtane.Models;
using Oqtane.Modules;

namespace GIBS.Module.SiteStripe
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "SiteStripe",
            Description = "SiteStripe Oqtane Module for Amazon Affiliates",
            Version = "1.0.0",
            ServerManagerType = "GIBS.Module.SiteStripe.Manager.SiteStripeManager, GIBS.Module.SiteStripe.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "GIBS.Module.SiteStripe.Shared.Oqtane",
            PackageName = "GIBS.Module.SiteStripe" 
        };
    }
}
