using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using HomeBooking.Util;
using Infraestructura.Models;
using web.Utils;

namespace HomeBooking.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Usuario usuario)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario oUsuario = null;
            try
            {
                if (ModelState.IsValid)
                {
                    oUsuario = _ServiceUsuario.GetUsuario(usuario.Identificacion, usuario.Contraseña);

                    if (oUsuario != null)
                    {
                        Session["User"] = oUsuario;

                        Log.Info($"Accede {oUsuario.Nombre} {oUsuario.PrimerApellido} con el rol { oUsuario.Rol.IdRol} -{ oUsuario.Rol.IdRol}");

                        TempData["mensaje"] = SweetAlert.Mensaje("Login", "Usario autenticado satisfactoriamente", SweetAlertMessageType.success);

                        if (oUsuario.IdRol == 1)
                        {
                            return RedirectToAction("AdminHome", "Home");
                        }
                        if (oUsuario.IdRol == 2)
                        {
                            return RedirectToAction("ClienteHome", "Home");
                        }
                    }
                    else
                    {
                        Log.Warn($"{usuario.Identificacion} se intentó conectar  y falló");
                        ViewBag.NotificationMessage = SweetAlert.Mensaje("Login", "Error al autenticarse", SweetAlertMessageType.warning);
                    }
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Logout(Usuario usuario)
        {
            try
            {
                Log.Info("Usuario desconectado!");
                Session["User"] = null;
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData["Redirect"] = "Login";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult UnAuthorized()
        {
            try
            {
                ViewBag.Message = "No autorizado";

                if (Session["User"] != null)
                {
                    Usuario oUsuario = Session["User"] as Usuario;
                    Log.Warn($"El usuario {oUsuario.Nombre} {oUsuario.PrimerApellido} con el rol {oUsuario.Rol.IdRol}-{oUsuario.Rol.Descripcion}, intentó acceder una página sin permisos  ");
                }

                return View();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData["Redirect"] = "Login";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
