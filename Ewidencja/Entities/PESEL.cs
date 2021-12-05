using System;
using System.ComponentModel.DataAnnotations;

namespace Ewidencja.Entities
{
    public class PESEL
    {
        [Key]
        public int PESELID { get; set; }

        public string NrPESEL { get; set; }

        public string Imie1 { get; set; }

        public string Imie2 { get; set; }

        public string Nazwisko { get; set; }

        public bool Plec { get; set; }

        public DateTime DataUrodzenia { get; set; }

        public string MiejsceUrodzenia { get; set; }

        public string KrajUrodzenia { get; set; }

    }
}
