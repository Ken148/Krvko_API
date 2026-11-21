using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Termin")]
public class Termin
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("TK_Zdravnik")]
    public int ZdravnikId { get; set; }

    [Column("TK_Lokacija_darovanja")]
    public int LokacijaDarovanjaId { get; set; }

    [Column("datum_cas_dogodka")]
    public DateTime DatumCasDogodka { get; set; }

    [Column("prosta_mesta")]
    public int ProstaMesta { get; set; }

    [ForeignKey(nameof(ZdravnikId))]
    public Zdravnik Zdravnik { get; set; } = null!;

    [ForeignKey(nameof(LokacijaDarovanjaId))]
    public LokacijaDarovanja LokacijaDarovanja { get; set; } = null!;

    public ICollection<Darovanje> Darovanja { get; set; } = new List<Darovanje>();
    public ICollection<Obvestilo> Obvestila { get; set; } = new List<Obvestilo>();
}