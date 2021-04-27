using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<SupremePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      builder.Entity<APizza>().HasOne<Crust>().WithMany();
      builder.Entity<APizza>().HasOne<Size>().WithMany();

      OnDataSeeding(builder);
    }

    private void OnDataSeeding(ModelBuilder builder)
    {
      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "Chitown Main Street"}
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "Big Apple"}
      });

      builder.Entity<Customer>().HasData(new Customer[]
      {
        new Customer() { EntityId = 1, Name = "Uncle Sam" }
      });

      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { EntityId = 1, Name = "Original", Price = 5M },
        new Crust() { EntityId = 2, Name = "Thin", Price = 4M },
        new Crust() { EntityId = 3, Name = "Stuffed", Price = 7M },
        new Crust() { EntityId = 4, Name = "Deep Dish", Price = 6M }
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Small", Price = 8M },
        new Size() { EntityId = 2, Name = "Medium", Price = 10M },
        new Size() { EntityId = 3, Name = "Large", Price = 12M }
      });

      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() { EntityId = 1, Name = "Mozzerella", Price = 2M },
        new Topping() { EntityId = 2, Name = "Pepperoni", Price = 3M },
        new Topping() { EntityId = 3, Name = "Bacon", Price = 3M },
        new Topping() { EntityId = 4, Name = "Ham", Price = 3M },
        new Topping() { EntityId = 5, Name = "Sausage", Price = 3M },
        new Topping() { EntityId = 6, Name = "Green Peppers", Price = 1M },
        new Topping() { EntityId = 7, Name = "Olives", Price = 1M },
      });
    }
  }
}