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
    public class MapController : TableController<Map>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<Map>(context, Request, Services);
        }

        // GET tables/Map
        public IQueryable<Map> GetAllMap()
        {
            return Query(); 
        }

        // GET tables/Map/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Map> GetMap(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Map/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Map> PatchMap(string id, Delta<Map> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Map
        public async Task<IHttpActionResult> PostMap(Map item)
        {
            Map current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Map/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMap(string id)
        {
             return DeleteAsync(id);
        }

    }
}