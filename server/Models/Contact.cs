using System.ComponentModel.DataAnnotations;

namespace AFCSite.Server.Models;

public partial class Contact
{
    [Key]
    public int ContactId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Email { get; set; }
}
