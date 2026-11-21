using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Lokacija_darovanja")]
public class LokacijaDarovanja
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required, MaxLength(150)]
    [Column("naziv")]
    public string Naziv { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    [Column("naslov")]
    public string Naslov { get; set; } = string.Empty;

    [MaxLength(100)]
    [Column("prostor")]
    public string? Prostor { get; set; }

    public ICollection<Termin> Termini { get; set; } = new List<Termin>();
}