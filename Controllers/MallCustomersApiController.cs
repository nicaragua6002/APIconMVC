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
    public class MallCustomersApiController : ApiController
    {
        private TallerAndroidContainer db = new TallerAndroidContainer();

        // GET: api/MallCustomersApi
        public IQueryable<MallCustomer> GetMallCustomers()
        {
            return db.MallCustomers;
        }

        // GET: api/MallCustomersApi/5
        [ResponseType(typeof(MallCustomer))]
        public IHttpActionResult GetMallCustomer(int id)
        {
            MallCustomer mallCustomer = db.MallCustomers.Find(id);
            if (mallCustomer == null)
            {
                return NotFound();
            }

            return Ok(mallCustomer);
        }
        // GET: api/MallCustomersApi/genero
        [Route("api/MallCustomersApi/genero/{genero}")]
        [HttpGet]
        public IHttpActionResult GetGenderCustomers(string genero)
        {
            var maleCustomers = db.MallCustomers.Where(c => c.Gender == genero).ToList();
            return Ok(maleCustomers);
        }

        // GET: api/MallCustomersApi/Gastones
        [Route("api/MallCustomersApi/Gastones")]
        [HttpGet]
        public IHttpActionResult GetGastonesCustomers()
        {
            var gastonesCustomers = db.MallCustomers.Where(c => c.AnnualIncome < c.SpendingScore).ToList();
            return Ok(gastonesCustomers);
        }

        // GET: api/mallCustomersApi/RangoEdad?min=valor&max=valor
        [Route("api/MallCustomersApi/RangoEdad")]
        [HttpGet]
        public IHttpActionResult GetRangoEdadCustomers(int min, int max)
        {
            var gastonesCustomers = db.MallCustomers.Where(c => c.Age>= min && c.Age<=max).ToList();
            return Ok(gastonesCustomers);
        }
        // GET: api/MallCustomersApi/Stats
        [Route("api/MallCustomersApi/Stats")]
        [HttpGet]
        public IHttpActionResult GetCustomerStats()
        {
            var customers = db.MallCustomers.ToList();

            if (customers == null || customers.Count == 0)
            {
                return NotFound();
            }

            double count = customers.Count;
            double sumAge = customers.Sum(c => c.Age);
            double sumIncome = customers.Sum(c => c.AnnualIncome);
            double sumSpendingScore = customers.Sum(c => c.SpendingScore);
            double meanAge = sumAge / count;
            double meanIncome = sumIncome / count;
            double meanSpendingScore = sumSpendingScore / count;
            double stdAge = Math.Sqrt(customers.Sum(c => Math.Pow(c.Age - meanAge, 2)) / count);
            double stdIncome = Math.Sqrt(customers.Sum(c => Math.Pow(c.AnnualIncome - meanIncome, 2)) / count);
            double stdSpendingScore = Math.Sqrt(customers.Sum(c => Math.Pow(c.SpendingScore - meanSpendingScore, 2)) / count);
            double minAge = customers.Min(c => c.Age);
            double minIncome = customers.Min(c => c.AnnualIncome);
            double minSpendingScore = customers.Min(c => c.SpendingScore);
            double q1Age = customers.OrderBy(c => c.Age).Skip((int)(0.25 * count)).First().Age;
            double q1Income = customers.OrderBy(c => c.AnnualIncome).Skip((int)(0.25 * count)).First().AnnualIncome;
            double q1SpendingScore = customers.OrderBy(c => c.SpendingScore).Skip((int)(0.25 * count)).First().SpendingScore;
            double medianAge = customers.OrderBy(c => c.Age).Skip((int)(0.5 * count)).First().Age;
            double medianIncome = customers.OrderBy(c => c.AnnualIncome).Skip((int)(0.5 * count)).First().AnnualIncome;
            double medianSpendingScore = customers.OrderBy(c => c.SpendingScore).Skip((int)(0.5 * count)).First().SpendingScore;
            double q3Age = customers.OrderBy(c => c.Age).Skip((int)(0.75 * count)).First().Age;
            double q3Income = customers.OrderBy(c => c.AnnualIncome).Skip((int)(0.75 * count)).First().AnnualIncome;
            double q3SpendingScore = customers.OrderBy(c => c.SpendingScore).Skip((int)(0.75 * count)).First().SpendingScore;
            double maxAge = customers.Max(c => c.Age);
            double maxIncome = customers.Max(c => c.AnnualIncome);
            double maxSpendingScore = customers.Max(c => c.SpendingScore);

            var stats = new
            {
                CustomerID = new { count },
                Age = new { mean = meanAge, std = stdAge, min = minAge, q1 = q1Age, median = medianAge, q3 = q3Age, max = maxAge },
                AnnualIncome = new { mean = meanIncome, std = stdIncome, min = minIncome, q1 = q1Income, median = medianIncome, q3 = q3Income, max = maxIncome },
                SpendingScore = new { mean = meanSpendingScore, std = stdSpendingScore, min = minSpendingScore, q1 = q1SpendingScore, median = medianSpendingScore, q3 = q3SpendingScore, max = maxSpendingScore }
            };

            return Ok(stats);
        }

        /*
        // PUT: api/MallCustomersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMallCustomer(int id, MallCustomer mallCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mallCustomer.Id)
            {
                return BadRequest();
            }

            db.Entry(mallCustomer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MallCustomerExists(id))
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

        // POST: api/MallCustomersApi
        [ResponseType(typeof(MallCustomer))]
        public IHttpActionResult PostMallCustomer(MallCustomer mallCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MallCustomers.Add(mallCustomer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mallCustomer.Id }, mallCustomer);
        }

        // DELETE: api/MallCustomersApi/5
        [ResponseType(typeof(MallCustomer))]
        public IHttpActionResult DeleteMallCustomer(int id)
        {
            MallCustomer mallCustomer = db.MallCustomers.Find(id);
            if (mallCustomer == null)
            {
                return NotFound();
            }

            db.MallCustomers.Remove(mallCustomer);
            db.SaveChanges();

            return Ok(mallCustomer);
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MallCustomerExists(int id)
        {
            return db.MallCustomers.Count(e => e.Id == id) > 0;
        }
    }
}