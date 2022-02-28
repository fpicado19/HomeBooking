using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructura.Models;
using web.Utils;

namespace HomeBooking.Controllers
{
    public class CasasController : Controller
    {
        // GET: Casas
        public ActionResult AdminCasas()
        {
            IEnumerable<Casa> lista = null;
            try
            {
                IServiceCasa _ServiceLibro = new ServiceCasa();
                lista = _ServiceLibro.GetCasas();
                ViewBag.title = "Lista Casas";
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
        public ActionResult ClienteCasas()
        {
            IEnumerable<Casa> lista = null;
            try
            {
                IServiceCasa _ServiceLibro = new ServiceCasa();
                lista = _ServiceLibro.GetCasas();
                ViewBag.title = "Lista Casas";
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
        // GET: Casas/Details/5
        public ActionResult Details(int? id)
        {
            ServiceCasa _ServiceLibro = new ServiceCasa();
            Casa libro = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("AdminCasas");
                }

                libro = _ServiceLibro.GetCasaByID(id.Value);
                if (libro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Casas";
                    TempData["Redirect-Action"] = "AdminCasas";
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
                TempData["Redirect"] = "Casas";
                TempData["Redirect-Action"] = "AdminCasas";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Casas/Create
        public ActionResult Create()
        {
            ViewBag.idCasa = listaCasas();
            return View();
        }

        private SelectList listaCasas(int idCasa = 0)
        {
            //Lista de Casas
            IServiceTipoCasa serviceTipo = new ServiceTipoCasa();
            IEnumerable<TipoCasa> listaCasas = serviceTipo.GetTipoCasa();
            return new SelectList(listaCasas, "IdCasa", "Nombre", idCasa);

        }

        // POST: Casas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("AdminCasas");
            }
            catch
            {
                return View();
            }
        }

        // GET: Casas/Edit/5
        public ActionResult Edit(int? id)
        {
            ServiceCasa serviceCasa = new ServiceCasa();
            Casa casa = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("AdminCasas");
                }
                casa = serviceCasa.GetCasaByID(id.Value);
                if (casa == null)
                {                    
                    TempData["Message"] = "No existe la casa";
                    TempData["Redirect"] = "Casas";
                    TempData["Redirect-Action"] = "AdminCasas";
                    //Redireccion a la capruta de Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.IdCasa = listaCasas();
                return View(casa);
            }
            catch (Exception ex)
            {

                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                TempData["Redirect"] = "Casas";
                TempData["Redirect-Action"] = "AdminCasas";
                //Redireccion a la capruta de Error
                return RedirectToAction("Default", "AdminCasas");
            }            
        }

        // POST: Casas/Edit/5
        [HttpPost]
        public ActionResult Save(Casa casa, HttpPostedFileBase ImageFile)
        {
            MemoryStream target = new MemoryStream();

            IServiceCasa _ServiceCasa = new ServiceCasa();
            try
            {
                if (casa.Foto == null)
                {
                    if (ImageFile != null)
                    {
                        ImageFile.InputStream.CopyTo(target);
                        casa.Foto = target.ToArray();
                        ModelState.Remove("Foto");
                    }

                }
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Casa oCasa = _ServiceCasa.Save(casa);
                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    ViewBag.IdCasa = listaCasas();
                    return View("Create", casa);
                }
                return RedirectToAction("AdminCasas");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                TempData["Redirect"] = "Casas";
                TempData["Redirect-Action"] = "AdminCasas";
                //Redireccion a la capruta de Error
                return RedirectToAction("AdminCasas", "Casas");
            }
        }

        // GET: Casas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Casas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("AdminCasas");
            }
            catch
            {
                return View();
            }
        }
    }
}
