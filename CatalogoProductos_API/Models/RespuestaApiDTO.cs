using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogoProductos_API.Models
{
    public class RespuestaApiDTO
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public Object Dato { get; set; }
    }
}