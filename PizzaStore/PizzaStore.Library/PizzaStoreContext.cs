using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Library
{
    public partial class PizzaStoreContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Cheese> Cheese { get; set; }
        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaHasCheese> PizzaHasCheese { get; set; }
        public virtual DbSet<PizzaHasTopping> PizzaHasTopping { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=adventureworksdb.cxkf3wzoieaw.us-east-2.rds.amazonaws.com; database=adventureworksdb;user id=sqladmin; password=password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "PizzaStore");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.State).HasMaxLength(2);

                entity.Property(e => e.Street).HasMaxLength(150);

                entity.Property(e => e.ZipCode).HasMaxLength(5);
            });

            modelBuilder.Entity<Cheese>(entity =>
            {
                entity.ToTable("Cheese", "PizzaStore");

                entity.Property(e => e.CheeseId).HasColumnName("CheeseID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cheese1)
                    .IsRequired()
                    .HasColumnName("Cheese")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "PizzaStore");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Crust1)
                    .IsRequired()
                    .HasColumnName("Crust")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "PizzaStore");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Address");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "PizzaStore");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.CheeseCheddarCount).HasColumnName("Cheese_Cheddar_Count");

                entity.Property(e => e.CheeseColbyCount).HasColumnName("Cheese_Colby_Count");

                entity.Property(e => e.CheeseMozzarellaCount).HasColumnName("Cheese_Mozzarella_Count");

                entity.Property(e => e.CrustHandTossedCount).HasColumnName("Crust_HandTossed_Count");

                entity.Property(e => e.CrustThickCount).HasColumnName("Crust_Thick_Count");

                entity.Property(e => e.CrustThinCount).HasColumnName("Crust_Thin_Count");

                entity.Property(e => e.SaucePestoCount).HasColumnName("Sauce_Pesto_Count");

                entity.Property(e => e.SauceTomatoCount).HasColumnName("Sauce_Tomato_Count");

                entity.Property(e => e.ToppingGreenPepperCount).HasColumnName("Topping_GreenPepper_Count");

                entity.Property(e => e.ToppingMeatballCount).HasColumnName("Topping_Meatball_Count");

                entity.Property(e => e.ToppingMushroomCount).HasColumnName("Topping_Mushroom_Count");

                entity.Property(e => e.ToppingOnionCount).HasColumnName("Topping_Onion_Count");

                entity.Property(e => e.ToppingPepperoniCount).HasColumnName("Topping_Pepperoni_Count");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "PizzaStore");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Address");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Inventory");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "PizzaStore");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.OrderTime).HasColumnType("datetime2(3)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Location");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PizzaStore");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.SauceId).HasColumnName("SauceID");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Crust");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Order");

                entity.HasOne(d => d.Sauce)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SauceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Sauce");
            });

            modelBuilder.Entity<PizzaHasCheese>(entity =>
            {
                entity.ToTable("PizzaHasCheese", "PizzaStore");

                entity.Property(e => e.PizzaHasCheeseId).HasColumnName("PizzaHasCheeseID");

                entity.Property(e => e.CheeseId).HasColumnName("CheeseID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Cheese)
                    .WithMany(p => p.PizzaHasCheese)
                    .HasForeignKey(d => d.CheeseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaHasCheese_Cheese");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaHasCheese)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaHasCheese_Pizza");
            });

            modelBuilder.Entity<PizzaHasTopping>(entity =>
            {
                entity.ToTable("PizzaHasTopping", "PizzaStore");

                entity.Property(e => e.PizzaHasToppingId).HasColumnName("PizzaHasToppingID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaHasTopping)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaHasTopping_Pizza");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaHasTopping)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaHasTopping_Topping");
            });

            modelBuilder.Entity<Sauce>(entity =>
            {
                entity.ToTable("Sauce", "PizzaStore");

                entity.Property(e => e.SauceId).HasColumnName("SauceID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.Sauce1)
                    .IsRequired()
                    .HasColumnName("Sauce")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "PizzaStore");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.Topping1)
                    .IsRequired()
                    .HasColumnName("Topping")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
