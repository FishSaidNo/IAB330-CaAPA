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
    public class UserMapsController : TableController<UserMaps>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<UserMaps>(context, Request, Services);
        }

        // GET tables/UserMaps
        public IQueryable<UserMaps> GetAllUserMaps()
        {
            return Query(); 
        }

        // GET tables/UserMaps/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserMaps> GetUserMaps(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserMaps/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserMaps> PatchUserMaps(string id, Delta<UserMaps> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserMaps
        public async Task<IHttpActionResult> PostUserMaps(UserMaps item)
        {
            UserMaps current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserMaps/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserMaps(string id)
        {
             return DeleteAsync(id);
        }

    }
}