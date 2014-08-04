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
    public class ChoicesController : ApiController
    {
        private ChoiceContext db = new ChoiceContext();

        // GET: api/ChoicesApi
        public IQueryable<Choice> GetChoices()
        {
            return db.Choices;
        }

        // GET: api/ChoicesApi/5
        [ResponseType(typeof(Choice))]
        public async Task<IHttpActionResult> GetChoice(Guid id)
        {
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return NotFound();
            }

            return Ok(choice);
        }

        // PUT: api/ChoicesApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChoice(Guid id, Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != choice.ChoiceId)
            {
                return BadRequest();
            }

            db.Entry(choice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoiceExists(id))
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

        // POST: api/ChoicesApi
        [ResponseType(typeof(Choice))]
        public async Task<IHttpActionResult> PostChoice(Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Choices.Add(choice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = choice.ChoiceId }, choice);
        }

        // DELETE: api/ChoicesApi/5
        [ResponseType(typeof(Choice))]
        public async Task<IHttpActionResult> DeleteChoice(Guid id)
        {
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return NotFound();
            }

            db.Choices.Remove(choice);
            await db.SaveChangesAsync();

            return Ok(choice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChoiceExists(Guid id)
        {
            return db.Choices.Count(e => e.ChoiceId == id) > 0;
        }
    }
}