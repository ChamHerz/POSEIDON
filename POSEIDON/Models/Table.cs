using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  [Table("TABLE")]
  public class Table
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(40)]
    public string Name { get; set; }

    [Required]
    [StringLength(200)]
    public string Description { get; set; }
  }
}
