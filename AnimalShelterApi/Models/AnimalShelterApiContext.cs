using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models;

public class AnimalShelterApiContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }

    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Fireheart", Species = "Cat", Age = "7m", Sex = "Male", Weight = "6.8lbs" },
          new Animal { AnimalId = 2, Name = "Honey Buns", Species = "Cat", Age = "4m", Sex = "Female", Weight = "4.6lbs" },
          new Animal { AnimalId = 3, Name = "Ceecee", Species = "Cat", Age = "6y", Sex = "Female", Weight = "14.9lbs" },
          new Animal { AnimalId = 4, Name = "Clint", Species = "Cat", Age = "10y 8m", Sex = "Male", Weight = "15.8lbs" },
          new Animal { AnimalId = 5, Name = "Lucas", Species = "Dog", Age = "9m", Sex = "Male", Weight = "50lbs" },
          new Animal { AnimalId = 6, Name = "Dexter", Species = "Dog", Age = "2y 2m", Sex = "Male", Weight = "66.4lbs" },
          new Animal { AnimalId = 7, Name = "Forrester", Species = "Dog", Age = "1y 7m", Sex = "Male", Weight = "51.5lbs" },
          new Animal { AnimalId = 8, Name = "Oliver", Species = "Dog", Age = "1y 11m", Sex = "Male", Weight = "63lbs" }
        );
    }
}
