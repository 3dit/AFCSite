using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCSite.Server.Models;

[Table("StyleSheet")]
public partial class StyleSheet
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Updated { get; set; }

    [Column("CSSData")]
    public string? Cssdata { get; set; }
}
