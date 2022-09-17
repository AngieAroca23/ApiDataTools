using System;

namespace AppDataTools.Models
{
    public class Transporte
    {
		public string PlacaVehiculo { get; set; }
		public string TipoIdentificacionEmpresa { get; set; }
		public int NumeroDocumento { get; set; }
		public string NombreCompleto { get; set; }
		public int Cantidad { get; set; }
        public int TipoDocumento { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public int NumeroDocumentoEmp { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}