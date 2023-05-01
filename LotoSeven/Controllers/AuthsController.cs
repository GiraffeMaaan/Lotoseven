using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LotoSeven.Data;
using LotoSeven.Models;

namespace LotoSeven.Controllers
{
    public class AuthsController : Controller
    {
        private LotoSevenContext db = new LotoSevenContext();

        // GET: Auths
        public ActionResult Index()
        {
            return View(db.Auths.ToList());
        }

        // GET: Auths/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // GET: Auths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auths/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Password")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                db.Auths.Add(auth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auth);
        }

        // GET: Auths/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // POST: Auths/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auth);
        }

        // GET: Auths/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auth auth = db.Auths.Find(id);
            if (auth == null)
            {
                return HttpNotFound();
            }
            return View(auth);
        }

        // POST: Auths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Auth auth = db.Auths.Find(id);
            db.Auths.Remove(auth);
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
