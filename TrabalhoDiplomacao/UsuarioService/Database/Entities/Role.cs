using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Database.Entities
{
    [Table("Roles")]
    public class Role
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(450)]
        public string RoleName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
