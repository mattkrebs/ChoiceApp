using ChoiceApp.WebApi.Models;
using ChoiceApp.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoiceApp.WebApi.Controllers
{
    public class HomeController : Controller
    {

        private ChoiceContext db = new ChoiceContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var choices = db.Choices.ToList();
            return View(choices);
        }

        public ActionResult CreateChoice()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveChoice(ChoiceViewModel choice)
        {
            ////check if url exists
            //if (!db.Options.Any(x => x.ImageUrl == choice.Option1.ImageUrl))
            //{
            //    db.Options.Add(choice.Option1);
            //    db.SaveChanges();
            //}
            //if (!db.Options.Any(x => x.ImageUrl == choice.Option2.ImageUrl))
            //{
            //    db.Options.Add(choice.Option2);
            //    db.SaveChanges();
            //}


            Choice c = new Choice();
            c.CreatedDate = DateTime.Now;
            c.Name = choice.Name;
            c.Tags = choice.Tags;
            c.Option1 = choice.Option1;
            c.Option2 = choice.Option2;
            c.ChoiceId = Guid.NewGuid();
            db.Choices.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
           
        }
    }
}
