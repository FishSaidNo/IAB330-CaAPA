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
    public class PromptController : TableController<Prompt>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<Prompt>(context, Request, Services);
        }

        // GET tables/Prompt
        public IQueryable<Prompt> GetAllPrompt()
        {
            return Query(); 
        }

        // GET tables/Prompt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Prompt> GetPrompt(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Prompt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Prompt> PatchPrompt(string id, Delta<Prompt> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Prompt
        public async Task<IHttpActionResult> PostPrompt(Prompt item)
        {
            Prompt current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Prompt/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePrompt(string id)
        {
             return DeleteAsync(id);
        }

    }
}