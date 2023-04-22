using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AddressBook_Multi.Areas.Country.Models
{
    public class CountryModel
    {
        public int? CountryID { get; set; }


        [Required(ErrorMessage = "Please Enter Country Name")]
        [DisplayName("Country Name")]
        public string? CountryName { get; set; }


        [Required(ErrorMessage = "Please Enter Country Code")]
        [DataType(DataType.Text)]
        public string? CountryCode { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }
        //public string? PhotoPath { get; set; }   
    }

    public class CountryDropDown
    {
        public int? CountryID { get; set; }

        public string? CountryName { get; set; }
    }
}