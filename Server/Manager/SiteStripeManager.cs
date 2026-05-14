using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Interfaces;
using Oqtane.Enums;
using Oqtane.Repository;
using GIBS.Module.SiteStripe.Repository;
using System.Threading.Tasks;

namespace GIBS.Module.SiteStripe.Manager
{
    public class SiteStripeManager : MigratableModuleBase, IInstallable, IPortable, ISearchable
    {
        private readonly ISiteStripeRepository _SiteStripeRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public SiteStripeManager(ISiteStripeRepository SiteStripeRepository, IDBContextDependencies DBContextDependencies)
        {
            _SiteStripeRepository = SiteStripeRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new SiteStripeContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new SiteStripeContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.SiteStripe> SiteStripes = _SiteStripeRepository.GetSiteStripes(module.ModuleId).ToList();
            if (SiteStripes != null)
            {
                content = JsonSerializer.Serialize(SiteStripes);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.SiteStripe> SiteStripes = null;
            if (!string.IsNullOrEmpty(content))
            {
                SiteStripes = JsonSerializer.Deserialize<List<Models.SiteStripe>>(content);
            }
            if (SiteStripes != null)
            {
                foreach(var SiteStripe in SiteStripes)
                {
                    _SiteStripeRepository.AddSiteStripe(new Models.SiteStripe { ModuleId = module.ModuleId, Name = SiteStripe.Name });
                }
            }
        }

        public Task<List<SearchContent>> GetSearchContentsAsync(PageModule pageModule, DateTime lastIndexedOn)
        {
           var searchContentList = new List<SearchContent>();

           foreach (var SiteStripe in _SiteStripeRepository.GetSiteStripes(pageModule.ModuleId))
           {
               if (SiteStripe.ModifiedOn >= lastIndexedOn)
               {
                   searchContentList.Add(new SearchContent
                   {
                       EntityName = "GIBSSiteStripe",
                       EntityId = SiteStripe.SiteStripeId.ToString(),
                       Title = SiteStripe.Name,
                       Body = SiteStripe.Name,
                       ContentModifiedBy = SiteStripe.ModifiedBy,
                       ContentModifiedOn = SiteStripe.ModifiedOn
                   });
               }
           }

           return Task.FromResult(searchContentList);
        }
    }
}
