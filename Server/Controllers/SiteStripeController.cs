using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using GIBS.Module.SiteStripe.Services;
using Oqtane.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace GIBS.Module.SiteStripe.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class SiteStripeController : ModuleControllerBase
    {
        private readonly ISiteStripeService _SiteStripeService;

        public SiteStripeController(ISiteStripeService SiteStripeService, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _SiteStripeService = SiteStripeService;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<IEnumerable<Models.SiteStripe>> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return await _SiteStripeService.GetSiteStripesAsync(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/site/5
        [HttpGet("site/{siteid}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<IEnumerable<Models.SiteStripe>> GetBySiteId(int siteid)
        {
            if (IsAuthorizedEntityId(EntityNames.Site, siteid))
            {
                return await _SiteStripeService.GetSiteStripesBySiteIdAsync(siteid);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Get Attempt {SiteId}", siteid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}/{moduleid}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<Models.SiteStripe> Get(int id, int moduleid)
        {
            Models.SiteStripe SiteStripe = await _SiteStripeService.GetSiteStripeAsync(id, moduleid);
            if (SiteStripe != null && IsAuthorizedEntityId(EntityNames.Module, SiteStripe.ModuleId))
            {
                return SiteStripe;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Get Attempt {SiteStripeId} {ModuleId}", id, moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Models.SiteStripe> Post([FromBody] Models.SiteStripe SiteStripe)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, SiteStripe.ModuleId))
            {
                SiteStripe = await _SiteStripeService.AddSiteStripeAsync(SiteStripe);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Post Attempt {SiteStripe}", SiteStripe);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                SiteStripe = null;
            }
            return SiteStripe;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Models.SiteStripe> Put(int id, [FromBody] Models.SiteStripe SiteStripe)
        {
            if (ModelState.IsValid && SiteStripe.SiteStripeId == id && IsAuthorizedEntityId(EntityNames.Module, SiteStripe.ModuleId))
            {
                SiteStripe = await _SiteStripeService.UpdateSiteStripeAsync(SiteStripe);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Put Attempt {SiteStripe}", SiteStripe);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                SiteStripe = null;
            }
            return SiteStripe;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}/{moduleid}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task Delete(int id, int moduleid)
        {
            Models.SiteStripe SiteStripe = await _SiteStripeService.GetSiteStripeAsync(id, moduleid);
            if (SiteStripe != null && IsAuthorizedEntityId(EntityNames.Module, SiteStripe.ModuleId))
            {
                await _SiteStripeService.DeleteSiteStripeAsync(id, SiteStripe.ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized SiteStripe Delete Attempt {SiteStripeId} {ModuleId}", id, moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
