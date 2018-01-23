using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MvcApplication6.Controllers;
using TaLimpoApp.Models;
using System.Web.Http.Cors;

namespace TaLimpoApp.Controllers
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class LoginModelsController : ApiController
    {
        private TaLimpoAppContext db = new TaLimpoAppContext();

        // GET: api/LoginModels
        public IQueryable<LoginModel> GetLoginModels()
        {
            return db.LoginModels;
        }

        // GET: api/LoginModels/5
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult GetLoginModel(Guid id)
        {
            LoginModel loginModel = db.LoginModels.Find(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            return Ok(loginModel);
        }

        // PUT: api/LoginModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoginModel(Guid id, LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginModel.Id)
            {
                return BadRequest();
            }

            db.Entry(loginModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
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

        // POST: api/LoginModels
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult PostLoginModel(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoginModels.Add(loginModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoginModelExists(loginModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = loginModel.Id }, loginModel);
        }

        // DELETE: api/LoginModels/5
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult DeleteLoginModel(Guid id)
        {
            LoginModel loginModel = db.LoginModels.Find(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            db.LoginModels.Remove(loginModel);
            db.SaveChanges();

            return Ok(loginModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginModelExists(Guid id)
        {
            return db.LoginModels.Count(e => e.Id == id) > 0;
        }
    }
}
