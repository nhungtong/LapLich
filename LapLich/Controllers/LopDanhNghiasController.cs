using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LapLich.Models;

namespace LapLich.Controllers
{
    public class LopDanhNghiasController : Controller
    {
        private QLLapLichDataContext db = new QLLapLichDataContext();

        // GET: LopDanhNghias
        public ActionResult Index()
        {
            return View(db.LopDanhNghias.ToList());
        }

        // GET: LopDanhNghias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopDanhNghia lopDanhNghia = db.LopDanhNghias.Find(id);
            if (lopDanhNghia == null)
            {
                return HttpNotFound();
            }
            return View(lopDanhNghia);
        }

        // GET: LopDanhNghias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LopDanhNghias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLDN,TenLDN")] LopDanhNghia lopDanhNghia)
        {
            if (ModelState.IsValid)
            {
                db.LopDanhNghias.Add(lopDanhNghia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lopDanhNghia);
        }

        // GET: LopDanhNghias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopDanhNghia lopDanhNghia = db.LopDanhNghias.Find(id);
            if (lopDanhNghia == null)
            {
                return HttpNotFound();
            }
            return View(lopDanhNghia);
        }

        // POST: LopDanhNghias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLDN,TenLDN")] LopDanhNghia lopDanhNghia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopDanhNghia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lopDanhNghia);
        }

        // GET: LopDanhNghias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopDanhNghia lopDanhNghia = db.LopDanhNghias.Find(id);
            if (lopDanhNghia == null)
            {
                return HttpNotFound();
            }
            return View(lopDanhNghia);
        }

        // POST: LopDanhNghias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LopDanhNghia lopDanhNghia = db.LopDanhNghias.Find(id);
            db.LopDanhNghias.Remove(lopDanhNghia);
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
