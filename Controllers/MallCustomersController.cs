using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APIconMVC.Models;

namespace APIconMVC.Controllers
{
    public class MallCustomersController : Controller
    {
        private TallerAndroidContainer db = new TallerAndroidContainer();

        // GET: MallCustomers
        public ActionResult Index()
        {
            return View(db.MallCustomers.ToList());
        }

        // GET: MallCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MallCustomer mallCustomer = db.MallCustomers.Find(id);
            if (mallCustomer == null)
            {
                return HttpNotFound();
            }
            return View(mallCustomer);
        }

        // GET: MallCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MallCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Gender,Age,AnnualIncome,SpendingScore")] MallCustomer mallCustomer)
        {
            if (ModelState.IsValid)
            {
                db.MallCustomers.Add(mallCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mallCustomer);
        }

        // GET: MallCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MallCustomer mallCustomer = db.MallCustomers.Find(id);
            if (mallCustomer == null)
            {
                return HttpNotFound();
            }
            return View(mallCustomer);
        }

        // POST: MallCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gender,Age,AnnualIncome,SpendingScore")] MallCustomer mallCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mallCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mallCustomer);
        }

        // GET: MallCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MallCustomer mallCustomer = db.MallCustomers.Find(id);
            if (mallCustomer == null)
            {
                return HttpNotFound();
            }
            return View(mallCustomer);
        }

        // POST: MallCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MallCustomer mallCustomer = db.MallCustomers.Find(id);
            db.MallCustomers.Remove(mallCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
