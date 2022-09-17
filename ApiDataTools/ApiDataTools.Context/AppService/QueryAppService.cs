using ApiDataTools.Context.Entities;
using ApiDataTools.Context.Interfaces;
using ApiDataTools.Context.Model;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ApiDataTools.Context.AppService
{
    public class QueryAppService : IQueryAppService
    {
        protected readonly IServiceScopeFactory serviceScopeFactory;
        public QueryAppService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public bool RegistrarEmpresa(Empresa empresa, ref string mensaje)
        {

            using var scope = serviceScopeFactory.CreateScope();
            using var dtDbContext = scope.ServiceProvider.GetRequiredService<DTDbContext>();
            using IDbContextTransaction trans = dtDbContext.Database.BeginTransaction();

            try
            {
                dtDbContext.RegistrarEmpresa(empresa);
                trans.Commit();

                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                mensaje = "Error al registrar Empresa => " + ex.Message;
                return false;
            }
        }

        public bool RegistrarRepresentanteLegal(RepresentanteLegal representanteLegal, ref string mensaje)
        {

            using var scope = serviceScopeFactory.CreateScope();
            using var dtDbContext = scope.ServiceProvider.GetRequiredService<DTDbContext>();
            using IDbContextTransaction trans = dtDbContext.Database.BeginTransaction();

            try
            {
                dtDbContext.RegistrarRepresentanteLegal(representanteLegal);
                trans.Commit();

                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                mensaje = "Error al registrar Empresa => " + ex.Message;
                return false;
            }
        }

        public IEnumerable<ConsultaEmpresaDetalle> ConsultarEmpresaDetalle(ref string mensaje)
        {
            try
            {
                using var scope = serviceScopeFactory.CreateScope();
                using var dtDbContext = scope.ServiceProvider.GetRequiredService<DTDbContext>();
                return dtDbContext.ConsultarEmpresaDetalle();
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar Empresa Detallada => " + ex.Message;
                return null;
            }
        }

        public IEnumerable<ConsultaEmpresas> ConsultarEmpresas(ref string mensaje)
        {
            try
            {
                using var scope = serviceScopeFactory.CreateScope();
                using var dtDbContext = scope.ServiceProvider.GetRequiredService<DTDbContext>();
                return dtDbContext.ConsultarEmpresas();
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar Empresa => " + ex.Message;
                return null;
            }
        }

        public IEnumerable<ConsultaTipoIdentificacion> ConsultarTipoIdentificacion(ref string mensaje)
        {
            try
            {
                using var scope = serviceScopeFactory.CreateScope();
                using var dtDbContext = scope.ServiceProvider.GetRequiredService<DTDbContext>();
                return dtDbContext.ConsultarTipoIdentificacion();
            }
            catch (Exception ex)
            {
                mensaje = "Error al consultar Empresa => " + ex.Message;
                return null;
            }
        }
    }
}
