using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Obvestilo")]
public class Obvestilo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("prebrano")]
    public bool Prebrano { get; set; }

    [Column("poslano_ob")]
    public DateTime PoslanoOb { get; set; }

    [Column("TK_Termin")]
    public int TerminId { get; set; }

    [Column("TK_Uporabnik")]
    public int UporabnikId { get; set; }

    [ForeignKey(nameof(TerminId))]
    public Termin Termin { get; set; } = null!;

    [ForeignKey(nameof(UporabnikId))]
    public Uporabnik Uporabnik { get; set; } = null!;
}