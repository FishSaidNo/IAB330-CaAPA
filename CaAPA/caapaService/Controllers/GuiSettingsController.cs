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
    public class GuiSettingsController : TableController<GuiSettings>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<GuiSettings>(context, Request, Services);
        }

        // GET tables/GuiSettings
        public IQueryable<GuiSettings> GetAllGuiSettings()
        {
            return Query(); 
        }

        // GET tables/GuiSettings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GuiSettings> GetGuiSettings(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GuiSettings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GuiSettings> PatchGuiSettings(string id, Delta<GuiSettings> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GuiSettings
        public async Task<IHttpActionResult> PostGuiSettings(GuiSettings item)
        {
            GuiSettings current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GuiSettings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGuiSettings(string id)
        {
             return DeleteAsync(id);
        }

    }
}