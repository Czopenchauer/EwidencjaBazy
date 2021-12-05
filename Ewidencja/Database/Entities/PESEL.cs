using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ewidencja.Database.Entities
{
    public class PESEL
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(11)")]
        public string NrPESEL { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Imie1 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Imie2 { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Nazwisko { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Plec { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataUrodzenia { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string MiejsceUrodzenia { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string KrajUrodzenia { get; set; }

        public ICollection<Edycja> Edycjas { get; set; }

        public ICollection<Zameldowanie> Zameldowanies { get; set; }

        public ICollection<Wyjazdy> Wyjazdies { get; set; }

    }
}
