using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ewidencja.Database.Entities
{
    public class Zameldowanie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Kraj { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Ulica { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string NrDomu { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string NrLokalu { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string KodPocztowy { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Miejscowosc { get; set; }

        [Required]
        [ForeignKey("PESEL")]
        public int PeselId { get; set; }

        public PESEL PESEL { get; set; }
    }
}
