using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  [Table("USER")]
  public class User
  {
    [Key]
    [StringLength(50)]
    public string Account { get; set; }

    [Required]
    [StringLength(15)]
    public string Key { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }

    [Required]
    public bool Active { get; set; }

    [Required]
    [StringLength(4)]
    public string Destine { get; set; }

    [Required]
    [StringLength(2)]
    public string Degree { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    public bool Authorized { get; set; }

    [Required]
    [StringLength(50)]
    public string Charge { get; set; }
    
    [Required]
    [StringLength(6)]
    public string InternalPhone { get; set; }
  }
}
