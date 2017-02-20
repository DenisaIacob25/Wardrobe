using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wardrobe.Models;

namespace wardrobe.Controllers
{
    public class ClothingDetailsController : Controller
    {
        private wardrobeEntities db = new wardrobeEntities();

        // GET: ClothingDetails
        public ActionResult Index()
        {
            var clothingDetails = db.ClothingDetails.Include(c => c.ClothingType).Include(c => c.Occassion).Include(c => c.Season);
            return View(clothingDetails.ToList());
        }
        //Start of methods to call each view of clothing by type
        // GET: Tops
        public ActionResult Tops()
        {
            var clothingDetails = db.ClothingDetails.Include(c => c.ClothingType).Include(c => c.Occassion).Include(c => c.Season);
            var query = from c in db.ClothingDetails
                        where c.ClothingType.ClothingType1.Contains("Tops")
                        select c;
            return View(query);
        }
        // GET: Bottoms
        public ActionResult Bottoms()
        {
            var clothingDetails = db.ClothingDetails.Include(c => c.ClothingType).Include(c => c.Occassion).Include(c => c.Season);
            var query = from c in db.ClothingDetails
                        where c.ClothingType.ClothingType1.Contains("Bottoms")
                        select c;
            return View(query);
        } // GET: Shoes
        public ActionResult Shoes()
        {
            var clothingDetails = db.ClothingDetails.Include(c => c.ClothingType).Include(c => c.Occassion).Include(c => c.Season);
            var query = from c in db.ClothingDetails
                        where c.ClothingType.ClothingType1.Contains("Shoes")
                        select c;
            return View(query);
        }
        // GET: Accessories
        public ActionResult Accessories()
        {
            var clothingDetails = db.ClothingDetails.Include(c => c.ClothingType).Include(c => c.Occassion).Include(c => c.Season);
            var query = from c in db.ClothingDetails
                        where c.ClothingType.ClothingType1.Contains("Accessories")
                        select c;
            return View(query);
        }
        //end methods of added views for clothing types

        // GET: ClothingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingDetail clothingDetail = db.ClothingDetails.Find(id);
            if (clothingDetail == null)
            {
                return HttpNotFound();
            }
            return View(clothingDetail);
        }

        // GET: ClothingDetails/Create
        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.ClothingTypes, "TypeID", "ClothingType1");
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionsID", "Occassions");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonsID", "Seasons");
            return View();
        }

        // POST: ClothingDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothingID,Title,Color,Photo,OccassionID,SeasonID,TypeID")] ClothingDetail clothingDetail)
        {
            if (ModelState.IsValid)
            {
                db.ClothingDetails.Add(clothingDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.ClothingTypes, "TypeID", "ClothingType1", clothingDetail.TypeID);
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionsID", "Occassions", clothingDetail.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonsID", "Seasons", clothingDetail.SeasonID);
            return View(clothingDetail);
        }

        // GET: ClothingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingDetail clothingDetail = db.ClothingDetails.Find(id);
            if (clothingDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.ClothingTypes, "TypeID", "ClothingType1", clothingDetail.TypeID);
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionsID", "Occassions", clothingDetail.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonsID", "Seasons", clothingDetail.SeasonID);
            return View(clothingDetail);
        }

        // POST: ClothingDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothingID,Title,Color,Photo,OccassionID,SeasonID,TypeID")] ClothingDetail clothingDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothingDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.ClothingTypes, "TypeID", "ClothingType1", clothingDetail.TypeID);
            ViewBag.OccassionID = new SelectList(db.Occassions, "OccassionsID", "Occassions", clothingDetail.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonsID", "Seasons", clothingDetail.SeasonID);
            return View(clothingDetail);
        }

        // GET: ClothingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingDetail clothingDetail = db.ClothingDetails.Find(id);
            if (clothingDetail == null)
            {
                return HttpNotFound();
            }
            return View(clothingDetail);
        }

        // POST: ClothingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClothingDetail clothingDetail = db.ClothingDetails.Find(id);
            db.ClothingDetails.Remove(clothingDetail);
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
