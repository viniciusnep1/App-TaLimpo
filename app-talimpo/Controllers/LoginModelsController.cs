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
    public class LoginModelsController : ApiController
    {
        private app_talimpoContext db = new app_talimpoContext();

        // GET: api/LoginModels
        public IQueryable<LoginModel> GetLogin()
        {
            return db.Login;
        }

        // GET: api/LoginModels/5
        [ResponseType(typeof(LoginModel))]
        public IHttpActionResult GetLoginModel(Guid id)
        {
            LoginModel loginModel = db.Login.Find(id);
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

            db.Login.Add(loginModel);

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
            LoginModel loginModel = db.Login.Find(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            db.Login.Remove(loginModel);
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
            return db.Login.Count(e => e.Id == id) > 0;
        }
    }
}
