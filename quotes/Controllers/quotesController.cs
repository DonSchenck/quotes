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
using quotes;

namespace quotes.Controllers
{
    public class quotesController : ApiController
    {
        private QuotesContainer db = new QuotesContainer();

        // GET: api/quotes
        public IQueryable<quote> Getquotes()
        {
            return db.quotes;
        }

        // GET: api/quotes/5
        [ResponseType(typeof(quote))]
        public async Task<IHttpActionResult> Getquote(int id)
        {
            quote quote = await db.quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // PUT: api/quotes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putquote(int id, quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.Id)
            {
                return BadRequest();
            }

            db.Entry(quote).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!quoteExists(id))
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

        // POST: api/quotes
        [ResponseType(typeof(quote))]
        public async Task<IHttpActionResult> Postquote(quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.quotes.Add(quote);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quote.Id }, quote);
        }

        // DELETE: api/quotes/5
        [ResponseType(typeof(quote))]
        public async Task<IHttpActionResult> Deletequote(int id)
        {
            quote quote = await db.quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            db.quotes.Remove(quote);
            await db.SaveChangesAsync();

            return Ok(quote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool quoteExists(int id)
        {
            return db.quotes.Count(e => e.Id == id) > 0;
        }
    }
}