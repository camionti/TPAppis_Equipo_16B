using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPAppis_Equipo_16_B.Models
{
    public class ImagenDTO
    {
        public int IdImagen { get; set; }
        public int IdArticulo { get; set; }
        public string UrlImagen { get; set; }
        public bool Eliminada { get; set; } = false;
    }
}