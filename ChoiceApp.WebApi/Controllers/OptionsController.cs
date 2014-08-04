using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChoiceApp.WebApi.Models;

namespace ChoiceApp.WebApi.Controllers
{
    public class OptionsController : ApiController
    {
        private ChoiceContext db = new ChoiceContext();

        // GET: api/Options
        public IQueryable<Option> GetOptions()
        {
            return db.Options;
        }

        // GET: api/Options/5
        [ResponseType(typeof(Option))]
        public async Task<IHttpActionResult> GetOption(Guid id)
        {
            Option option = await db.Options.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        // PUT: api/Options/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOption(Guid id, Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != option.OptionId)
            {
                return BadRequest();
            }

            db.Entry(option).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Options
        [ResponseType(typeof(Option))]
        public async Task<IHttpActionResult> PostOption(Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Options.Add(option);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = option.OptionId }, option);
        }

        // DELETE: api/Options/5
        [ResponseType(typeof(Option))]
        public async Task<IHttpActionResult> DeleteOption(Guid id)
        {
            Option option = await db.Options.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            db.Options.Remove(option);
            await db.SaveChangesAsync();

            return Ok(option);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OptionExists(Guid id)
        {
            return db.Options.Count(e => e.OptionId == id) > 0;
        }
    }
}