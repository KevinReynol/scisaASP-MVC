using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scisaASP_MVC.Models;
namespace scisaASP_MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            List<productos> listaProductos = new List<productos>();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                listaProductos = scisamodel.productos.ToList<productos>();
            }
            return View(listaProductos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            productos productosModelos = new productos();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                productosModelos = scisamodel.productos.Where(x => x.idProducto == id).FirstOrDefault();
            }
            return View(productosModelos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View(new productos());
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(productos productosModelos)
        {
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                scisamodel.productos.Add(productosModelos);
                scisamodel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            productos productosModelos = new productos();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                productosModelos = scisamodel.productos.Where(x => x.idProducto == id).FirstOrDefault();
            }
            return View(productosModelos);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(productos productosModelos)
        {
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                scisamodel.Entry(productosModelos).State = System.Data.EntityState.Modified;
                scisamodel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            productos productosModelos = new productos();
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                productosModelos = scisamodel.productos.Where(x => x.idProducto == id).FirstOrDefault();
            }
            return View(productosModelos);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (scisaEntities1 scisamodel = new scisaEntities1())
            {
                productos productosModelos = scisamodel.productos.Where(x => x.idProducto == id).FirstOrDefault();
                scisamodel.productos.Remove(productosModelos);
                scisamodel.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
