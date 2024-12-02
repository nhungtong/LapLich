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
    public class PhongHocsController : Controller
    {
        private QLLapLichDataContext db = new QLLapLichDataContext();

        // GET: PhongHocs
        public ActionResult Index()
        {
            return View(db.PhongHocs.ToList());
        }

        // GET: PhongHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongHoc phongHoc = db.PhongHocs.Find(id);
            if (phongHoc == null)
            {
                return HttpNotFound();
            }
            return View(phongHoc);
        }

        // GET: PhongHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhongHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhong,TenPhong,DayNha")] PhongHoc phongHoc)
        {
            if (ModelState.IsValid)
            {
                db.PhongHocs.Add(phongHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongHoc);
        }

        // GET: PhongHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongHoc phongHoc = db.PhongHocs.Find(id);
            if (phongHoc == null)
            {
                return HttpNotFound();
            }
            return View(phongHoc);
        }

        // POST: PhongHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhong,TenPhong,DayNha")] PhongHoc phongHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongHoc);
        }

        // GET: PhongHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongHoc phongHoc = db.PhongHocs.Find(id);
            if (phongHoc == null)
            {
                return HttpNotFound();
            }
            return View(phongHoc);
        }

        // POST: PhongHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongHoc phongHoc = db.PhongHocs.Find(id);
            db.PhongHocs.Remove(phongHoc);
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
