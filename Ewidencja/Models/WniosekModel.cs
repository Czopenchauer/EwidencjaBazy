using System;

namespace Ewidencja.Models
{
    public class WniosekModel
    {
        public string Typ { get; set; }

        public string Status { get; set; }

        public DateTime Data { get; set; }

        public string Wniosek { get; set; } = null;
    }
}
