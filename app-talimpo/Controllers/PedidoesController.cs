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
  public class PedidoesController : ApiController
    {
        private app_talimpoContext db = new app_talimpoContext();

        // GET: api/Pedidoes
        public IQueryable<Pedido> GetPedidos()
        {
            return db.Pedidos;
        }

        // GET: api/Pedidoes/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(Guid id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // PUT: api/Pedidoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido(Guid id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.Id)
            {
                return BadRequest();
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidoes
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(pedido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PedidoExists(pedido.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidoes/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult DeletePedido(Guid id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedido);
            db.SaveChanges();

            return Ok(pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoExists(Guid id)
        {
            return db.Pedidos.Count(e => e.Id == id) > 0;
        }
    }
}
