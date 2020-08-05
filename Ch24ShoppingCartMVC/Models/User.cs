using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ch24ShoppingCartMVC.Models.DataAccess
{
    [MetadataType(typeof(UserData))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }
    }

    public class UserData {
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username Required!")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required!")]
        [MinLength(8, ErrorMessage = "Atleast 8 characters are required!")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match!") ]
        public string ConfirmPassword { get; set; }
    }
}