using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public Imagen() {}

        public int IdImagen { get; set; }
        public int IdArticulo { get; set; }
        public string UrlImagen { get; set; }

        public bool Eliminada { get; set; } = false;
        public override string ToString() => UrlImagen;
    }
}
