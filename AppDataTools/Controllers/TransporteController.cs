using AppDataTools.Models;
using AppDataTools.RequestApi;
using SweetAlert.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using static AppDataTools.Models.Enum;

namespace AppDataTools.Controllers
{
    [HandleError]
    public class TransporteController : SweetController
    {
        private AppResult result = new AppResult();
        private requestApi ra = new requestApi();
        string Baseurl = "http://localhost:21391";

        public async Task<ActionResult> Home()
        {
            var resultConsulta = await ra.RequestApiResourceGet(Baseurl, $"api/Transporte/ConsultaEmpresaDetalle");
            if (resultConsulta == null)
                resultConsulta = new List<Transporte>();


            ViewData["EmpresaList"] = resultConsulta;

            var resultTipoIden = await ra.RequestApiResourceGet(Baseurl, $"api/Transporte/ConsultaTipoIdentificacion");
            ViewBag.TipoDocumento = new SelectList(resultTipoIden.OrderBy(x => x.Id), "Id", "Descripcion");

            var resultEmpresa = await ra.RequestApiResourceGet(Baseurl, $"api/Transporte/ConsultaEmpresas");
            ViewBag.NumeroDocumentoEmp = new SelectList(resultEmpresa.OrderBy(x => x.NumeroDocumento), "NumeroDocumento", "NombreCompleto");

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmpresa(Transporte collection)
        {
            try
            {
                Empresa empresa = new Empresa()
                {
                    NumeroDocumento = collection.NumeroDocumento,
                    TipoDocumento = collection.TipoDocumento,
                    NombreCompleto = collection.NombreCompleto,
                    Ciudad = collection.Ciudad,
                    Departamento = collection.Departamento,
                    Direccion = collection.Direccion,
                    Pais = collection.Pais,
                    Telefono = collection.Telefono
                };

                if (empresa.NumeroDocumento == 0)
                {
                    Alert("Debe digitar un número de documento con máximo 10 digitos.", NotificationType.info);
                    return RedirectToAction("Home");
                }

                result = await ra.RequestApiResourcePost(Baseurl, "api/Transporte/RegistraEmpresa", empresa);
                if (!result.IsSuccessful)
                {
                    Alert(result.Message, NotificationType.error);
                }
                else
                {
                    Alert(result.Message, NotificationType.success);

                }
            }
            catch
            {
                return RedirectToAction("Home");
            }
            return RedirectToAction("Home");
        }

        [HttpPost]
        public async Task<ActionResult> CreateRepresentante(Transporte collection)
        {
            ;
            try
            {
                RepresentanteLegal representante = new RepresentanteLegal()
                {
                    NumeroDocumento = collection.NumeroDocumento,
                    TipoDocumento = collection.TipoDocumento,
                    NombreCompleto = collection.NombreCompleto,
                    Ciudad = collection.Ciudad,
                    Departamento = collection.Departamento,
                    Direccion = collection.Direccion,
                    Pais = collection.Pais,
                    Telefono = collection.Telefono,
                    NumeroDocumentoEmp = collection.NumeroDocumentoEmp,
                    PlacaVehiculo = collection.PlacaVehiculo
                };

                if (representante.NumeroDocumento == 0)
                {
                    Alert("Debe digitar un número de documento con máximo 10 digitos.", NotificationType.info);
                    return RedirectToAction("Home");
                }

                result = await ra.RequestApiResourcePost(Baseurl, "api/Transporte/RegistraRepresentanteLegal", representante);
                if (!result.IsSuccessful)
                {
                    Alert(result.Message, NotificationType.error);
                }
                else
                {
                    Alert(result.Message, NotificationType.success);

                }
            }
            catch
            {
                return RedirectToAction("Home");
            }
            return RedirectToAction("Home");
        }

    }
}
