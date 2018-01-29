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
  public class ProdutoesController : ApiController
  {
    private app_talimpoContext db = new app_talimpoContext();

    // GET: api/Produtoes
    public IQueryable<Produto> GetProdutos()
    {
      var result = db.Produtos;
      return db.Produtos;
    }

    // GET: api/Produtoes/5
    [ResponseType(typeof(Produto))]
    public IHttpActionResult GetProduto(Guid id)
    {
      Produto produto = db.Produtos.Find(id);
      if (produto == null)
      {
        return NotFound();
      }

      return Ok(produto);
    }

    // PUT: api/Produtoes/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutProduto(Guid id, Produto produto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != produto.Id)
      {
        return BadRequest();
      }

      db.Entry(produto).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProdutoExists(id))
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

    // POST: api/Produtoes
    [ResponseType(typeof(Produto))]
    public IHttpActionResult PostProduto(Produto produto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Produtos.Add(produto);

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (ProdutoExists(produto.Id))
        {
          return Conflict();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
    }

    // DELETE: api/Produtoes/5
    [ResponseType(typeof(Produto))]
    public IHttpActionResult DeleteProduto(Guid id)
    {
      Produto produto = db.Produtos.Find(id);
      if (produto == null)
      {
        return NotFound();
      }

      db.Produtos.Remove(produto);
      db.SaveChanges();

      return Ok(produto);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ProdutoExists(Guid id)
    {
      return db.Produtos.Count(e => e.Id == id) > 0;
    }
  }
}
