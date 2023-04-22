using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook_Multi.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int? UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string? Password { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }
}
