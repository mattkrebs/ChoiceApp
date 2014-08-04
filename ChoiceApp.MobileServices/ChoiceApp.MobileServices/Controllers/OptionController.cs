using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using ChoiceApp.MobileServices.DataObjects;
using ChoiceApp.MobileServices.Models;

namespace ChoiceApp.MobileServices.Controllers
{
    public class OptionController : TableController<MobileOption>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ChoiceContext context = new ChoiceContext();
            DomainManager = new EntityDomainManager<MobileOption>(context, Request, Services);
        }

        // GET tables/Option
        public IQueryable<MobileOption> GetAllOption()
        {
            return Query(); 
        }

        // GET tables/Option/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MobileOption> GetOption(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Option/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MobileOption> PatchOption(string id, Delta<MobileOption> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Option/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostOption(MobileOption item)
        {
            MobileOption current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Option/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteOption(string id)
        {
             return DeleteAsync(id);
        }

    }
}