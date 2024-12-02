﻿using System;
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
    public class LichHocsController : Controller
    {
        private QLLapLichDataContext db = new QLLapLichDataContext();

        // GET: LichHocs
        public ActionResult Index()
        {
            var lichHocs = db.LichHocs.Include(l => l.LopHocPhan).Include(l => l.PhongHoc);
            return View(lichHocs.ToList());
        }

        // GET: LichHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHoc lichHoc = db.LichHocs.Find(id);
            if (lichHoc == null)
            {
                return HttpNotFound();
            }
            return View(lichHoc);
        }

        // GET: LichHocs/Create
        public ActionResult Create()
        {
            ViewBag.MaLHP = new SelectList(db.LopHocPhans, "MaLHP", "MaLHP");
            ViewBag.MaPhong = new SelectList(db.PhongHocs, "MaPhong", "TenPhong");
            return View();
        }

        // POST: LichHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,MaLHP,MaPhong,NgayHoc,TietBatDau,TietKetthuc,GioTanHoc")] LichHoc lichHoc)
        {
            if (ModelState.IsValid)
            {
                db.LichHocs.Add(lichHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLHP = new SelectList(db.LopHocPhans, "MaLHP", "MaLHP", lichHoc.MaLHP);
            ViewBag.MaPhong = new SelectList(db.PhongHocs, "MaPhong", "TenPhong", lichHoc.MaPhong);
            return View(lichHoc);
        }

        // GET: LichHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHoc lichHoc = db.LichHocs.Find(id);
            if (lichHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLHP = new SelectList(db.LopHocPhans, "MaLHP", "MaLHP", lichHoc.MaLHP);
            ViewBag.MaPhong = new SelectList(db.PhongHocs, "MaPhong", "TenPhong", lichHoc.MaPhong);
            return View(lichHoc);
        }

        // POST: LichHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,MaLHP,MaPhong,NgayHoc,TietBatDau,TietKetthuc,GioTanHoc")] LichHoc lichHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLHP = new SelectList(db.LopHocPhans, "MaLHP", "MaLHP", lichHoc.MaLHP);
            ViewBag.MaPhong = new SelectList(db.PhongHocs, "MaPhong", "TenPhong", lichHoc.MaPhong);
            return View(lichHoc);
        }

        // GET: LichHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHoc lichHoc = db.LichHocs.Find(id);
            if (lichHoc == null)
            {
                return HttpNotFound();
            }
            return View(lichHoc);
        }

        // POST: LichHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichHoc lichHoc = db.LichHocs.Find(id);
            db.LichHocs.Remove(lichHoc);
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
