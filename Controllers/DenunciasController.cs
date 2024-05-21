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
using APIconMVC.Models;

namespace APIconMVC.Controllers
{
    public class DenunciasController : ApiController
    {
        private TallerAndroidContainer db = new TallerAndroidContainer();

        // GET: api/Denuncias
        public IQueryable<Denuncia> GetDenuncias()
        {
            return db.Denuncias;
        }

        // GET: api/Denuncias/5
        [ResponseType(typeof(Denuncia))]
        public IHttpActionResult GetDenuncia(int id)
        {
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return Ok(denuncia);
        }
        // GET: api/Denuncias/Departamentos
        [Route("api/Denuncias/Departamentos")]
        [HttpGet]
        public IHttpActionResult GetDepartamentos()
        {
            var Departamento = db.Denuncias.Select(d => d.Departamento).Distinct().ToList();

            if (Departamento == null || Departamento.Count == 0)
            {
                return NotFound();
            }

            return Ok(Departamento);
        }

        // GET: api/Denuncias/Departamentos/Departamento
        [Route("api/Denuncias/Departamentos/{departamento}")]
        [HttpGet]
        public IHttpActionResult GetDenunciasByDepartment(string departamento)
        {
            if (string.IsNullOrEmpty(departamento))
            {
                return BadRequest("El nombre del departamento no puede estar vacío.");
            }

            var denuncias = db.Denuncias.Where(d => d.Departamento.Equals(departamento, StringComparison.OrdinalIgnoreCase)).ToList();

            if (denuncias == null || denuncias.Count == 0)
            {
                return NotFound();
            }

            return Ok(denuncias);
        }

        // GET: api/Denuncias/Tipologias/Tipologia
        [Route("api/Denuncias/Tipologias/{Tipologia}")]
        [HttpGet]
        public IHttpActionResult GetDenunciasTipologia(string tipologia)
        {
            if (string.IsNullOrEmpty(tipologia))
            {
                return BadRequest("El nombre del Tipologia no puede estar vacío.");
            }

            var denuncias = db.Denuncias.Where(d => d.Tipologia.Equals(tipologia, StringComparison.OrdinalIgnoreCase)).ToList();

            if (denuncias == null || denuncias.Count == 0)
            {
                return NotFound();
            }

            return Ok(denuncias);
        }

        // GET: api/Denuncias/Tipologias
        [Route("api/Denuncias/Tipologias")]
        [HttpGet]
        public IHttpActionResult GetTiposDeDenuncias()
        {
            var tipologiaDeDenuncias = db.Denuncias.Select(d => d.Tipologia).Distinct().ToList();

            if (tipologiaDeDenuncias == null || tipologiaDeDenuncias.Count == 0)
            {
                return NotFound();
            }

            return Ok(tipologiaDeDenuncias);
        }


        // PUT: api/Denuncias/5
        /*  [ResponseType(typeof(void))]
          public IHttpActionResult PutDenuncia(int id, Denuncia denuncia)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              if (id != denuncia.Id)
              {
                  return BadRequest();
              }

              db.Entry(denuncia).State = EntityState.Modified;

              try
              {
                  db.SaveChanges();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!DenunciaExists(id))
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

          // POST: api/Denuncias
          [ResponseType(typeof(Denuncia))]
          public IHttpActionResult PostDenuncia(Denuncia denuncia)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(ModelState);
              }

              db.Denuncias.Add(denuncia);
              db.SaveChanges();

              return CreatedAtRoute("DefaultApi", new { id = denuncia.Id }, denuncia);
          }

          // DELETE: api/Denuncias/5
          [ResponseType(typeof(Denuncia))]
          public IHttpActionResult DeleteDenuncia(int id)
          {
              Denuncia denuncia = db.Denuncias.Find(id);
              if (denuncia == null)
              {
                  return NotFound();
              }

              db.Denuncias.Remove(denuncia);
              db.SaveChanges();

              return Ok(denuncia);
          }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DenunciaExists(int id)
        {
            return db.Denuncias.Count(e => e.Id == id) > 0;
        }
    }
}