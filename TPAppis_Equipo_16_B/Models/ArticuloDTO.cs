using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPAppis_Equipo_16_B.Models
{
    public class ArticuloDTO
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Idmarca { get; set; }
        public int Idcategoria { get; set; }
        public int Idimagen { get; set; }
        public decimal Precio { get; set; }
    }
}