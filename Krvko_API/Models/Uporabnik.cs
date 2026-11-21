using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Uporabnik")]
public class Uporabnik
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(255)]
    [Column("geslo_hash")]
    public string GesloHash { get; set; } = string.Empty;

    [Column("ustvarjen_ob")]
    public DateTime UstvarjenOb { get; set; }

    public Krvodajalec? Krvodajalec { get; set; }
    public Zdravnik? Zdravnik { get; set; }
    public Admin? Admin { get; set; }
    public ICollection<Obvestilo> Obvestila { get; set; } = new List<Obvestilo>();
}