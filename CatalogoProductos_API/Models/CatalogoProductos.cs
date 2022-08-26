using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogoProductos_API.Models
{
    public class CatalogoProductos
    {
        public int Id_CatPro { get; set; }

        public string Nombre_CatPro { get; set; }

        public string DescripcionBreve_CatPro { get; set; }

        public string Categoria_CatPro { get; set; }

        public byte[] ImagenProducto_CatPro { get; set; }
    }
}