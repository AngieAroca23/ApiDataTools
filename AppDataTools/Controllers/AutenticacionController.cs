using AppDataTools.Models;
using AppDataTools.RequestApi;
using SweetAlert.Controllers;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AppDataTools.Models.Enum;

namespace AppDataTools.Controllers
{
    [HandleError]
    public class AutenticacionController : SweetController
    {
        [HttpGet]
        public ActionResult Login()
        {

            Session.Clear();
            ViewData.Clear();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now); 
            Response.Cache.SetNoStore();
            Response.Cache.SetNoServerCaching();

            return View();
        }

        [HttpPost]
#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica. Puede usar el operador 'await' para esperar llamadas API que no sean de bloqueo o 'await Task.Run(...)' para hacer tareas enlazadas a la CPU en un subproceso en segundo plano.
        public async Task<ActionResult> Login(Autenticacion autenticacion)
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica. Puede usar el operador 'await' para esperar llamadas API que no sean de bloqueo o 'await Task.Run(...)' para hacer tareas enlazadas a la CPU en un subproceso en segundo plano.
        {
            if (String.IsNullOrEmpty(autenticacion.UserName) || String.IsNullOrEmpty(autenticacion.Pass))
            {
                return View();
            }

            if (autenticacion.UserName == "UserPrueba22" && autenticacion.Pass == "PruebaDT2022")
            {
                System.Web.HttpContext.Current.Session["Usuario"] = autenticacion.UserName;
                return RedirectToAction("Home", "Transporte");
            }
            else
            {
                Alert("Usuario o contraseña incorrectos.", NotificationType.error);
            }
            return View();

        }
    }
}