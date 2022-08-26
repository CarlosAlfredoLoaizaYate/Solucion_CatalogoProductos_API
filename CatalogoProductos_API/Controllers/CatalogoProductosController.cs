using CatalogoProductos_API.Models;
using CatalogoProductos_DB.Context;
using CatalogoProductos_Negocios.Clases;
using CatalogoProductos_Negocios.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CatalogoProductos_API.Controllers
{
    //[DisableCors]
    public class CatalogoProductosController : ApiController
    {

        private readonly Cls_CatalogoProductos Cls_CatProd = new Cls_CatalogoProductos(new CatalogoProductosContext());
        string Mensaje;
        int Codigo;

        // GET: api/CatalogoProductos
        public IHttpActionResult GetCatalogoProductos()
        {
            var CatalogosProductos = Cls_CatProd.GetCatalogoProductos(out Mensaje, out Codigo);
            return Content(HttpStatusCode.OK,
                          new RespuestaApiDTO
                          {
                              Codigo = Codigo,
                              Descripcion = Mensaje,
                              Dato = CatalogosProductos
                          }
                  );
        }

        // GET: api/CatalogoProductos/5
        [ResponseType(typeof(CatalogoProductos))]
        public IHttpActionResult GetCatalogoProductos(int id)
        {
            Neg_CatalogoProductos neg_CatalogoProductos = Cls_CatProd.GetCatalogoProductosId(id, out Mensaje, out Codigo);

            return Content(HttpStatusCode.OK,
                          new RespuestaApiDTO
                          {
                              Codigo = Codigo,
                              Descripcion = Mensaje,
                              Dato = neg_CatalogoProductos
                          }
                  );
        }

        [ResponseType(typeof(CatalogoProductos))]
        public IHttpActionResult GetCatalogoProductosFiltro(string TipBusqueda, string ValorBusqueda, bool OrdenDesendente)
        {
            var CatalogosProductos = Cls_CatProd.GetCatalogoProductosFilter(TipBusqueda, ValorBusqueda, OrdenDesendente, out Mensaje, out Codigo);

            return Content(HttpStatusCode.OK,
                          new RespuestaApiDTO
                          {
                              Codigo = Codigo,
                              Descripcion = Mensaje,
                              Dato = CatalogosProductos
                          }
                  );
        }
        // PUT: api/CatalogoProductos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalogoProductos(int id, Neg_CatalogoProductos catalogoProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalogoProductos.Id_CatPro)
            {
                return BadRequest();
            }
            var Imagen = catalogoProductos.ImagenProducto_CatPro.Split(',');
            catalogoProductos.ExtImagProd_CatPro = Imagen[0];
            catalogoProductos.ImagenProducto_CatPro = Imagen[1];

            Cls_CatProd.UpdateCatalogoProductos(catalogoProductos, out Mensaje, out Codigo);

            return Content(HttpStatusCode.OK,
                          new RespuestaApiDTO
                          {
                              Codigo = Codigo,
                              Descripcion = Mensaje,
                              Dato = catalogoProductos
                          }
                  );
        }

        // POST: api/CatalogoProductos
        [HttpPost]
        [ResponseType(typeof(CatalogoProductos))]
        public IHttpActionResult PostCatalogoProductos([FromBody] Neg_CatalogoProductos catalogoProductos)
        {
            var Imagen = catalogoProductos.ImagenProducto_CatPro.Split(',');
            catalogoProductos.ExtImagProd_CatPro = Imagen[0];
            catalogoProductos.ImagenProducto_CatPro = Imagen[1];
            catalogoProductos = Cls_CatProd.CreateCatalogoProductos(catalogoProductos, out Mensaje, out Codigo);
            return Content(HttpStatusCode.OK,
                          new RespuestaApiDTO
                          {
                              Codigo = Codigo,
                              Descripcion = Mensaje,
                              Dato = catalogoProductos
                          }
                  );
        }

        // DELETE: api/CatalogoProductos/5
        [ResponseType(typeof(CatalogoProductos))]
        public IHttpActionResult DeleteCatalogoProductos(int id)
        {
            Cls_CatProd.DeleteCatalogoProductos(id, out Mensaje, out Codigo);

            return Content(HttpStatusCode.OK,
                          new RespuestaApiDTO
                          {
                              Codigo = Codigo,
                              Descripcion = Mensaje,
                              Dato = null
                          }
                  );
        }
    }
}