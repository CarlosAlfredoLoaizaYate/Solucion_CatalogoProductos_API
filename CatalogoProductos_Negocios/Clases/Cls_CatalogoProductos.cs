using CatalogoProductos_DB.Context;
using CatalogoProductos_DB.Models;
using CatalogoProductos_Negocios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CatalogoProductos_Negocios.Clases
{
    public class Cls_CatalogoProductos
    {
        private readonly CatalogoProductosContext db;
        public Cls_CatalogoProductos(CatalogoProductosContext db)
        {
            //this.db = new CatalogoProductosContext();
            this.db = db;
        }

        public List<Neg_CatalogoProductos> GetCatalogoProductos(out string Mensaje, out int Codigo)
        {
            Mensaje = "Ok";
            Codigo = 200;
            try
            {
                List<Neg_CatalogoProductos> lst_Neg_CatalogoProductos = new List<Neg_CatalogoProductos>();
                Neg_CatalogoProductos cls_Neg_CatalogoProductos;
                var resultado = db.CatalogoProductos.Select(x => x).ToList();

                foreach (var item in resultado)
                {
                    cls_Neg_CatalogoProductos = new Neg_CatalogoProductos
                    {
                        Id_CatPro = item.Id_CatPro,
                        Nombre_CatPro = item.Nombre_CatPro,
                        DescripcionBreve_CatPro = item.DescripcionBreve_CatPro,
                        Categoria_CatPro = item.Categoria_CatPro,
                        ExtImagProd_CatPro = item.ExtImagProd_CatPro,
                        ImagenProducto_CatPro = Convert.ToBase64String(item.ImagenProducto_CatPro)
                    };
                    lst_Neg_CatalogoProductos.Add(cls_Neg_CatalogoProductos);
                }

                return lst_Neg_CatalogoProductos;
            }
            catch (Exception Exc)
            {
                Mensaje = Exc.Message;
                Codigo = 400;

                return null;
            }
        }

        public Neg_CatalogoProductos GetCatalogoProductosId(int id, out string Mensaje, out int Codigo)
        {
            Mensaje = "Ok";
            Codigo = 200;
            try
            {
                CatalogoProductos catalogoProductos = db.CatalogoProductos.Find(id);
                if (catalogoProductos == null)
                {
                    Mensaje = "No se encontro el producto";
                    return null;
                }
                else
                {
                    Neg_CatalogoProductos neg_CatalogoProductos = new Neg_CatalogoProductos
                    {
                        Id_CatPro = catalogoProductos.Id_CatPro,
                        Nombre_CatPro = catalogoProductos.Nombre_CatPro,
                        DescripcionBreve_CatPro = catalogoProductos.DescripcionBreve_CatPro,
                        Categoria_CatPro = catalogoProductos.Categoria_CatPro,
                        ExtImagProd_CatPro = catalogoProductos.ExtImagProd_CatPro,
                        ImagenProducto_CatPro = Convert.ToBase64String(catalogoProductos.ImagenProducto_CatPro)
                    };
                    return neg_CatalogoProductos;
                }
            }
            catch (Exception Exc)
            {
                Mensaje = Exc.Message;
                Codigo = 400;

                return null;
            }

        }

        public List<Neg_CatalogoProductos> GetCatalogoProductosFilter(string TipBusqueda, string ValorBusqueda, bool OrdenDesendente, out string Mensaje, out int Codigo)
        {
            Mensaje = "Ok";
            Codigo = 200;
            try
            {
                string var_Nombre_CatPro = null;
                string var_DescripcionBreve_CatPro = null;
                string var_Categoria_CatPro = null;

                switch (TipBusqueda)
                {
                    case "Nombre":
                        var_Nombre_CatPro = ValorBusqueda;
                        break;
                    case "Descripcion":
                        var_DescripcionBreve_CatPro = ValorBusqueda;
                        break;
                    case "Categoria":
                        var_Categoria_CatPro = ValorBusqueda;
                        break;
                }
                var resultado = (
                 from items in db.CatalogoProductos
                 where items.Nombre_CatPro.Contains((var_Nombre_CatPro ?? items.Nombre_CatPro)) &&
                 items.DescripcionBreve_CatPro.Contains(var_DescripcionBreve_CatPro ?? items.DescripcionBreve_CatPro) &&
                 items.Categoria_CatPro.Contains(var_Categoria_CatPro ?? items.Categoria_CatPro)
                 select items
                 
                 );

                if (OrdenDesendente)
                {
                    switch (TipBusqueda)
                    {
                        case "Nombre":
                            resultado = resultado.OrderByDescending(x => x.Nombre_CatPro);
                            break;
                        case "Descripcion":
                            resultado = resultado.OrderByDescending(x => x.DescripcionBreve_CatPro);
                            break;
                        case "Categoria":
                            resultado = resultado.OrderByDescending(x => x.Categoria_CatPro);
                            break;
                    }
                }
                else
                {
                    switch (TipBusqueda)
                    {
                        case "Nombre":
                            resultado = resultado.OrderBy(x => x.Nombre_CatPro);
                            break;
                        case "Descripcion":
                            resultado = resultado.OrderBy(x => x.DescripcionBreve_CatPro);
                            break;
                        case "Categoria":
                            resultado = resultado.OrderBy(x => x.Categoria_CatPro);
                            break;
                    }
                }

                List<Neg_CatalogoProductos> lst_Neg_CatalogoProductos = new List<Neg_CatalogoProductos>();
                Neg_CatalogoProductos cls_Neg_CatalogoProductos;
                //var resultado = db.CatalogoProductos.Select(x => x).ToList();

                foreach (var item in resultado)
                {
                    cls_Neg_CatalogoProductos = new Neg_CatalogoProductos
                    {
                        Id_CatPro = item.Id_CatPro,
                        Nombre_CatPro = item.Nombre_CatPro,
                        DescripcionBreve_CatPro = item.DescripcionBreve_CatPro,
                        Categoria_CatPro = item.Categoria_CatPro,
                        ExtImagProd_CatPro = item.ExtImagProd_CatPro,
                        ImagenProducto_CatPro = Convert.ToBase64String(item.ImagenProducto_CatPro)
                    };
                    lst_Neg_CatalogoProductos.Add(cls_Neg_CatalogoProductos);
                }
                return lst_Neg_CatalogoProductos;
            }
            catch (Exception Exc)
            {
                Mensaje = Exc.Message;
                Codigo = 400;

                return null;
            }

        }


        public void UpdateCatalogoProductos(Neg_CatalogoProductos catalogoProductos, out string Mensaje, out int Codigo)
        {
            Mensaje = "Ok";
            Codigo = 200;

            try
            {
                CatalogoProductos CatalogoProductos = new CatalogoProductos
                {
                    Id_CatPro = catalogoProductos.Id_CatPro,
                    Nombre_CatPro = catalogoProductos.Nombre_CatPro,
                    DescripcionBreve_CatPro = catalogoProductos.DescripcionBreve_CatPro,
                    Categoria_CatPro = catalogoProductos.Categoria_CatPro,
                    ExtImagProd_CatPro = catalogoProductos.ExtImagProd_CatPro,
                    ImagenProducto_CatPro = Convert.FromBase64String(catalogoProductos.ImagenProducto_CatPro)
                };

                db.Entry(CatalogoProductos).State = EntityState.Modified;

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException Exc)
            {
                Mensaje = Exc.Message;
                Codigo = 400;
            }
        }

        public Neg_CatalogoProductos CreateCatalogoProductos(Neg_CatalogoProductos catalogoProductos, out string Mensaje, out int Codigo)
        {
            Mensaje = "Ok";
            Codigo = 200;
            try
            {
                CatalogoProductos CatalogoProductos = new CatalogoProductos
                {
                    Nombre_CatPro = catalogoProductos.Nombre_CatPro,
                    DescripcionBreve_CatPro = catalogoProductos.DescripcionBreve_CatPro,
                    Categoria_CatPro = catalogoProductos.Categoria_CatPro,
                    ExtImagProd_CatPro = catalogoProductos.ExtImagProd_CatPro,
                    ImagenProducto_CatPro = Convert.FromBase64String(catalogoProductos.ImagenProducto_CatPro)
                };

                db.CatalogoProductos.Add(CatalogoProductos);
                db.SaveChanges();

                catalogoProductos.Id_CatPro = CatalogoProductos.Id_CatPro;

                return catalogoProductos;
            }
            catch (Exception Exc)
            {
                Mensaje = Exc.Message;
                Codigo = 400;
                return null;
            }
        }

        public void DeleteCatalogoProductos(int id, out string Mensaje, out int Codigo)
        {
            Mensaje = "Ok";
            Codigo = 200;
            try
            {
                CatalogoProductos catalogoProductos = db.CatalogoProductos.Find(id);

                if (catalogoProductos == null)
                {
                    Mensaje = "No se encontro el producto";
                }

                db.CatalogoProductos.Remove(catalogoProductos);
                db.SaveChanges();
            }
            catch (Exception Exc)
            {
                Mensaje = Exc.Message;
                Codigo = 400;
            }
        }
    }
}
