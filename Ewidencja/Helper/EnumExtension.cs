using Ewidencja.Database.Entities;
using Ewidencja.Database.Enums;
using System.Collections;
using System.Collections.Generic;

namespace Ewidencja.Helper
{

    public static class EnumExtension
    {
        public static readonly string NadajPesel = "Nadanie numeru PESEL";
        public static readonly string Zameldowanie = "Zameldowanie";
        public static readonly string Wyjazd = "Zgloszenie wyjazdu";
        public static readonly string DanePesel = "Udostepnienie danych";

        private static readonly string Przyjeto = "Przyjety";
        private static readonly string Odrzucono = "Odrzucono";
        private static readonly string Oczekujacy = "Oczekujacy";

/*        public static string GetNameOfType(this Typ typ)
        {
            switch (typ.Rodzaj)
            {
                case WniosekTyp.NadajPesel: return NadajPesel;
                case WniosekTyp.Zameldowanie: return Zameldowanie;
                case WniosekTyp.Wyjazd: return Wyjazd;
                case WniosekTyp.DanePesel: return DanePesel;
            }

            return null;
        }*/

        public static string GetNameOfType(this WniosekTyp typ)
        {
            switch (typ)
            {
                case WniosekTyp.NadajPesel: return NadajPesel;
                case WniosekTyp.Zameldowanie: return Zameldowanie;
                case WniosekTyp.Wyjazd: return Wyjazd;
                case WniosekTyp.DanePesel: return DanePesel;
            }

            return null;
        }

        public static string GetNameOfType(this StatusTyp status)
        {
            switch (status)
            {
                case StatusTyp.Przyjety: return Przyjeto;
                case StatusTyp.Odrzucony: return Odrzucono;
                case StatusTyp.Oczekujacy: return Oczekujacy;
            }

            return null;
        }
    }
}
