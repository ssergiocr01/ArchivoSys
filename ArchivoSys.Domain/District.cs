using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchivoSys.Domain
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }

        [Index("District_Name_CantonId_Index", IsUnique = true, Order = 2)]
        [Display(Name = "Cantón")]
        public int CantonId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} tiene un máximo de {1} caracteres de longitud")]
        [Index("District_Name_CantonId_Index", IsUnique = true, Order = 1)]
        [Display(Name = "Distrito")]
        public string Name { get; set; }

        public virtual Canton Canton { get; set; }
    }
}
