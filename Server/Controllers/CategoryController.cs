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
    public class SiteStripeCategoryController : ModuleControllerBase
    {
        private readonly ICategoryService _categoryService;

        public SiteStripeCategoryController(ICategoryService categoryService, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _categoryService = categoryService;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<IEnumerable<Models.Category>> Get(string moduleid)
        {
            if (int.TryParse(moduleid, out int ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return await _categoryService.GetCategoriesAsync(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Category Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5/moduleid
        [HttpGet("{id}/{moduleid}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<Models.Category> Get(int id, int moduleid)
        {
            Models.Category category = await _categoryService.GetCategoryAsync(id, moduleid);
            if (category != null && IsAuthorizedEntityId(EntityNames.Module, category.ModuleId))
            {
                return category;
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Category Get Attempt {CategoryId} {ModuleId}", id, moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Models.Category> Post([FromBody] Models.Category category)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, category.ModuleId))
            {
                category = await _categoryService.AddCategoryAsync(category);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Category Post Attempt {Category}", category);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                category = null;
            }
            return category;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Models.Category> Put(int id, [FromBody] Models.Category category)
        {
            if (ModelState.IsValid && category.CategoryId == id && IsAuthorizedEntityId(EntityNames.Module, category.ModuleId))
            {
                category = await _categoryService.UpdateCategoryAsync(category);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Category Put Attempt {Category}", category);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                category = null;
            }
            return category;
        }
        // GET api/<controller>/site/5
        [HttpGet("site/{siteid}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<IEnumerable<Models.Category>> GetBySiteId(int siteid)
        {
            if (IsAuthorizedEntityId(EntityNames.Site, siteid))
            {
                return await _categoryService.GetCategoriesBySiteIdAsync(siteid);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Category Get By SiteId Attempt {SiteId}", siteid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // DELETE api/<controller>/5/moduleid
        [HttpDelete("{id}/{moduleid}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task Delete(int id, int moduleid)
        {
            if (IsAuthorizedEntityId(EntityNames.Module, moduleid))
            {
                await _categoryService.DeleteCategoryAsync(id, moduleid);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Category Delete Attempt {CategoryId} {ModuleId}", id, moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
