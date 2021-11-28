using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleOps.Application.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        [Display(Name = "Tax Id")]
        public string TaxId { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
    }

    public class EmployeeModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lat name is required")]
        public string Lastname { get; set; }
        [Required]
        public DateTime DateJoined { get; set; }
        [Required]
        public AddressModel Address { get; set; }
    }

    public class AddressModel
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}
