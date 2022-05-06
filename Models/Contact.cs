using System;
using System.ComponentModel.DataAnnotations;
namespace ContactManagerAPP.V2.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }

        public string Organization { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 4, ErrorMessage ="Please choose a category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public string Slug => 
            FirstName?.Replace(' ', '_').ToLower()
            + LastName?.Replace(' ', '_').ToLower();

    }
}
