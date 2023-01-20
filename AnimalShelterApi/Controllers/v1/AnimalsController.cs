using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace AnimalShelterApi.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
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

    // NON-MVP: handle string ages and string weights
    // Regex regexMonth = new Regex(@"\d+m");
    // Regex regexNumber = new Regex(@"\d+");
    // Regex regexYear = new Regex(@"\d+y");

    // switch (ageParameter)
    // {
    //   case "less than 6 months":
    //     query = query.AsEnumerable().Where(entry => entry.Age.Contains("m") && (entry.Age.Contains("y") == false) && Int32.Parse(regexNumber.Match(regexMonth.Match(entry.Age).Value).Value) < 6);
    //     query = query.AsQueryable();
    //     break;
    //   case "6 months to 5 years":
    //     query = query.Where(entry => ((entry.Age.Contains("m") && (entry.Age.Contains("y") == false))) || (entry.Age.Contains("m") && (entry.Age.Contains("y"))) && Int32.Parse(regexNumber.Match(regexMonth.Match(entry.Age).Value).Value) >= 6 && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) < 5);
    //     break;
    //   case "5 years to 10 years":
    //     query = query.Where(entry => entry.Age.Contains("y") && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) >= 5 && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) < 10);
    //     break;
    //   case "10 years or older":
    //     query = query.Where(entry => entry.Age.Contains("y") && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) >= 10);
    //     break;
    // }

    // if (weight != null)
    // {
    //   query = query.Where(entry => entry.Weight == weight);
    // }

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