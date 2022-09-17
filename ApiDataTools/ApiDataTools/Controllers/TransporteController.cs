using ApiDataTools.Context.Entities;
using ApiDataTools.Context.Interfaces;
using ApiDataTools.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace ApiDataTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteController : ControllerBase
    {
        protected readonly IQueryAppService _registrarAppService;
        public TransporteController(IQueryAppService registrarAppService)
        {
            this._registrarAppService = registrarAppService;
        }

        [HttpPost]
        [Route("RegistraEmpresa")]
        public AppResultDto RegistraEmpresa(Empresa empresa)
        {
            try
            {
                string mensaje = null;

                if (!(_registrarAppService.RegistrarEmpresa(empresa, ref mensaje)))
                    return AppResultDto.CreateError(mensaje);

            }
            catch (Exception ex)
            {
                return AppResultDto.CreateError(ex.Message);
            }

            return AppResultDto.CreateSuccessful("Empresa registrada correctamente.");
        }

        [HttpPost]
        [Route("RegistraRepresentanteLegal")]
        public AppResultDto RegistraRepresentanteLegal(RepresentanteLegal representanteLegal)
        {
            try
            {
                string mensaje = null;

                if (!(_registrarAppService.RegistrarRepresentanteLegal(representanteLegal, ref mensaje)))
                    return AppResultDto.CreateError(mensaje);

            }
            catch (Exception ex)
            {
                return AppResultDto.CreateError(ex.Message);
            }

            return AppResultDto.CreateSuccessful("Representante Legal registrado correctamente.");
        }

        [HttpGet]
        [Route("ConsultaEmpresaDetalle")]
        public IEnumerable<ConsultaEmpresaDetalle> ConsultaEmpresaDetalle()
        {
            try
            {
                string mensaje = null;

                var result = _registrarAppService.ConsultarEmpresaDetalle(ref mensaje);

                if (!string.IsNullOrEmpty(mensaje))
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                else

                    Response.StatusCode = (int)HttpStatusCode.OK;

                return result;
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultaEmpresas")]
        public IEnumerable<ConsultaEmpresas> ConsultaEmpresas()
        {
            try
            {
                string mensaje = null;

                var result = _registrarAppService.ConsultarEmpresas(ref mensaje);

                if (!string.IsNullOrEmpty(mensaje))
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                else

                    Response.StatusCode = (int)HttpStatusCode.OK;

                return result;
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultaTipoIdentificacion")]
        public IEnumerable<ConsultaTipoIdentificacion> ConsultaTipoIdentificacion()
        {
            try
            {
                string mensaje = null;

                var result = _registrarAppService.ConsultarTipoIdentificacion(ref mensaje);

                if (!string.IsNullOrEmpty(mensaje))
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                else

                    Response.StatusCode = (int)HttpStatusCode.OK;

                return result;
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }
        }
    }
}
