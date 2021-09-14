using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  [Table("HISTORY")]
  public class History
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int TableId { get; set; }

    [Required]
    public int OriginId { get; set; }

    [Required]
    public int Activity { get; set; }

    [Required]
    [ForeignKey("User")]
    public int? UserId { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    [StringLength(250)]
    public string Observation { get; set; }
  }
}
