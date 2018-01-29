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
using app_talimpo.Models;

namespace app_talimpo.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class GerentesController : ApiController
  {
        private app_talimpoContext db = new app_talimpoContext();

        // GET: api/Gerentes
        public IQueryable<Gerente> GetGerentes()
        {
            return db.Gerentes;
        }

        // GET: api/Gerentes/5
        [ResponseType(typeof(Gerente))]
        public IHttpActionResult GetGerente(Guid id)
        {
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return NotFound();
            }

            return Ok(gerente);
        }

        // PUT: api/Gerentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGerente(Guid id, Gerente gerente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gerente.Id)
            {
                return BadRequest();
            }

            db.Entry(gerente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerenteExists(id))
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

        // POST: api/Gerentes
        [ResponseType(typeof(Gerente))]
        public IHttpActionResult PostGerente(Gerente gerente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gerentes.Add(gerente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GerenteExists(gerente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gerente.Id }, gerente);
        }

        // DELETE: api/Gerentes/5
        [ResponseType(typeof(Gerente))]
        public IHttpActionResult DeleteGerente(Guid id)
        {
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return NotFound();
            }

            db.Gerentes.Remove(gerente);
            db.SaveChanges();

            return Ok(gerente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GerenteExists(Guid id)
        {
            return db.Gerentes.Count(e => e.Id == id) > 0;
        }
    }
}
