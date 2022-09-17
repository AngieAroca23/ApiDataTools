using ApiDataTools.Context.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiDataTools.Context.Model
{
    public sealed partial class DTDbContext
    {
        internal void RegistrarEmpresa(Empresa empresa)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, empresa.NumeroDocumento));
            param.Add(new SqlParameter("@p" + param.Count, empresa.TipoDocumento));
            param.Add(new SqlParameter("@p" + param.Count, empresa.NombreCompleto));
            param.Add(new SqlParameter("@p" + param.Count, empresa.Direccion));
            param.Add(new SqlParameter("@p" + param.Count, empresa.Ciudad));
            param.Add(new SqlParameter("@p" + param.Count, empresa.Departamento));
            param.Add(new SqlParameter("@p" + param.Count, empresa.Pais));
            param.Add(new SqlParameter("@p" + param.Count, empresa.Telefono));

            string commandText = "INS_Empresa ";
            for (int i = 0; i < param.Count; i++)
                commandText += $"@p{i},";

            commandText = commandText.TrimEnd(',');
            Database.ExecuteSqlRaw(commandText, param);
        }

        internal void RegistrarRepresentanteLegal(RepresentanteLegal representanteLegal)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.NumeroDocumento));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.TipoDocumento));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.NombreCompleto));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.Direccion));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.Ciudad));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.Departamento));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.Pais));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.Telefono));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.PlacaVehiculo));
            param.Add(new SqlParameter("@p" + param.Count, representanteLegal.NumeroDocumentoEmp));

            string commandText = "INS_RepresentanteLegal ";
            for (int i = 0; i < param.Count; i++)
                commandText += $"@p{i},";

            commandText = commandText.TrimEnd(',');
            Database.ExecuteSqlRaw(commandText, param);
        }

        internal IEnumerable<ConsultaEmpresaDetalle> ConsultarEmpresaDetalle()
        {
            return ConsultaEmpresaDetalle.FromSqlRaw("QRY_ConsultaEmpresaDetalle ").ToList();
        }

        internal IEnumerable<ConsultaEmpresas> ConsultarEmpresas()
        {
            return ConsultaEmpresas.FromSqlRaw("QRY_ConsultaEmpresas ").ToList();
        }

        internal IEnumerable<ConsultaTipoIdentificacion> ConsultarTipoIdentificacion()
        {
            return ConsultaTipoIdentificacion.FromSqlRaw("QRY_ConsultaTipoIdentificacion ").ToList();
        }
    }
}
