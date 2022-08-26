using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos_DB.Models
{
    [Table("CatalogoProductos")]

    public class CatalogoProductos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int Id_CatPro { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_CatPro { get; set; }

        [Required]
        [StringLength(200)]
        public string DescripcionBreve_CatPro { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoria_CatPro { get; set; }

        [Required]
        [StringLength(50)]
        public string ExtImagProd_CatPro { get; set; }

        [Required]
        public byte[] ImagenProducto_CatPro { get; set; }
    }
}
