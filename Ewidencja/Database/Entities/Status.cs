using Ewidencja.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ewidencja.Database.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(StatusTyp))]
        public StatusTyp Stan { get; set; }
    }
}
