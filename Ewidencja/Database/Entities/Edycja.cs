using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ewidencja.Database.Entities
{
    public class Edycja
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataEdycji { get; set; }

        [Required]
        [ForeignKey("PESEL")]
        public int PeselId { get; set; }

        public PESEL PESEL { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
