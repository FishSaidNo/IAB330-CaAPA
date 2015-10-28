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
    public class PromptStepController : TableController<PromptStep>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            caapaContext context = new caapaContext();
            DomainManager = new EntityDomainManager<PromptStep>(context, Request, Services);
        }

        // GET tables/PromptStep
        public IQueryable<PromptStep> GetAllPromptStep()
        {
            return Query(); 
        }

        // GET tables/PromptStep/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PromptStep> GetPromptStep(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PromptStep/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PromptStep> PatchPromptStep(string id, Delta<PromptStep> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PromptStep
        public async Task<IHttpActionResult> PostPromptStep(PromptStep item)
        {
            PromptStep current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PromptStep/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePromptStep(string id)
        {
             return DeleteAsync(id);
        }

    }
}