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
  public async Task<List<Animal>> Get(string species, string name, string ageParameter, string weight, string sex)
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

    // NON-MVP: handle string ages
    Regex regexMonth = new Regex(@"\d+m");
    Regex regexNumber = new Regex(@"\d+");
    Regex regexYear = new Regex(@"\d+y");

    switch (ageParameter)
    {
      case "less than 6 months":
        query = query.Where(entry => entry.Age.Contains("m") && (entry.Age.Contains("y") == false) && Int32.Parse(regexNumber.Match(regexMonth.Match(entry.Age).Value).Value) < 6);
        break;
      case "6 months to 5 years":
        query = query.Where(entry => ((entry.Age.Contains("m") && (entry.Age.Contains("y") == false))) || (entry.Age.Contains("m") && (entry.Age.Contains("y"))) && Int32.Parse(regexNumber.Match(regexMonth.Match(entry.Age).Value).Value) >= 6 && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) < 5);
        break;
      case "5 years to 10 years":
        query = query.Where(entry => entry.Age.Contains("y") && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) >= 5 && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) < 10);
        break;
      case "10 years or older":
        query = query.Where(entry => entry.Age.Contains("y") && Int32.Parse(regexNumber.Match(regexYear.Match(entry.Age).Value).Value) >= 10);
        break;
    }

    if (weight != null)
    {
      query = query.Where(entry => entry.Weight == weight);
    }

    if (sex != null)
    {
      query = query.Where(entry => entry.Sex == sex);
    }

    return await query.ToListAsync();
  }
}