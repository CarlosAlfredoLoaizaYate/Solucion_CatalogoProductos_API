using CatalogoProductos_DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos_DB.Context
{
    public class CatalogoProductosContext : DbContext
    {
        public CatalogoProductosContext() : base("ConnCatalogoProductosDB")
        {
        }

        public DbSet<CatalogoProductos> CatalogoProductos { get; set; }
    }
}
