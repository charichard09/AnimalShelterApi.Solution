using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace AnimalShelterApi.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class AnimalsController : ControllerBase
{
  private AnimalShelterApiContext _db;

  public AnimalsController(AnimalShelterApiContext db)
  {
    _db = db;
  }

  [HttpGet]
  public async Task<List<Animal>> Get(string species, string ageParameter, string name, string weight, string sex)
  {
    IQueryable<Animal> query = _db.Animals.AsQueryable();

    if (species != null)
    {
      query = query.Where(entry => entry.Species == species);
    }

    if (name != null)
    {
      query = query.Where(entry => entry.Name == name);
    }

    if (sex != null)
    {
      query = query.Where(entry => entry.Sex == sex);
    }

    return await query.ToListAsync();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Animal>> GetAnimal(int id)
  {
    Animal animal = await _db.Animals.FindAsync(id);

    if (animal == null)
    {
      return NotFound();
    }

    return animal;
  }

  [HttpPost]
  public async Task<ActionResult<Animal>> Post(Animal animal)
  {
    _db.Animals.Add(animal);
    await _db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Animal animal)
  {
    if (id != animal.AnimalId)
    {
      return BadRequest();
    }

    _db.Animals.Update(animal);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!AnimalExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  private bool AnimalExists(int id)
  {
    return _db.Animals.Any(e => e.AnimalId == id);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAnimal(int id)
  {
    Animal animal = await _db.Animals.FindAsync(id);
    if (animal == null)
    {
      return NotFound();
    }

    _db.Animals.Remove(animal);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}