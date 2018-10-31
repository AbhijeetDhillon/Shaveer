using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Shaveer.Models;


namespace Shaveer.Controllers
{
    public class CoachShavController : Controller
    {
        //
        // GET: /CoachShav/
        ShaveerEntities db = new ShaveerEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Transformation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TransformationCreate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TransformationCreate(HttpPostedFileBase file, FormCollection frm)

        { 
        
            if (file != null )
                try
                {
                    Transformation obj = new Transformation();
                    
                    obj.ImageName=file.FileName;
                    String path = Path.Combine(Server.MapPath("~/Transformation"),
                                               Path.GetFileName(file.FileName));
                    
                    file.SaveAs(path);
                    obj.ImagePath = path;
                    obj.Name = frm["Name"];
                    obj.Message = frm["Message"];
                    
                    db.Transformations.Add(obj);
                    db.SaveChanges();
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        
        }

        [HttpGet]
        public ActionResult TransformationDelete(Transformation model)
        {
            var model1 = new Transformation();
            // ...
            return View(db.Transformations.ToList());
        }
    
        [HttpPost]
        public ActionResult TransformationDelete(string photoFileName, FormCollection frm)
        {
            Transformation tbl = new Transformation();
         ViewBag.deleteSuccess = "false";
            tbl.Name = frm["Name"];
            tbl.Message = frm["Message"];
            var photoName = ""; 
             photoName = photoFileName;
             tbl.ImageName = photoName;
             var fullPath = Server.MapPath("~/Transformation/" + photoName);
             tbl.ImagePath = fullPath; 
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                db.Transformations.Remove(tbl);
                db.SaveChanges();
                ViewBag.deleteSuccess = "true";
            }
            return RedirectToAction("TransformationDelete");
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Nutrition()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NutritionCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NutritionCreate(FormCollection frm)
        {
            Nutrition tbl = new Nutrition();
            tbl.Ingredients = frm["Ingredients"];
            tbl.NutrionalContent = frm["Nutritional Content"];
            tbl.NVideoLink = frm["VideoLink"];
            tbl.Title = frm["Title"];
            db.Nutritions.Add(tbl);
            db.SaveChanges();
            
            return View("Nutrition");
        }
        [HttpGet]
        public ActionResult NutritionDelete()
        {
          

            return View(db.Nutritions.ToList());
            
        }
        [HttpPost]
        public ActionResult NutritionDelete(FormCollection frm)
        {
           
             string Title =  frm ["Title"];
           using(ShaveerEntities db = new ShaveerEntities()){
             var dbz = db.Nutritions.Where(u => u.Title.Equals(Title)).FirstOrDefault();
             db.Nutritions.Remove(dbz);
             db.SaveChanges();
            return RedirectToAction("Nutrition");
        }
        }      
        public ActionResult Training()
        {

            return View();
        }

        [HttpGet]
        public ActionResult TrainingCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TrainingCreate(FormCollection frm)
        {
            Training tbl = new Training();
            tbl.Title = frm["Title"];
            tbl.Duration = frm["Duration"];
            tbl.Description = frm["Description"];
            tbl.TVideoLink = frm["VideoLink"];
            db.Trainings.Add(tbl);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult TrainingDelete()
        {
            return View(db.Trainings.ToList());
        }
        [HttpPost]
        public ActionResult TrainingDelete(FormCollection frm)
        {
            string Title = frm["Title"];
            using (ShaveerEntities db = new ShaveerEntities())
            {
                var dbz = db.Trainings.Where(u => u.Title.Equals(Title)).FirstOrDefault();
                db.Trainings.Remove(dbz);
                db.SaveChanges();
                return RedirectToAction("Training");
            }
            
        }

        public ActionResult Wellness()
        {

            return View();
        }

        [HttpGet]
        public ActionResult WellnessCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WellnessCreate(FormCollection frm)
        {
            Wellness tbl = new Wellness();
            tbl.Title = frm["Title"];
            tbl.Duration = frm["Duration"];
            tbl.Description = frm["Description"];
            tbl.WVideoLink = frm["VideoLink"];
            db.Wellnesses.Add(tbl);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult WellnessDelete()
        {
            return View(db.Wellnesses.ToList());
        }
        [HttpPost]
        public ActionResult WellnessDelete(FormCollection frm)
        {
            string Title = frm["Title"];
            using (ShaveerEntities db = new ShaveerEntities())
            {
                var dbz = db.Wellnesses.Where(u => u.Title.Equals(Title)).FirstOrDefault();
                db.Wellnesses.Remove(dbz);
                db.SaveChanges();
                return RedirectToAction("Wellness");
            }

        }
 

        }


    }


 