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
    public class LopHocPhansController : Controller
    {
        private QLLapLichDataContext db = new QLLapLichDataContext();

        // GET: LopHocPhans
        public ActionResult Index()
        {
            var lopHocPhans = db.LopHocPhans.Include(l => l.GiangVien).Include(l => l.LopDanhNghia).Include(l => l.MonHoc);
            return View(lopHocPhans.ToList());
        }

        // GET: LopHocPhans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHocPhan lopHocPhan = db.LopHocPhans.Find(id);
            if (lopHocPhan == null)
            {
                return HttpNotFound();
            }
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Create
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.GiangViens, "MaGV", "TenGV");
            ViewBag.MaLDN = new SelectList(db.LopDanhNghias, "MaLDN", "TenLDN");
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH");
            return View();
        }

        // POST: LopHocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLHP,MaMH,MaLDN,SiSo,MaGV")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                db.LopHocPhans.Add(lopHocPhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(db.GiangViens, "MaGV", "TenGV", lopHocPhan.MaGV);
            ViewBag.MaLDN = new SelectList(db.LopDanhNghias, "MaLDN", "TenLDN", lopHocPhan.MaLDN);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", lopHocPhan.MaMH);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHocPhan lopHocPhan = db.LopHocPhans.Find(id);
            if (lopHocPhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(db.GiangViens, "MaGV", "TenGV", lopHocPhan.MaGV);
            ViewBag.MaLDN = new SelectList(db.LopDanhNghias, "MaLDN", "TenLDN", lopHocPhan.MaLDN);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", lopHocPhan.MaMH);
            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLHP,MaMH,MaLDN,SiSo,MaGV")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopHocPhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.GiangViens, "MaGV", "TenGV", lopHocPhan.MaGV);
            ViewBag.MaLDN = new SelectList(db.LopDanhNghias, "MaLDN", "TenLDN", lopHocPhan.MaLDN);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", lopHocPhan.MaMH);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHocPhan lopHocPhan = db.LopHocPhans.Find(id);
            if (lopHocPhan == null)
            {
                return HttpNotFound();
            }
            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LopHocPhan lopHocPhan = db.LopHocPhans.Find(id);
            db.LopHocPhans.Remove(lopHocPhan);
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
