//using Microsoft.Scripting.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogoProductos_Negocios.Models
{
    public class Neg_CatalogoProductos
    {
        //[ModelBinder(BinderType = typeof(ByteArrayModelBinder))]
        public int Id_CatPro { get; set; }

        public string Nombre_CatPro { get; set; }

        public string DescripcionBreve_CatPro { get; set; }

        public string Categoria_CatPro { get; set; }

        public string ExtImagProd_CatPro { get; set; }
        public string ImagenProducto_CatPro { get; set; }
    }
}
