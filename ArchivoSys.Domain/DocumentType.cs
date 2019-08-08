using System.ComponentModel.DataAnnotations;

namespace ArchivoSys.Domain
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage ="El campo {0} tiene un máximo de {1} caracteres de longitud")]
        [Display(Name ="Tipo de documento")]
        public string Name { get; set; }
    }
}
