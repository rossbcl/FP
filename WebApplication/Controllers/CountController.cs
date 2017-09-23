using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CountController : Controller
    {
        // GET: Count
        [HttpGet]
        public ActionResult Index()
        {
            var model = new Models.CountModel() { CountValue = 0 };

            using (var db = new FPContext())
            {
                db.Database.CreateIfNotExists();

                model = db.Counts.Select(x => new Models.CountModel
                { 
                     CountValue = x.CountValue
                }).FirstOrDefault();
            }

            return View(model);
        }

        // POST: Count
        [HttpPost]
        public ActionResult Index(int? CountValue)
        {
            var model = new Models.CountModel() { CountValue = CountValue.Value };

            using (var db = new FPContext())
            {
                var firstRecord = db.Counts.FirstOrDefault();
                if (firstRecord != null)
                {
                    firstRecord.CountValue = CountValue.Value;
                }
                else
                {
                    firstRecord = db.Counts.Add(new Count { CountValue = CountValue.Value });
                }

                db.SaveChanges();
            }

            return View(model);
        }
    }
}