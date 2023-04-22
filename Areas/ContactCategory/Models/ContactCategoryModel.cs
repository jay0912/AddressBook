using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AddressBook_Multi.Areas.ContactCategory.Models
{
    public class ContactCategoryModel
    {
        public int? CategoryID { get; set; }


        [Required(ErrorMessage = "Please Enter Category Name")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }


        //[Required(ErrorMessage = "Please Select Category")]
        //[DisplayName("Category")]
        //public int ContactID { get; set; }

        public IFormFile? File { get; set; }

        //public string? PhotoPath { get; set; }
    }

    public class ContactCategoryDropDown
    {
        public int? CategoryID { get; set; }

        public string? CategoryName { get; set; }

    }

}