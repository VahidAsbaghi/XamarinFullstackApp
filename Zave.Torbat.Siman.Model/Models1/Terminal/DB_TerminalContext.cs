using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zave.Torbat.Siman.Model.Models1.Terminal
{
    public partial class DB_TerminalContext : DbContext
    {
        public DB_TerminalContext()
        {
        }

        public DB_TerminalContext(DbContextOptions<DB_TerminalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TBar> TBar { get; set; }
        public virtual DbSet<TBarNew> TBarNew { get; set; }
        public virtual DbSet<TBarbari> TBarbari { get; set; }
        public virtual DbSet<TBonker> TBonker { get; set; }
        public virtual DbSet<TCarCost> TCarCost { get; set; }
        public virtual DbSet<TCardName> TCardName { get; set; }
        public virtual DbSet<TCars> TCars { get; set; }
        public virtual DbSet<TCustomers> TCustomers { get; set; }
        public virtual DbSet<TDateSelect> TDateSelect { get; set; }
        public virtual DbSet<TDestination> TDestination { get; set; }
        public virtual DbSet<TDrivers> TDrivers { get; set; }
        public virtual DbSet<TElamBarFalle> TElamBarFalle { get; set; }
        public virtual DbSet<TElamBarPakati> TElamBarPakati { get; set; }
        public virtual DbSet<TNobat> TNobat { get; set; }
        public virtual DbSet<TNobatBonker> TNobatBonker { get; set; }
        public virtual DbSet<TProducts> TProducts { get; set; }
        public virtual DbSet<TShow> TShow { get; set; }
        public virtual DbSet<TTakhalofat> TTakhalofat { get; set; }
        public virtual DbSet<TTon> TTon { get; set; }
        public virtual DbSet<TTypeCar> TTypeCar { get; set; }
        public virtual DbSet<TUsers> TUsers { get; set; }
        public virtual DbSet<Tt> Tt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=tcp: 78.38.134.2,13121;Initial Catalog=DB_Terminal;User ID=loading;Password=123#@!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TBar>(entity =>
            {
                entity.HasKey(e => e.Row)
                    .HasName("PK_T_Bar2");

                entity.ToTable("T_Bar");

                entity.Property(e => e.Bakhsh)
                    .HasColumnName("bakhsh")
                    .HasMaxLength(50);

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.CrmCodeB).HasColumnName("crm_code_b");

                entity.Property(e => e.CrmCodeC).HasColumnName("crm_code_c");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.DateSabt)
                    .HasColumnName("date_sabt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedd).HasColumnName("deletedd");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Haml)
                    .HasColumnName("haml")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.NameBoss)
                    .HasColumnName("name_boss")
                    .HasMaxLength(300);

                entity.Property(e => e.Non).HasColumnName("non");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");

                entity.Property(e => e.RowCustomers).HasColumnName("row_customers");

                entity.Property(e => e.RowSale)
                    .HasColumnName("row_sale")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat).HasColumnName("saderat");

                entity.Property(e => e.SelectTruck).HasColumnName("select_truck");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Takhlieh)
                    .HasColumnName("takhlieh")
                    .HasMaxLength(150);

                entity.Property(e => e.TimeTakhlie)
                    .HasColumnName("time_takhlie")
                    .HasMaxLength(50);

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);

                entity.Property(e => e.UserSabt)
                    .HasColumnName("user_sabt")
                    .HasMaxLength(50);

                entity.Property(e => e.Waybill).HasColumnName("waybill");
            });

            modelBuilder.Entity<TBarNew>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Bar_New");

                entity.Property(e => e.Back).HasColumnName("back");

                entity.Property(e => e.Bakhsh)
                    .HasColumnName("bakhsh")
                    .HasMaxLength(50);

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.CrmCodeB).HasColumnName("crm_code_b");

                entity.Property(e => e.CrmCodeC).HasColumnName("crm_code_c");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.DateSabt)
                    .HasColumnName("date_sabt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedd).HasColumnName("deletedd");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Free).HasColumnName("free");

                entity.Property(e => e.Haml)
                    .HasColumnName("haml")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.NameBoss)
                    .HasColumnName("name_boss")
                    .HasMaxLength(300);

                entity.Property(e => e.Non).HasColumnName("non");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");

                entity.Property(e => e.RowCustomers).HasColumnName("row_customers");

                entity.Property(e => e.RowSale)
                    .HasColumnName("row_sale")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat).HasColumnName("saderat");

                entity.Property(e => e.SelectTruck).HasColumnName("select_truck");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Takhlieh)
                    .HasColumnName("takhlieh")
                    .HasMaxLength(150);

                entity.Property(e => e.Terminal)
                    .HasColumnName("terminal")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeTakhlie)
                    .HasColumnName("time_takhlie")
                    .HasMaxLength(50);

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.TruckType)
                    .HasColumnName("truck_type")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);

                entity.Property(e => e.UserSabt)
                    .HasColumnName("user_sabt")
                    .HasMaxLength(50);

                entity.Property(e => e.Waybill).HasColumnName("waybill");
            });

            modelBuilder.Entity<TBarbari>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_barbari");

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Terminal).HasMaxLength(50);
            });

            modelBuilder.Entity<TBonker>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Bonker");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Bonker).HasColumnName("bonker");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Car)
                    .HasColumnName("car")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Drivers)
                    .HasColumnName("drivers")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Mony)
                    .HasColumnName("mony")
                    .HasMaxLength(50);

                entity.Property(e => e.NameMalek)
                    .HasColumnName("name_malek")
                    .HasMaxLength(50);

                entity.Property(e => e.Nobat).HasColumnName("nobat");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat)
                    .HasColumnName("saderat")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeActive)
                    .HasColumnName("time_active")
                    .HasColumnType("date");

                entity.Property(e => e.TimeFanni)
                    .HasColumnName("time_fanni")
                    .HasColumnType("date");

                entity.Property(e => e.TimeHushmand)
                    .HasColumnName("time_hushmand")
                    .HasColumnType("date");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCarCost>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_CarCost");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.CarName)
                    .HasColumnName("car_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Mony).HasColumnName("mony");

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Ton).HasColumnName("ton");
            });

            modelBuilder.Entity<TCardName>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_CardName");

                entity.Property(e => e.Card).HasColumnName("card");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCars>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Cars");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Bonker).HasColumnName("bonker");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Car)
                    .HasColumnName("car")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Drivers)
                    .HasColumnName("drivers")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Mony)
                    .HasColumnName("mony")
                    .HasMaxLength(50);

                entity.Property(e => e.NameMalek)
                    .HasColumnName("name_malek")
                    .HasMaxLength(50);

                entity.Property(e => e.Nobat).HasColumnName("nobat");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat)
                    .HasColumnName("saderat")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeActive)
                    .HasColumnName("time_active")
                    .HasColumnType("date");

                entity.Property(e => e.TimeFanni)
                    .HasColumnName("time_fanni")
                    .HasColumnType("date");

                entity.Property(e => e.TimeHushmand)
                    .HasColumnName("time_hushmand")
                    .HasColumnType("date");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCustomers>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Customers");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(300);

                entity.Property(e => e.Bakhsh)
                    .HasColumnName("bakhsh")
                    .HasMaxLength(50);

                entity.Property(e => e.Bosscode)
                    .HasColumnName("bosscode")
                    .HasMaxLength(300);

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasMaxLength(150);

                entity.Property(e => e.CrmCode).HasColumnName("crm_code");

                entity.Property(e => e.Delette).HasColumnName("delette");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TDateSelect>(entity =>
            {
                entity.HasKey(e => e.Row)
                    .HasName("PK_T_DateSelect1");

                entity.ToTable("T_DateSelect");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TDestination>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Destination");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TDrivers>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Drivers");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50);

                entity.Property(e => e.Hushmand)
                    .HasColumnName("hushmand")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.NumCertificates)
                    .HasColumnName("num_Certificates")
                    .HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Salamat)
                    .HasColumnName("salamat")
                    .HasMaxLength(50);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeSabt)
                    .HasColumnName("time_sabt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TElamBarFalle>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_ElamBar_falle");

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.Cansel)
                    .HasColumnName("cansel")
                    .HasMaxLength(50);

                entity.Property(e => e.Card)
                    .HasColumnName("card")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(50);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Haml)
                    .HasColumnName("haml")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.NameBoss)
                    .HasColumnName("name_boss")
                    .HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeTakhlie)
                    .HasColumnName("time_takhlie")
                    .HasMaxLength(50);

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(50);

                entity.Property(e => e.Zarfiat).HasColumnName("zarfiat");
            });

            modelBuilder.Entity<TElamBarPakati>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_ElamBar_pakati");

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.Cansel)
                    .HasColumnName("cansel")
                    .HasMaxLength(50);

                entity.Property(e => e.Card)
                    .HasColumnName("card")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Haml)
                    .HasColumnName("haml")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.NameBoss)
                    .HasColumnName("name_boss")
                    .HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeTakhlie)
                    .HasColumnName("time_takhlie")
                    .HasMaxLength(50);

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(50);

                entity.Property(e => e.Zarfiat).HasColumnName("zarfiat");
            });

            modelBuilder.Entity<TNobat>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Nobat");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Bonker).HasColumnName("bonker");

                entity.Property(e => e.Car)
                    .HasColumnName("car")
                    .HasMaxLength(50);

                entity.Property(e => e.Cheng).HasColumnName("cheng");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Hazine).HasColumnName("hazine");

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.NumNobat).HasColumnName("num_nobat");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat)
                    .HasColumnName("saderat")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(50);

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TNobatBonker>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Nobat_Bonker");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Bonker).HasColumnName("bonker");

                entity.Property(e => e.Car)
                    .HasColumnName("car")
                    .HasMaxLength(50);

                entity.Property(e => e.Cheng).HasColumnName("cheng");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Hazine).HasColumnName("hazine");

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.NumNobat).HasColumnName("num_nobat");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat)
                    .HasColumnName("saderat")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(50);

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TProducts>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Products");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TShow>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Show");

                entity.Property(e => e.Deitals)
                    .HasColumnName("deitals")
                    .HasMaxLength(50);

                entity.Property(e => e.Show).HasColumnName("show");
            });

            modelBuilder.Entity<TTakhalofat>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Takhalofat");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.NumCertificates)
                    .HasColumnName("num_Certificates")
                    .HasMaxLength(50);

                entity.Property(e => e.Taahod).HasColumnName("taahod");

                entity.Property(e => e.Takhalof).HasColumnName("takhalof");
            });

            modelBuilder.Entity<TTon>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Ton");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Ton).HasColumnName("ton");
            });

            modelBuilder.Entity<TTypeCar>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_TypeCar");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TUsers>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Users");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Control).HasColumnName("control");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(50);

                entity.Property(e => e.Post)
                    .HasColumnName("post")
                    .HasMaxLength(50);

                entity.Property(e => e.Terminal).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(50);
            });

            modelBuilder.Entity<Tt>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("TT");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50);
            });
        }
    }
}
