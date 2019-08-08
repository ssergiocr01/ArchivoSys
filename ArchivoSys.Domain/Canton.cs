using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoSys.Domain
{
    public class Canton
    {
        [Key]
        public int CantonId { get; set; }

        [Display(Name = "Provincia")]
        [Index("Canton_Name_ProvinceId_Index", IsUnique = true, Order = 2)]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} tiene un máximo de {1} caracteres de longitud")]
        [Index("Canton_Name_ProvinceId_Index", IsUnique = true, Order = 1)]
        [Display(Name = "Cantón")]
        public string Name { get; set; }

        public virtual Province Province { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
