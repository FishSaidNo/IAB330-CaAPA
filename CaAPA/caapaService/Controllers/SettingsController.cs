using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using caapaService.DataObjects;
using caapaService.Models;

namespace caapaService.Controllers
{
    public class SettingsController : TableController<Settings>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<Settings>(context, Request, Services);
        }

        // GET tables/Settings
        public IQueryable<Settings> GetAllSettings()
        {
            return Query(); 
        }

        // GET tables/Settings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Settings> GetSettings(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Settings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Settings> PatchSettings(string id, Delta<Settings> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Settings
        public async Task<IHttpActionResult> PostSettings(Settings item)
        {
            Settings current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Settings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSettings(string id)
        {
             return DeleteAsync(id);
        }

    }
}