using Ewidencja.Database.Entities;
using Ewidencja.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja.Helper
{

    public static class EnumExtension
    {
        private static readonly string NadajPesel = "Nadaj pesel";
        private static readonly string Zameldowanie = "Zameldowanie";
        private static readonly string Wyjazd = "Wyjazd";
        private static readonly string DanePesel = "DanePesel";

        private static readonly string Przyjeto = "Przyjęto";
        private static readonly string Odrzucono = "Odrzucono";
        private static readonly string Oczekujacy = "Oczekujący";



        public static string GetNameOfType(this Typ typ)
        {
            switch (typ.Rodzaj)
            {
                case WniosekTyp.NadajPesel: return NadajPesel;
                case WniosekTyp.Zameldowanie: return Zameldowanie;
                case WniosekTyp.Wyjazd: return Wyjazd;
                case WniosekTyp.DanePesel: return DanePesel;
            }

            return null;
        }

        public static string GetNameOfType(this Status status)
        {
            switch (status.Stan)
            {
                case StatusTyp.Przyjety: return Przyjeto;
                case StatusTyp.Odrzucony: return Odrzucono;
                case StatusTyp.Oczekujacy: return Oczekujacy;
            }

            return null;
        }

    }
}
