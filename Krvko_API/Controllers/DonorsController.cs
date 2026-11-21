using Microsoft.AspNetCore.Mvc;

namespace Krvko_API.Controllers;

// ---------- Model ----------
public class Donor
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string BloodType { get; set; } = "";
}

// ---------- Vmesnik servisa (tega v testih zamenjamo z mockom) ----------
public interface IDonorService
{
    Donor? GetById(int id);
    Donor Create(Donor donor);
}

// ---------- Preprosta implementacija v pomnilniku (brez baze) ----------
public class DonorService : IDonorService
{
    private readonly List<Donor> _donors = new();
    private int _nextId = 1;

    public Donor? GetById(int id)
    {
        return _donors.FirstOrDefault(d => d.Id == id);
    }

    public Donor Create(Donor donor)
    {
        donor.Id = _nextId++;
        _donors.Add(donor);
        return donor;
    }
}

// ---------- Controller ----------
[ApiController]
[Route("api/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly IDonorService _service;

    public DonorsController(IDonorService service)
    {
        _service = service;
    }

    // GET api/donors/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var donor = _service.GetById(id);
        if (donor == null)
            return NotFound();

        return Ok(donor);
    }

    // POST api/donors
    [HttpPost]
    public IActionResult Create(Donor donor)
    {
        if (string.IsNullOrWhiteSpace(donor.Name))
            return BadRequest("Ime je obvezno.");

        var created = _service.Create(donor);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}