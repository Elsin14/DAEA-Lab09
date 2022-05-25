using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Semana09.Models;
namespace Semana09.Controllers
{
    public class ProductController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {

            if (Session["Product"] == null)
            {
                List<Product> product = new List<Product>();
                product.Add(new Product { ProductId = 1, Name = "TV", Description = "LG", Price = 700});
                product.Add(new Product { ProductId = 2, Name = "Lavadora ", Description = "LG", Price = 100 });
                Session["Product"] = product;
            }

            return View(Session["Product"]);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (Session["Product"] == null)
                    Session["Product"] = new List<Product>();
                // TODO: Add insert logic here
                model.ProductId = this.maxInt() + 1;
                ((List<Product>)Session["Product"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ((List<Product>)Session["Product"]).Where(x => x.ProductId == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product model)
        {
            try
            {
                // TODO: Add update logic here
                Product product = ((List<Product>)Session["Product"]).Find(x => x.ProductId == id);
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<Product>)Session["Product"]).Where(x => x.ProductId == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product model)
        {
            try
            {
                // TODO: Add delete logic here
                var toRemove = ((List<Product>)Session["Product"]).Find(x => x.ProductId == id);
                ((List<Product>)Session["Product"]).Remove(toRemove);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private int maxInt() => ((List<Product>)Session["Product"]).Max(x => x.ProductId);

    }
}