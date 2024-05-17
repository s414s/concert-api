using Domain.Entities;
using Domain.Enum;
using Infraestructure.Persistence.EntityConfigurator;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventGroup> EventGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventEntityConfigurator());
        modelBuilder.ApplyConfiguration(new GroupEntityConfigurator());

        modelBuilder.Entity<Group>().HasData([
            new Group{ Id = 1, Name = "Los Ramones", CreatedOn = DateTime.UtcNow, ExplicitContent = true, Genre = Genre.Rock, Password = "root" },
            new Group{ Id = 2, Name = "ACDC", CreatedOn = DateTime.UtcNow, ExplicitContent = true, Genre = Genre.Rock, Password = "root" },
            ]);

        modelBuilder.Entity<Event>().HasData([
            new Event{ Id = 1, Name = "boston", ZipCode = "50018", Date = DateTime.UtcNow, Capacity = 100, OnlyAdults = false },
            new Event{ Id = 2, Name = "altamira", ZipCode = "28850", Date = DateTime.UtcNow, Capacity = 200, OnlyAdults = false },
            ]);

        modelBuilder.Entity<EventGroup>().HasData([
            new EventGroup{ Id = 1, GroupId = 1, EventId = 1 },
            new EventGroup{ Id = 2, GroupId = 2, EventId = 1 },
            ]);
    }
}
