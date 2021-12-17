
using Core.Entities.Concretes;
using Entities.Concretes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Concretes.EntityFramework
{
    public class InvoiceManagementDbContext : DbContext 
    {

        public InvoiceManagementDbContext(DbContextOptions<InvoiceManagementDbContext> options) : base(options){ }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<FlatType> FlatTypes { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.Entity<Person>(ConfigurePerson);
            modelBuilder.Entity<Owner>(ConfigureOwner);
            modelBuilder.Entity<Resident>(ConfigureResident);
            modelBuilder.Entity<House>(ConfigureHouse);
            modelBuilder.Entity<Apartment>(ConfigureApartment);
            modelBuilder.Entity<FlatType>(ConfigureFlatType);
            modelBuilder.Entity<InvoiceType>(ConfigureInvoiceType);
            modelBuilder.Entity<Invoice>(ConfigureInvoice);


            base.OnModelCreating(modelBuilder);
        }

        private void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
           
        }


        private void ConfigureOwner(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(ow=> new {ow.PersonId,ow.HouseId});
            builder.HasOne<Person>().WithMany().HasForeignKey(x=>x.PersonId);
            builder.HasOne<House>().WithMany().HasForeignKey(x => x.HouseId);
        }

        private void ConfigureResident(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(x=>x.PersonId);
            builder.HasOne<Person>().WithOne().HasForeignKey<Resident>(x=>x.PersonId);
            builder.HasOne<House>().WithMany().HasForeignKey(x=>x.HouseId);

        }

        private void ConfigureHouse(EntityTypeBuilder<House> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne<Apartment>().WithMany().HasForeignKey(x=>x.ApartmentId);
            builder.HasOne<FlatType>().WithMany().HasForeignKey(x=>x.FlatTypeId);   
        }

        private void ConfigureApartment(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.Id);
        }
        private void ConfigureFlatType(EntityTypeBuilder<FlatType> builder)
        {
            builder.HasKey(x => x.Id);
        }
        private void ConfigureInvoiceType(EntityTypeBuilder<InvoiceType> builder)
        {
            builder.HasKey(x => x.Id);
        }

        private void ConfigureInvoice(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne<InvoiceType>().WithMany().HasForeignKey(x=>x.InvoiceTypeId);
            builder.HasOne<House>().WithMany().HasForeignKey(x=>x.HouseId);
            builder.HasOne<Person>().WithMany().HasForeignKey(x=>x.PayingPersonId);
        }




    }
}
