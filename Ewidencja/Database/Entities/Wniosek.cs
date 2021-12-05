using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ewidencja.Database.Entities
{
    public class Wniosek
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Formularz { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey("Typ")]
        public int TypId { get; set; }

        public Typ Typ { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public Status Status { get; set; }

    }
}
