using Ewidencja.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ewidencja.Database.Entities
{
    public class Typ
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(WniosekTyp))]
        public WniosekTyp Rodzaj { get; set; }
    }
}
