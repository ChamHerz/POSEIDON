using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  [Table("USER_ACCESS")]
  public class UserAccess
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    [StringLength(300)]
    public string Token { get; set; }

    [Required]
    public bool Active { get; set; }

    [Required]
    [StringLength(200)]
    public string OperativeSystem { get; set; }

    [Required]
    [StringLength(200)]
    public string Browser { get; set; }

    [Required]
    [StringLength(300)]
    public string Cyte { get; set; }

    [Required]
    [StringLength(300)]
    public string State { get; set; }

    [Required]
    [StringLength(200)]
    public string RefreshToken { get; set; }

    [Required]
    public DateTime RefreshDate { get; set; }

    [Required]
    public bool StillSession { get; set; }
  }
}
