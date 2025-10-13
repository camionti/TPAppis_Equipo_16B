using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace dominio

{
    public class Articulo
    { 
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int Idmarca { get; set; }
            public int Idcategoria { get; set; }
            public int Idimagen { get; set; }
            public decimal Precio { get; set; }
            public Marca TipoMarca { get; set; }
            public Categoria TipoCategoria { get; set; }
            public List<Imagen> Imagen { get; set; } = new List<Imagen>();
    }
}
