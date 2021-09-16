using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.DTO
{
  public class LoginDTO
  {
    [Required]
    [StringLength(15)]
    public string User { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }
  }
}
