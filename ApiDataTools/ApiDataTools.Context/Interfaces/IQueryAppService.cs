using ApiDataTools.Context.Entities;
using System.Collections.Generic;

namespace ApiDataTools.Context.Interfaces
{
    public interface IQueryAppService
    {
        bool RegistrarEmpresa(Empresa empresa, ref string mensaje);
        bool RegistrarRepresentanteLegal(RepresentanteLegal representanteLegal, ref string mensaje);
        IEnumerable<ConsultaEmpresaDetalle> ConsultarEmpresaDetalle(ref string mensaje);
        IEnumerable<ConsultaEmpresas> ConsultarEmpresas(ref string mensaje);
        IEnumerable<ConsultaTipoIdentificacion> ConsultarTipoIdentificacion(ref string mensaje);
    }
}
