using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArchivoSys.Domain
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} tiene un máximo de {1} caracteres de longitud")]
        [Display(Name = "Provincia")]
        public string Name { get; set; }

        public virtual ICollection<Canton> Cantons { get; set; }
    }
}
