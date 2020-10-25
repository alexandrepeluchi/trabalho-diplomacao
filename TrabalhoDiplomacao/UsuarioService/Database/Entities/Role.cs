using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioService.Database.Entities
{
    public class Role
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [MaxLength(450)]
        public string RoleName { get; private set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; private set; }
    }
}
