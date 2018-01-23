using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TaLimpoApp.Models;

namespace TaLimpoApp.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class MateriaPrimasController : ApiController
    {
        private TaLimpoAppContext db = new TaLimpoAppContext();

        // GET: api/MateriaPrimas
        public IQueryable<MateriaPrima> GetMateriaPrimas()
        {
            return db.MateriaPrimas;
        }

        // GET: api/MateriaPrimas/5
        [ResponseType(typeof(MateriaPrima))]
        public IHttpActionResult GetMateriaPrima(Guid id)
        {
            MateriaPrima materiaPrima = db.MateriaPrimas.Find(id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return Ok(materiaPrima);
        }

        // PUT: api/MateriaPrimas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMateriaPrima(Guid id, MateriaPrima materiaPrima)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materiaPrima.Id)
            {
                return BadRequest();
            }

            db.Entry(materiaPrima).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaPrimaExists(id))
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

        // POST: api/MateriaPrimas
        [ResponseType(typeof(MateriaPrima))]
        public IHttpActionResult PostMateriaPrima(MateriaPrima materiaPrima)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MateriaPrimas.Add(materiaPrima);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MateriaPrimaExists(materiaPrima.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = materiaPrima.Id }, materiaPrima);
        }

        // DELETE: api/MateriaPrimas/5
        [ResponseType(typeof(MateriaPrima))]
        public IHttpActionResult DeleteMateriaPrima(Guid id)
        {
            MateriaPrima materiaPrima = db.MateriaPrimas.Find(id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            db.MateriaPrimas.Remove(materiaPrima);
            db.SaveChanges();

            return Ok(materiaPrima);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MateriaPrimaExists(Guid id)
        {
            return db.MateriaPrimas.Count(e => e.Id == id) > 0;
        }
    }
}
