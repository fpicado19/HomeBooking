using ApplicationCore.Services;
using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using web.Utils;

namespace HomeBooking.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicios
        public ActionResult AdminServicio()
        {
            IEnumerable<TipoServicio> lista = null;
            try
            {
                IServiceServicio _ServiceLibro = new ServiceServicio();
                lista = _ServiceLibro.GetServicio();
                ViewBag.title = "Lista Servicios";
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult ClienteServicio()
        {
            IEnumerable<TipoServicio> lista = null;
            try
            {
                IServiceServicio _ServiceLibro = new ServiceServicio();
                lista = _ServiceLibro.GetServicio();
                ViewBag.title = "Lista Servicios";
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            ServiceServicio _ServiceLibro = new ServiceServicio();
            TipoServicio libro = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("AdminServicio");
                }

                libro = _ServiceLibro.GetServicioByID(id.Value);
                if (libro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Servicios";
                    TempData["Redirect-Action"] = "AdminServicio";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(libro);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Servicios";
                TempData["Redirect-Action"] = "AdminServicio";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("AdminServicio");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            ServiceServicio serviceCasa = new ServiceServicio();
            TipoServicio casa = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("AdminServicio");
                }
                casa = serviceCasa.GetServicioByID(id.Value);
                if (casa == null)
                {
                    TempData["Message"] = "No existe la casa";
                    TempData["Redirect"] = "Servicios";
                    TempData["Redirect-Action"] = "AdminServicio";
                    //Redireccion a la capruta de Error
                    return RedirectToAction("Default", "Error");
                }
                return View(casa);
            }
            catch (Exception ex)
            {

                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                TempData["Redirect"] = "Servicios";
                TempData["Redirect-Action"] = "AdminServicio";
                //Redireccion a la capruta de Error
                return RedirectToAction("Default", "AdminServicio");
            }
        }

        // POST: Servicios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("AdminServicio");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Servicios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("AdminServicio");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Save(TipoServicio servicio)
        {
            IServiceServicio _ServiceServicio = new ServiceServicio();
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    TipoServicio oServicio = _ServiceServicio.Save(servicio);
                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    return View("Create", servicio);
                }
                return RedirectToAction("AdminServicio");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                TempData["Redirect"] = "Servicios";
                TempData["Redirect-Action"] = "AdminServicio";
                //Redireccion a la capruta de Error
                return RedirectToAction("Default", "AdminServicio");
            }
        }
    }
}
