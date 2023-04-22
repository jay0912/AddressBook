using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook_Multi.Areas.Contact.Models
{
    public class ContactModel
    {
        public int? ContactID { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [DisplayName("Contact Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Number")]
        [DataType(DataType.PhoneNumber)]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [DataType(DataType.Text)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string? PhotoPath { get; set; }


        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [DisplayName("State")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        [DisplayName("City")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        [DisplayName("Category")]
        public int CategoryID { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }


    }
}
