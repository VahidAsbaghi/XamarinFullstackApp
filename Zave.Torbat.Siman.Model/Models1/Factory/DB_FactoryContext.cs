using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zave.Torbat.Siman.Model.Models1.Factory
{
    public partial class DB_FactoryContext : DbContext
    {
        public DB_FactoryContext()
        {
        }

        public DB_FactoryContext(DbContextOptions<DB_FactoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TBakhsh> TBakhsh { get; set; }
        public virtual DbSet<TBlockCars> TBlockCars { get; set; }
        public virtual DbSet<TCarType> TCarType { get; set; }
        public virtual DbSet<TCard> TCard { get; set; }
        public virtual DbSet<TCarsCement> TCarsCement { get; set; }
        public virtual DbSet<TChopper> TChopper { get; set; }
        public virtual DbSet<TCity> TCity { get; set; }
        public virtual DbSet<TCountry> TCountry { get; set; }
        public virtual DbSet<TDestination> TDestination { get; set; }
        public virtual DbSet<TInputBar> TInputBar { get; set; }
        public virtual DbSet<TInputBarNew> TInputBarNew { get; set; }
        public virtual DbSet<TLevelAccess> TLevelAccess { get; set; }
        public virtual DbSet<TNewDrivers> TNewDrivers { get; set; }
        public virtual DbSet<TNewTerminals> TNewTerminals { get; set; }
        public virtual DbSet<TPaletCount> TPaletCount { get; set; }
        public virtual DbSet<TProvince> TProvince { get; set; }
        public virtual DbSet<TSabtEtahvil> TSabtEtahvil { get; set; }
        public virtual DbSet<TSentry> TSentry { get; set; }
        public virtual DbSet<TShiftCar> TShiftCar { get; set; }
        public virtual DbSet<TSms> TSms { get; set; }
        public virtual DbSet<TTag> TTag { get; set; }
        public virtual DbSet<TTempStart> TTempStart { get; set; }
        public virtual DbSet<TTerminals> TTerminals { get; set; }
        public virtual DbSet<TTruck> TTruck { get; set; }
        public virtual DbSet<TTruckTurn> TTruckTurn { get; set; }
        public virtual DbSet<TTruckType> TTruckType { get; set; }
        public virtual DbSet<TUsers> TUsers { get; set; }
        public virtual DbSet<TVersion> TVersion { get; set; }
        public virtual DbSet<TWBlock> TWBlock { get; set; }
        public virtual DbSet<TWCarType> TWCarType { get; set; }
        public virtual DbSet<TWContractor> TWContractor { get; set; }
        public virtual DbSet<TWDComp> TWDComp { get; set; }
        public virtual DbSet<TWDrivre> TWDrivre { get; set; }
        public virtual DbSet<TWGroup> TWGroup { get; set; }
        public virtual DbSet<TWLoads> TWLoads { get; set; }
        public virtual DbSet<TWSComp> TWSComp { get; set; }
        public virtual DbSet<TWTempWeigh> TWTempWeigh { get; set; }
        public virtual DbSet<TWWeighings> TWWeighings { get; set; }
        public virtual DbSet<TWeighingNumbers> TWeighingNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //192.168.100.94
                optionsBuilder.UseSqlServer("Data Source=tcp: 78.38.134.2,13121;Initial Catalog=DB_Factory;User ID=loading;Password=123#@!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(e => e.UserId);
            modelBuilder.Entity<TBakhsh>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Bakhsh");

                entity.Property(e => e.Row)
                    .HasColumnName("row")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TBlockCars>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_BlockCars");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Reson)
                    .HasColumnName("reson")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<TCarType>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_CarType");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCard>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Card");

                entity.Property(e => e.Cansel).HasColumnName("cansel");

                entity.Property(e => e.IdCard)
                    .HasColumnName("id_card")
                    .HasMaxLength(50);

                entity.Property(e => e.NumCard)
                    .HasColumnName("num_card")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TCarsCement>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_CarsCement");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.CarType)
                    .HasColumnName("car_type")
                    .HasMaxLength(50);

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.Province).HasColumnName("province");
            });

            modelBuilder.Entity<TChopper>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Chopper");

                entity.Property(e => e.AntNum).HasColumnName("ant_num");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Delete).HasColumnName("delete");

                entity.Property(e => e.Destination).HasColumnName("destination");

                entity.Property(e => e.Loads)
                    .HasColumnName("loads")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TruckCode)
                    .HasColumnName("truck_code")
                    .HasMaxLength(10);

                entity.Property(e => e.W).HasColumnName("w");
            });

            modelBuilder.Entity<TCity>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_City");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");
            });

            modelBuilder.Entity<TCountry>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Country");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TDestination>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Destination");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TInputBar>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_InputBar");

                entity.Property(e => e.Bakhsh)
                    .HasColumnName("bakhsh")
                    .HasMaxLength(50);

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.Cansel).HasColumnName("cansel");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.CarCode)
                    .HasColumnName("car_code")
                    .HasMaxLength(50);

                entity.Property(e => e.CarType)
                    .HasColumnName("car_type")
                    .HasMaxLength(50);

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.CrmCodeB).HasColumnName("crm_code_b");

                entity.Property(e => e.CrmCodeC).HasColumnName("crm_code_c");

                entity.Property(e => e.CustomMobail)
                    .HasColumnName("custom_mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.DisEdit)
                    .HasColumnName("dis_edit")
                    .HasMaxLength(150);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Haml)
                    .HasColumnName("haml")
                    .HasMaxLength(20);

                entity.Property(e => e.Havale)
                    .HasColumnName("havale")
                    .HasMaxLength(50);

                entity.Property(e => e.In).HasColumnName("in_");

                entity.Property(e => e.Loading).HasColumnName("loading");

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.NameBoss)
                    .HasColumnName("name_boss")
                    .HasMaxLength(300);

                entity.Property(e => e.Nobat).HasColumnName("nobat");

                entity.Property(e => e.NumCertificates)
                    .HasColumnName("num_Certificates")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Out).HasColumnName("out_");

                entity.Property(e => e.PS).HasColumnName("P_S");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");

                entity.Property(e => e.RowSale).HasColumnName("row_sale");

                entity.Property(e => e.Saderat).HasColumnName("saderat");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Takhlieh)
                    .HasColumnName("takhlieh")
                    .HasMaxLength(150);

                entity.Property(e => e.Terminal)
                    .HasColumnName("terminal")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(10);

                entity.Property(e => e.TimeTakhlie)
                    .HasColumnName("time_takhlie")
                    .HasMaxLength(20);

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(300);

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);

                entity.Property(e => e.Zarfiat).HasColumnName("zarfiat");
            });

            modelBuilder.Entity<TInputBarNew>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_InputBar_New");

                entity.Property(e => e.Bakhsh)
                    .HasColumnName("bakhsh")
                    .HasMaxLength(50);

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.Cansel).HasColumnName("cansel");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.CarCode)
                    .HasColumnName("car_code")
                    .HasMaxLength(50);

                entity.Property(e => e.CarType)
                    .HasColumnName("car_type")
                    .HasMaxLength(50);

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.CrmCodeB).HasColumnName("crm_code_b");

                entity.Property(e => e.CrmCodeC).HasColumnName("crm_code_c");

                entity.Property(e => e.CustomMobail)
                    .HasColumnName("custom_mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.DisEdit)
                    .HasColumnName("dis_edit")
                    .HasMaxLength(150);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Haml)
                    .HasColumnName("haml")
                    .HasMaxLength(20);

                entity.Property(e => e.Havale)
                    .HasColumnName("havale")
                    .HasMaxLength(50);

                entity.Property(e => e.In).HasColumnName("in_");

                entity.Property(e => e.Loading).HasColumnName("loading");

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.NameBoss)
                    .HasColumnName("name_boss")
                    .HasMaxLength(300);

                entity.Property(e => e.Nobat).HasColumnName("nobat");

                entity.Property(e => e.NumCertificates)
                    .HasColumnName("num_Certificates")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Out).HasColumnName("out_");

                entity.Property(e => e.PS).HasColumnName("P_S");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");

                entity.Property(e => e.RowSale).HasColumnName("row_sale");

                entity.Property(e => e.Saderat).HasColumnName("saderat");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Takhlieh)
                    .HasColumnName("takhlieh")
                    .HasMaxLength(150);

                entity.Property(e => e.Terminal)
                    .HasColumnName("terminal")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(10);

                entity.Property(e => e.TimeTakhlie)
                    .HasColumnName("time_takhlie")
                    .HasMaxLength(20);

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(300);

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);

                entity.Property(e => e.Zarfiat).HasColumnName("zarfiat");
            });

            modelBuilder.Entity<TLevelAccess>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_LevelAccess");

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.A1).HasColumnName("a1");

                entity.Property(e => e.A10).HasColumnName("a10");

                entity.Property(e => e.A11).HasColumnName("a11");

                entity.Property(e => e.A12).HasColumnName("a12");

                entity.Property(e => e.A13).HasColumnName("a13");

                entity.Property(e => e.A14).HasColumnName("a14");

                entity.Property(e => e.A15).HasColumnName("a15");

                entity.Property(e => e.A16).HasColumnName("a16");

                entity.Property(e => e.A17).HasColumnName("a17");

                entity.Property(e => e.A18).HasColumnName("a18");

                entity.Property(e => e.A19).HasColumnName("a19");

                entity.Property(e => e.A2).HasColumnName("a2");

                entity.Property(e => e.A20).HasColumnName("a20");

                entity.Property(e => e.A21).HasColumnName("a21");

                entity.Property(e => e.A22).HasColumnName("a22");

                entity.Property(e => e.A23).HasColumnName("a23");

                entity.Property(e => e.A24).HasColumnName("a24");

                entity.Property(e => e.A25).HasColumnName("a25");

                entity.Property(e => e.A26).HasColumnName("a26");

                entity.Property(e => e.A27).HasColumnName("a27");

                entity.Property(e => e.A28).HasColumnName("a28");

                entity.Property(e => e.A29).HasColumnName("a29");

                entity.Property(e => e.A3).HasColumnName("a3");

                entity.Property(e => e.A30).HasColumnName("a30");

                entity.Property(e => e.A31).HasColumnName("a31");

                entity.Property(e => e.A32).HasColumnName("a32");

                entity.Property(e => e.A33).HasColumnName("a33");

                entity.Property(e => e.A34).HasColumnName("a34");

                entity.Property(e => e.A35).HasColumnName("a35");

                entity.Property(e => e.A36).HasColumnName("a36");

                entity.Property(e => e.A37).HasColumnName("a37");

                entity.Property(e => e.A38).HasColumnName("a38");

                entity.Property(e => e.A39).HasColumnName("a39");

                entity.Property(e => e.A4).HasColumnName("a4");

                entity.Property(e => e.A40).HasColumnName("a40");

                entity.Property(e => e.A5).HasColumnName("a5");

                entity.Property(e => e.A6).HasColumnName("a6");

                entity.Property(e => e.A7).HasColumnName("a7");

                entity.Property(e => e.A8).HasColumnName("a8");

                entity.Property(e => e.A9).HasColumnName("a9");

                entity.Property(e => e.Dateedit)
                    .HasColumnName("dateedit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discr)
                    .HasColumnName("discr")
                    .HasMaxLength(100);

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TNewDrivers>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_New_Drivers");

                entity.Property(e => e.CertificateDate).HasColumnType("date");

                entity.Property(e => e.CertificateNum).HasMaxLength(20);

                entity.Property(e => e.DriverName).HasMaxLength(100);

                entity.Property(e => e.EditeDate).HasColumnType("datetime");

                entity.Property(e => e.EditeMan).HasMaxLength(100);

                entity.Property(e => e.HooshmandDate).HasColumnType("date");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.NationalCode).HasMaxLength(20);

                entity.Property(e => e.SalamatDate).HasColumnType("date");
            });

            modelBuilder.Entity<TNewTerminals>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_NewTerminals");

                entity.Property(e => e.DeleteNobat).HasColumnName("delete_nobat");

                entity.Property(e => e.EditeDate).HasMaxLength(100);

                entity.Property(e => e.EditeMan).HasMaxLength(100);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NoeBigbag).HasColumnName("NOE_Bigbag");

                entity.Property(e => e.NoeClinker).HasColumnName("NOE_Clinker");

                entity.Property(e => e.NoeFale).HasColumnName("NOE_Fale");

                entity.Property(e => e.NoePakati).HasColumnName("NOE_Pakati");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TPaletCount>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_PaletCount");

                entity.Property(e => e.Row).ValueGeneratedOnAdd();

                entity.Property(e => e.Palet).HasColumnName("palet");

                entity.Property(e => e.Sandugh).HasColumnName("sandugh");
            });

            modelBuilder.Entity<TProvince>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Province");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TSabtEtahvil>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_SabtETahvil");

                entity.Property(e => e.Bakhsh)
                    .HasColumnName("bakhsh")
                    .HasMaxLength(50);

                entity.Property(e => e.Barbari)
                    .HasColumnName("barbari")
                    .HasMaxLength(50);

                entity.Property(e => e.BaskoolNumber)
                    .HasColumnName("baskool_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Cansel).HasColumnName("cansel");

                entity.Property(e => e.CarCode)
                    .HasColumnName("car_code")
                    .HasMaxLength(50);

                entity.Property(e => e.CarType)
                    .HasColumnName("car_type")
                    .HasMaxLength(50);

                entity.Property(e => e.Card)
                    .HasColumnName("card")
                    .HasMaxLength(50);

                entity.Property(e => e.CementName)
                    .HasColumnName("cement_name")
                    .HasMaxLength(20);

                entity.Property(e => e.CityCode).HasColumnName("city_code");

                entity.Property(e => e.CountPakat).HasColumnName("count_pakat");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.CrmCodeB).HasColumnName("crm_code_b");

                entity.Property(e => e.CrmCodeC).HasColumnName("crm_code_c");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Date2)
                    .HasColumnName("date2")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateHavale)
                    .HasColumnName("date_havale")
                    .HasColumnType("date");

                entity.Property(e => e.DateWeight1)
                    .HasColumnName("date_weight1")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateWeight2)
                    .HasColumnName("date_weight2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.DisEdit)
                    .HasColumnName("dis_edit")
                    .HasMaxLength(150);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.Error)
                    .HasColumnName("error")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar2)
                    .HasColumnName("karbar2")
                    .HasMaxLength(50);

                entity.Property(e => e.Loading)
                    .HasColumnName("loading")
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

                entity.Property(e => e.Nobat).HasColumnName("nobat");

                entity.Property(e => e.NumBarname).HasColumnName("num_barname");

                entity.Property(e => e.NumBarname2)
                    .HasColumnName("num_barname2")
                    .HasMaxLength(100);

                entity.Property(e => e.Ok).HasColumnName("ok");

                entity.Property(e => e.OkOut).HasColumnName("ok_out");

                entity.Property(e => e.PS).HasColumnName("P_S");

                entity.Property(e => e.Palet).HasColumnName("palet");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");

                entity.Property(e => e.Rayvarz)
                    .HasColumnName("rayvarz")
                    .HasMaxLength(50);

                entity.Property(e => e.RowSale).HasColumnName("row_sale");

                entity.Property(e => e.RowTerminal).HasColumnName("row_terminal");

                entity.Property(e => e.Saderat)
                    .HasColumnName("saderat")
                    .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.Takhlieh)
                    .HasColumnName("takhlieh")
                    .HasMaxLength(150);

                entity.Property(e => e.Terminal)
                    .HasColumnName("terminal")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(10);

                entity.Property(e => e.TimeLoading)
                    .HasColumnName("time_loading")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ton).HasColumnName("ton");

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);

                entity.Property(e => e.WeighingLocal1)
                    .HasColumnName("weighing_local1")
                    .HasMaxLength(50);

                entity.Property(e => e.WeighingLocal2)
                    .HasColumnName("weighing_local2")
                    .HasMaxLength(50);

                entity.Property(e => e.Weight1).HasColumnName("weight1");

                entity.Property(e => e.Weight2).HasColumnName("weight2");

                entity.Property(e => e.Weight3).HasColumnName("weight3");

                entity.Property(e => e.Zarfiat).HasColumnName("zarfiat");
            });

            modelBuilder.Entity<TSentry>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Sentry");

                entity.Property(e => e.CarType)
                    .HasColumnName("car_type")
                    .HasMaxLength(50);

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateIn)
                    .HasColumnName("date_in")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOut)
                    .HasColumnName("date_out")
                    .HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(100);

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasMaxLength(50);

                entity.Property(e => e.In).HasColumnName("in_");

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobail)
                    .HasColumnName("mobail")
                    .HasMaxLength(50);

                entity.Property(e => e.Out).HasColumnName("out_");

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.Polomp)
                    .HasColumnName("polomp")
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .HasColumnName("product")
                    .HasMaxLength(50);

                entity.Property(e => e.RowIn)
                    .HasColumnName("row_in")
                    .HasMaxLength(50);

                entity.Property(e => e.Saderat).HasColumnName("saderat");

                entity.Property(e => e.Tozihat)
                    .HasColumnName("tozihat")
                    .HasMaxLength(100);

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TShiftCar>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_ShiftCar");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.Car)
                    .IsRequired()
                    .HasColumnName("car")
                    .HasMaxLength(50);

                entity.Property(e => e.Count).HasColumnName("count");
            });

            modelBuilder.Entity<TSms>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Sms");

                entity.Property(e => e.BigDakheli).HasColumnName("big_dakheli");

                entity.Property(e => e.BigSaderat).HasColumnName("big_saderat");

                entity.Property(e => e.Domain)
                    .HasColumnName("domain")
                    .HasMaxLength(50);

                entity.Property(e => e.FaleDakheli).HasColumnName("fale_dakheli");

                entity.Property(e => e.FaleSaderat).HasColumnName("fale_saderat");

                entity.Property(e => e.KilinkerDakheli).HasColumnName("kilinker_dakheli");

                entity.Property(e => e.KilinkerSaderat).HasColumnName("kilinker_saderat");

                entity.Property(e => e.PakatDakheli).HasColumnName("pakat_dakheli");

                entity.Property(e => e.PakatSaderat).HasColumnName("pakat_saderat");

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(50);

                entity.Property(e => e.Paterncode)
                    .HasColumnName("paterncode")
                    .HasMaxLength(50);

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasMaxLength(50);

                entity.Property(e => e.Send)
                    .HasColumnName("send")
                    .HasMaxLength(300);

                entity.Property(e => e.Smsnum)
                    .HasColumnName("smsnum")
                    .HasMaxLength(50);

                entity.Property(e => e.Smspass)
                    .HasColumnName("smspass")
                    .HasMaxLength(50);

                entity.Property(e => e.Smsuser)
                    .HasColumnName("smsuser")
                    .HasMaxLength(50);

                entity.Property(e => e.Terminal)
                    .HasColumnName("terminal")
                    .HasMaxLength(50);

                entity.Property(e => e.Txt1)
                    .HasColumnName("txt1")
                    .HasMaxLength(300);

                entity.Property(e => e.Txt2)
                    .HasColumnName("txt2")
                    .HasMaxLength(300);

                entity.Property(e => e.Txt3)
                    .HasColumnName("txt3")
                    .HasMaxLength(300);

                entity.Property(e => e.Txt4)
                    .HasColumnName("txt4")
                    .HasMaxLength(300);

                entity.Property(e => e.Txt5)
                    .HasColumnName("txt5")
                    .HasMaxLength(300);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TTag>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Tag");

                entity.Property(e => e.Cansel).HasColumnName("cansel");

                entity.Property(e => e.IdTag)
                    .HasColumnName("id_tag")
                    .HasMaxLength(50);

                entity.Property(e => e.NumTag)
                    .HasColumnName("num_tag")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TTempStart>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_TempStart");

                entity.Property(e => e.Row)
                    .HasColumnName("row")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.NumOfStartBigbag).HasColumnName("num_of_start_bigbag");

                entity.Property(e => e.NumOfStartClinker).HasColumnName("num_of_start_clinker");

                entity.Property(e => e.NumOfStartFalleh).HasColumnName("num_of_start_falleh");

                entity.Property(e => e.NumOfStartPakati).HasColumnName("num_of_start_pakati");

                entity.Property(e => e.Terminal)
                    .HasColumnName("terminal")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TTerminals>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Terminals");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TTruck>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Truck");

                entity.Property(e => e.Card).HasMaxLength(50);

                entity.Property(e => e.DriverName).HasMaxLength(100);

                entity.Property(e => e.EditeDate).HasColumnType("datetime");

                entity.Property(e => e.EditeMan).HasMaxLength(100);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(100);

                entity.Property(e => e.InsureDate).HasColumnType("date");

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.NationalCode).HasMaxLength(20);

                entity.Property(e => e.Pelak).HasMaxLength(50);

                entity.Property(e => e.TechDate).HasColumnType("date");

                entity.Property(e => e.Terminal).HasMaxLength(20);

                entity.Property(e => e.Truck).HasMaxLength(50);
            });

            modelBuilder.Entity<TTruckTurn>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_TruckTurn");

                entity.Property(e => e.DateCall1).HasColumnType("datetime");

                entity.Property(e => e.DateCall2).HasColumnType("datetime");

                entity.Property(e => e.DateCall3).HasColumnType("datetime");

                entity.Property(e => e.DateEdit).HasColumnType("datetime");

                entity.Property(e => e.DeletedCall1).HasMaxLength(100);

                entity.Property(e => e.DeletedCall2).HasMaxLength(100);

                entity.Property(e => e.DeletedCall3).HasMaxLength(100);

                entity.Property(e => e.EditeMan).HasMaxLength(100);

                entity.Property(e => e.InsertDateNobat).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(100);

                entity.Property(e => e.Pelak).HasMaxLength(50);

                entity.Property(e => e.Product).HasMaxLength(50);

                entity.Property(e => e.Terminal).HasMaxLength(100);

                entity.Property(e => e.TurnDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TTruckType>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_TruckType");

                entity.Property(e => e.Truck).HasMaxLength(50);
            });

            modelBuilder.Entity<TUsers>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_Users");

                entity.Property(e => e.Row).ValueGeneratedNever();

                entity.Property(e => e.A1).HasColumnName("a1");

                entity.Property(e => e.A10).HasColumnName("a10");

                entity.Property(e => e.A11).HasColumnName("a11");

                entity.Property(e => e.A12).HasColumnName("a12");

                entity.Property(e => e.A13).HasColumnName("a13");

                entity.Property(e => e.A14).HasColumnName("a14");

                entity.Property(e => e.A15).HasColumnName("a15");

                entity.Property(e => e.A16).HasColumnName("a16");

                entity.Property(e => e.A17).HasColumnName("a17");

                entity.Property(e => e.A18).HasColumnName("a18");

                entity.Property(e => e.A19).HasColumnName("a19");

                entity.Property(e => e.A2).HasColumnName("a2");

                entity.Property(e => e.A20).HasColumnName("a20");

                entity.Property(e => e.A21).HasColumnName("a21");

                entity.Property(e => e.A22).HasColumnName("a22");

                entity.Property(e => e.A23).HasColumnName("a23");

                entity.Property(e => e.A24).HasColumnName("a24");

                entity.Property(e => e.A25).HasColumnName("a25");

                entity.Property(e => e.A26).HasColumnName("a26");

                entity.Property(e => e.A27).HasColumnName("a27");

                entity.Property(e => e.A28).HasColumnName("a28");

                entity.Property(e => e.A29).HasColumnName("a29");

                entity.Property(e => e.A3).HasColumnName("a3");

                entity.Property(e => e.A30).HasColumnName("a30");

                entity.Property(e => e.A31).HasColumnName("a31");

                entity.Property(e => e.A32).HasColumnName("a32");

                entity.Property(e => e.A33).HasColumnName("a33");

                entity.Property(e => e.A34).HasColumnName("a34");

                entity.Property(e => e.A35).HasColumnName("a35");

                entity.Property(e => e.A36).HasColumnName("a36");

                entity.Property(e => e.A37).HasColumnName("a37");

                entity.Property(e => e.A38).HasColumnName("a38");

                entity.Property(e => e.A39).HasColumnName("a39");

                entity.Property(e => e.A4).HasColumnName("a4");

                entity.Property(e => e.A40).HasColumnName("a40");

                entity.Property(e => e.A41).HasColumnName("a41");

                entity.Property(e => e.A42).HasColumnName("a42");

                entity.Property(e => e.A43).HasColumnName("a43");

                entity.Property(e => e.A44).HasColumnName("a44");

                entity.Property(e => e.A45).HasColumnName("a45");

                entity.Property(e => e.A46).HasColumnName("a46");

                entity.Property(e => e.A47).HasColumnName("a47");

                entity.Property(e => e.A48).HasColumnName("a48");

                entity.Property(e => e.A49).HasColumnName("a49");

                entity.Property(e => e.A5).HasColumnName("a5");

                entity.Property(e => e.A50).HasColumnName("a50");

                entity.Property(e => e.A51).HasColumnName("a51");

                entity.Property(e => e.A52).HasColumnName("a52");

                entity.Property(e => e.A53).HasColumnName("a53");

                entity.Property(e => e.A54).HasColumnName("a54");

                entity.Property(e => e.A55).HasColumnName("a55");

                entity.Property(e => e.A56).HasColumnName("a56");

                entity.Property(e => e.A57).HasColumnName("a57");

                entity.Property(e => e.A58).HasColumnName("a58");

                entity.Property(e => e.A59).HasColumnName("a59");

                entity.Property(e => e.A6).HasColumnName("a6");

                entity.Property(e => e.A60).HasColumnName("a60");

                entity.Property(e => e.A61).HasColumnName("a61");

                entity.Property(e => e.A62).HasColumnName("a62");

                entity.Property(e => e.A63).HasColumnName("a63");

                entity.Property(e => e.A64).HasColumnName("a64");

                entity.Property(e => e.A65).HasColumnName("a65");

                entity.Property(e => e.A66).HasColumnName("a66");

                entity.Property(e => e.A67).HasColumnName("a67");

                entity.Property(e => e.A68).HasColumnName("a68");

                entity.Property(e => e.A69).HasColumnName("a69");

                entity.Property(e => e.A7).HasColumnName("a7");

                entity.Property(e => e.A70).HasColumnName("a70");

                entity.Property(e => e.A71).HasColumnName("a71");

                entity.Property(e => e.A72).HasColumnName("a72");

                entity.Property(e => e.A73).HasColumnName("a73");

                entity.Property(e => e.A74).HasColumnName("a74");

                entity.Property(e => e.A75).HasColumnName("a75");

                entity.Property(e => e.A76).HasColumnName("a76");

                entity.Property(e => e.A77).HasColumnName("a77");

                entity.Property(e => e.A78).HasColumnName("a78");

                entity.Property(e => e.A79).HasColumnName("a79");

                entity.Property(e => e.A8).HasColumnName("a8");

                entity.Property(e => e.A80).HasColumnName("a80");

                entity.Property(e => e.A81).HasColumnName("a81");

                entity.Property(e => e.A82).HasColumnName("a82");

                entity.Property(e => e.A83).HasColumnName("a83");

                entity.Property(e => e.A84).HasColumnName("a84");

                entity.Property(e => e.A85).HasColumnName("a85");

                entity.Property(e => e.A9).HasColumnName("a9");

                entity.Property(e => e.Control).HasColumnName("control");

                entity.Property(e => e.Free).HasColumnName("free");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(50);

                entity.Property(e => e.Post)
                    .HasColumnName("post")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TVersion>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_version");

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.Control)
                    .HasColumnName("control")
                    .HasMaxLength(50);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TWBlock>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_Block");

                entity.Property(e => e.Block)
                    .HasColumnName("block")
                    .HasMaxLength(30);

                entity.Property(e => e.CarCode).HasColumnName("car_code");
            });

            modelBuilder.Entity<TWCarType>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_CarType");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TWContractor>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_Contractor");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ToTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TWDComp>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_D_Comp");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ToTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TWDrivre>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_Drivre");

                entity.Property(e => e.CarCode).HasColumnName("car_code");

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Contractor).HasMaxLength(50);

                entity.Property(e => e.DComp)
                    .HasColumnName("D_Comp")
                    .HasMaxLength(50);

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(20);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(20);

                entity.Property(e => e.Loads).HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(50);

                entity.Property(e => e.SComp)
                    .HasColumnName("S_Comp")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TWGroup>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_group");

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.Cancel).HasColumnName("cancel");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .HasColumnName("group_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TWLoads>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_Loads");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ToTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TWSComp>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_S_Comp");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ToTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TWTempWeigh>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_TempWeigh");

                entity.Property(e => e.Baskool)
                    .HasColumnName("baskool")
                    .HasMaxLength(10);

                entity.Property(e => e.Block)
                    .HasColumnName("block")
                    .HasMaxLength(10);

                entity.Property(e => e.CarCode).HasColumnName("car_code");

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.Contractor).HasMaxLength(50);

                entity.Property(e => e.DComp)
                    .HasColumnName("D_Comp")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(30);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50);

                entity.Property(e => e.Loads).HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(30);

                entity.Property(e => e.SComp)
                    .HasColumnName("S_Comp")
                    .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.Property(e => e.W1).HasColumnName("w1");
            });

            modelBuilder.Entity<TWWeighings>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_W_Weighings");

                entity.Property(e => e.Baskool)
                    .HasColumnName("baskool")
                    .HasMaxLength(10);

                entity.Property(e => e.Block)
                    .HasColumnName("block")
                    .HasMaxLength(10);

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.Cansel).HasColumnName("cansel");

                entity.Property(e => e.CarCode).HasColumnName("car_code");

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.Chopper).HasColumnName("chopper");

                entity.Property(e => e.Contractor).HasMaxLength(50);

                entity.Property(e => e.DComp)
                    .HasColumnName("D_Comp")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateEdit)
                    .HasColumnName("date_edit")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.DisEdit)
                    .HasColumnName("dis_edit")
                    .HasMaxLength(150);

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50);

                entity.Property(e => e.Karbar)
                    .HasColumnName("karbar")
                    .HasMaxLength(30);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50);

                entity.Property(e => e.Loads).HasMaxLength(50);

                entity.Property(e => e.Pelak)
                    .HasColumnName("pelak")
                    .HasMaxLength(30);

                entity.Property(e => e.SComp)
                    .HasColumnName("S_Comp")
                    .HasMaxLength(50);

                entity.Property(e => e.Time1)
                    .HasColumnName("time1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Time2)
                    .HasColumnName("time2")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEdit)
                    .HasColumnName("user_edit")
                    .HasMaxLength(50);

                entity.Property(e => e.W1).HasColumnName("w1");

                entity.Property(e => e.W2).HasColumnName("w2");

                entity.Property(e => e.W3).HasColumnName("w3");
            });

            modelBuilder.Entity<TWeighingNumbers>(entity =>
            {
                entity.HasKey(e => e.Row);

                entity.ToTable("T_WeighingNumbers");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(20);
            });
        }
    }
}
