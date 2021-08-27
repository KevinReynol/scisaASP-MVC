using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scisaASP_MVC.Models;

namespace scisaASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<categoria> listaCategoria = new List<categoria>();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                listaCategoria = scisamodel.categoria.ToList<categoria>();
            }
            return View(listaCategoria);
        }

        public ActionResult Details(int id)
        {
            categoria categoriaModelos = new categoria();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                categoriaModelos = scisamodel.categoria.Where(x => x.idCategoria == id).FirstOrDefault();
            }
            return View(categoriaModelos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View(new categoria());
        }

        [HttpPost]
        public ActionResult Create(categoria categoriaModelos)
        {
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                scisamodel.categoria.Add(categoriaModelos);
                scisamodel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            categoria categoriaModelos = new categoria();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                categoriaModelos = scisamodel.categoria.Where(x => x.idCategoria == id).FirstOrDefault();
            }
            return View(categoriaModelos);
        }

        [HttpPost]
        public ActionResult Edit(categoria categoriaModelos)
        {
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                scisamodel.Entry(categoriaModelos).State = System.Data.EntityState.Modified;
                scisamodel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {       
            categoria categoriaModelos = new categoria();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                categoriaModelos = scisamodel.categoria.Where(x => x.idCategoria == id).FirstOrDefault();
            }
            return View(categoriaModelos);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {     
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                categoria categoriaModelos = scisamodel.categoria.Where(x => x.idCategoria == id).FirstOrDefault();
                scisamodel.categoria.Remove(categoriaModelos);
                scisamodel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}