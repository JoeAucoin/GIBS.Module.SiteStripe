using Oqtane.Models;
using Oqtane.Modules;

namespace GIBS.Module.SiteStripe.List
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "SiteStripe List",
            Description = "Widgets For Displaying Blog SiteStripe Records In A Variety Of Formats",
            Version = "1.0.3",
            ServerManagerType = "GIBS.Module.SiteStripe.Manager.SiteStripeManager, GIBS.Module.SiteStripe.Server.Oqtane",
            ReleaseVersions = "1.0.0,1.0.1,1.0.2,1.0.3",
            Dependencies = "GIBS.Module.SiteStripe.Shared.Oqtane",
            PackageName = "GIBS.Module.SiteStripe.List" 
        };
    }
}
