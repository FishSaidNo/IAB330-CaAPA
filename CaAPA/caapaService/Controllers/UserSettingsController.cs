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
    public class UserSettingsController : TableController<UserSettings>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<UserSettings>(context, Request, Services);
        }

        // GET tables/UserSettings
        public IQueryable<UserSettings> GetAllUserSettings()
        {
            return Query(); 
        }

        // GET tables/UserSettings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserSettings> GetUserSettings(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserSettings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserSettings> PatchUserSettings(string id, Delta<UserSettings> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserSettings
        public async Task<IHttpActionResult> PostUserSettings(UserSettings item)
        {
            UserSettings current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserSettings/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserSettings(string id)
        {
             return DeleteAsync(id);
        }

    }
}