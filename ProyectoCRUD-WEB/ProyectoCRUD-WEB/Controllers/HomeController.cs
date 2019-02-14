using ProyectoCRUD_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCRUD_WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RegistroProducto pd = new RegistroProducto();
            return View(pd.RecuperarTodos());
        }
        public ActionResult Grabar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Grabar(FormCollection collection)
        {
            RegistroProducto pd = new RegistroProducto();
            Producto produ = new Producto
            {
                Id = int.Parse(collection["Id"]),
                Descripcion = collection["Descripcion"],
                Tipo = collection["Tipo"],
                Precio = decimal.Parse(collection["Precio"].ToString()),
            };
            pd.GrabarProducto(produ);
            return RedirectToAction("Index");
        }
        public ActionResult Borrar(int Id)
        {
            RegistroProducto produ = new RegistroProducto();
            produ.Borrar(Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            RegistroProducto produ = new RegistroProducto();
            Producto pd = new Producto()
            {
                Id = int.Parse(collection["Id"]),
                Descripcion = collection["Descripcion"],
                Tipo = collection["Tipo"],
                Precio = decimal.Parse(collection["Precio"]),
            };
            produ.Modificar(pd);
            return RedirectToAction("Index");
        }

    }
}