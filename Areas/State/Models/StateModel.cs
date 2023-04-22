using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AddressBook_Multi.Areas.State.Models
{
    public class StateModel
    {
        public int? StateID { get; set; }


        [Required(ErrorMessage = "Please Enter State Name")]
        [DisplayName("State Name")]
        public string? StateName { get; set; }


        [Required(ErrorMessage = "Please Enter State Code")]
        [DataType(DataType.Text)]
        public string? StateCode { get; set; }


        [Required(ErrorMessage = "Please Select Country")]
        [DisplayName("Country")]
        public int CountryID { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IFormFile? File { get; set; }
        //public string? PhotoPath { get; set; }
    }

    public class StateDropDown
    {
        public int? StateID { get; set; }

        public string? StateName { get; set; }

    }
}
