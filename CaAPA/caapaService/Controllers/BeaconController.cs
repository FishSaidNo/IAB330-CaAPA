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
    public class BeaconController : TableController<Beacon>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<Beacon>(context, Request, Services);
        }

        // GET tables/Beacon
        public IQueryable<Beacon> GetAllBeacon()
        {
            return Query(); 
        }

        // GET tables/Beacon/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Beacon> GetBeacon(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Beacon/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Beacon> PatchBeacon(string id, Delta<Beacon> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Beacon
        public async Task<IHttpActionResult> PostBeacon(Beacon item)
        {
            Beacon current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Beacon/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBeacon(string id)
        {
             return DeleteAsync(id);
        }

    }
}