using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArchivoSys.Domain;
using ArchivoSys.Web.Models;

namespace ArchivoSys.Web.Controllers
{
    [Authorize]
    public class ProvincesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        /*
         * Métodos Cantones
         */

        public async Task<ActionResult> CreateCanton(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var province = await db.Provinces.FindAsync(id);

            if (province == null)
            {
                return HttpNotFound();
            }

            var view = new Canton
            {
                ProvinceId = province.ProvinceId,
            };

            
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCanton(Canton canton)
        {
            if (ModelState.IsValid)
            {
                db.Cantons.Add(canton);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", canton.ProvinceId));
            }            
            return View(canton);
        }

        public async Task<ActionResult> EditCanton(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var canton = await db.Cantons.FindAsync(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            
            return View(canton);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCanton(Canton canton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canton).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", canton.ProvinceId));
            }
            
            return View(canton);
        }

        public async Task<ActionResult> DeleteCanton(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var canton = await db.Cantons.FindAsync(id);

            if (canton == null)
            {
                return HttpNotFound();
            }

            db.Cantons.Remove(canton);
            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", canton.ProvinceId));
        }

        /*
         * Métodos Provincias
         */
        public async Task<ActionResult> Index()
        {
            var provinces = db.Provinces.OrderByDescending(p => p.ProvinceId).ToListAsync();
            return View(await provinces);
        }

        // GET: Provinces/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = await db.Provinces.FindAsync(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // GET: Provinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProvinceId,Name")] Province province)
        {
            if (ModelState.IsValid)
            {
                db.Provinces.Add(province);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(province);
        }

        // GET: Provinces/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = await db.Provinces.FindAsync(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProvinceId,Name")] Province province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(province).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(province);
        }

        // GET: Provinces/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Province province = await db.Provinces.FindAsync(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Province province = await db.Provinces.FindAsync(id);
            db.Provinces.Remove(province);
            await db.SaveChangesAsync();
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
