using System;

namespace Ewidencja.Models
{
    public class WniosekModel
    {
        public int Id { get; set; }

        public string Typ { get; set; }

        public string Status { get; set; }

        public DateTime Data { get; set; }

        public string Wniosek { get; set; } = null;
    }
}
