using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCSite.Server.Models;

[Table("Family")]
public partial class Family
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [InverseProperty("Family")]
    public virtual ICollection<BaseIngredient> BaseIngredients { get; set; } = new List<BaseIngredient>();
}
