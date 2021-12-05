using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ewidencja.Database.Entities
{
    public class Wyjazdy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataWyjazdu { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string KrajWyjazdu { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Od { get; set; }

        [Column(TypeName = "date")]
        public DateTime Do { get; set; }

        [Required]
        [ForeignKey("PESEL")]
        public int PeselId { get; set; }

        public PESEL PESEL { get; set; }

    }
}
