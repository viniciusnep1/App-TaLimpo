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
  public class VendedorsController : ApiController
    {
        private TaLimpoAppContext db = new TaLimpoAppContext();

        // GET: api/Vendedors
        public IQueryable<Vendedor> GetVendedores()
        {
            return db.Vendedores;
        }

        // GET: api/Vendedors/5
        [ResponseType(typeof(Vendedor))]
        public IHttpActionResult GetVendedor(Guid id)
        {
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return Ok(vendedor);
        }

        // PUT: api/Vendedors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendedor(Guid id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            db.Entry(vendedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
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

        // POST: api/Vendedors
        [ResponseType(typeof(Vendedor))]
        public IHttpActionResult PostVendedor(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendedores.Add(vendedor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VendedorExists(vendedor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vendedor.Id }, vendedor);
        }

        // DELETE: api/Vendedors/5
        [ResponseType(typeof(Vendedor))]
        public IHttpActionResult DeleteVendedor(Guid id)
        {
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            db.Vendedores.Remove(vendedor);
            db.SaveChanges();

            return Ok(vendedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendedorExists(Guid id)
        {
            return db.Vendedores.Count(e => e.Id == id) > 0;
        }
    }
}
