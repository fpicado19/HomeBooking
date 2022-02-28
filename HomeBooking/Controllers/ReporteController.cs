using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;

namespace HomeBooking.Controllers
{
    public class ReporteController : Controller
    {

        public ActionResult GraficoPedido()
        {

            IServiceReserva servicePedido = new ServiceReserva();
            var list = servicePedido.GetReserva();
            List<int> repartitions = new List<int>();
            var pedidos = list.Select(s => s.IDCliente).Distinct();
            foreach (var item in pedidos)
            {
                repartitions.Add(list.Count(x => x.IDCliente == item));
            }

            var rep = repartitions;
            ViewBag.pedidos = pedidos;
            ViewBag.rep = rep.ToList();

            return View();


        }
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reporte/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reporte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reporte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
