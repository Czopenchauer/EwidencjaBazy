using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ewidencja.Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Rola { get; set; }


        public ICollection<Wniosek> Wnioseks { get; set; }

        public ICollection<Edycja> Edycjas { get; set; }

    }
}
