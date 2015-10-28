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
    public class ReminderController : TableController<Reminder>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<Reminder>(context, Request, Services);
        }

        // GET tables/Reminder
        public IQueryable<Reminder> GetAllReminder()
        {
            return Query(); 
        }

        // GET tables/Reminder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Reminder> GetReminder(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Reminder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Reminder> PatchReminder(string id, Delta<Reminder> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Reminder
        public async Task<IHttpActionResult> PostReminder(Reminder item)
        {
            Reminder current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Reminder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteReminder(string id)
        {
             return DeleteAsync(id);
        }

    }
}