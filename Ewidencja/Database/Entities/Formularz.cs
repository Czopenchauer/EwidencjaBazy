using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ewidencja.Database.Entities
{
    public class Formularz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Template { get; set; }

        [Required]
        [ForeignKey("Typ")]
        public int TypId { get; set; }

        public Typ FormularzTyp { get; set; }
    }
}
