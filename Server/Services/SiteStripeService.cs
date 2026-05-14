using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using GIBS.Module.SiteStripe.Repository;

namespace GIBS.Module.SiteStripe.Services
{
    public class ServerSiteStripeService : ISiteStripeService
    {
        private readonly ISiteStripeRepository _SiteStripeRepository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public ServerSiteStripeService(ISiteStripeRepository SiteStripeRepository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _SiteStripeRepository = SiteStripeRepository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public Task<List<Models.SiteStripe>> GetSiteStripesAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_SiteStripeRepository.GetSiteStripes(ModuleId).ToList());
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public Task<Models.SiteStripe> GetSiteStripeAsync(int SiteStripeId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_SiteStripeRepository.GetSiteStripe(SiteStripeId));
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Get Attempt {SiteStripeId} {ModuleId}", SiteStripeId, ModuleId);
                return null;
            }
        }

        public Task<Models.SiteStripe> AddSiteStripeAsync(Models.SiteStripe SiteStripe)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, SiteStripe.ModuleId, PermissionNames.Edit))
            {
                SiteStripe = _SiteStripeRepository.AddSiteStripe(SiteStripe);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "SiteStripe Added {SiteStripe}", SiteStripe);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Add Attempt {SiteStripe}", SiteStripe);
                SiteStripe = null;
            }
            return Task.FromResult(SiteStripe);
        }

        public Task<Models.SiteStripe> UpdateSiteStripeAsync(Models.SiteStripe SiteStripe)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, SiteStripe.ModuleId, PermissionNames.Edit))
            {
                SiteStripe = _SiteStripeRepository.UpdateSiteStripe(SiteStripe);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "SiteStripe Updated {SiteStripe}", SiteStripe);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Update Attempt {SiteStripe}", SiteStripe);
                SiteStripe = null;
            }
            return Task.FromResult(SiteStripe);
        }

        public Task DeleteSiteStripeAsync(int SiteStripeId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                _SiteStripeRepository.DeleteSiteStripe(SiteStripeId);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "SiteStripe Deleted {SiteStripeId}", SiteStripeId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Delete Attempt {SiteStripeId} {ModuleId}", SiteStripeId, ModuleId);
            }
            return Task.CompletedTask;
        }
    }
}
