using System;
using Microsoft.EntityFrameworkCore;
namespace ContactManagerAPP.V2.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext (DbContextOptions<ContactContext> options)
            : base(options) 
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Other" }
                );

            modelBuilder.Entity<Contact>().HasData(
                 new Contact
                 {
                     ContactId = 1,
                     FirstName = "Momma",
                     LastName = "Bear",
                     PhoneNumber = "555-555-5555",
                     Email = "MBear@outlook.com",
                     CategoryId = 1,
                     DateAdded = DateTime.Now
                 },
               new Contact
               {
                   ContactId = 2,
                   FirstName = "Buddy",
                   LastName = "Boy",
                   PhoneNumber = "555-555-1234",
                   Email = "Bboy@aol.com",
                   CategoryId = 2,
                   DateAdded = DateTime.Now
               },
               new Contact
               {
                   ContactId = 3,
                   FirstName = "Boss",
                   LastName = "Man",
                   PhoneNumber = "555-555-1050",
                   Email = "BigBoss@yahoo.com",
                   CategoryId = 3,
                   DateAdded = DateTime.Now
               },
               new Contact
               {
                   ContactId = 4,
                   FirstName = "Stranger",
                   LastName = "Danger",
                   PhoneNumber = "555-555-1452",
                   Email = "danger@hotmail.com",
                   CategoryId = 4,
                   DateAdded = DateTime.Now
               }
                );
        }
    }
}
