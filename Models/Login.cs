using System.ComponentModel.DataAnnotations;
namespace WebApplication04G.Models
{
    public class Login
    {
        [Key]
        [DataType(DataType.EmailAddress,ErrorMessage ="Wrong Email Address")]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50),MinLength(3,ErrorMessage ="Min 3 Char Requried")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50), MinLength(3, ErrorMessage = "Min 3 Char Requried")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50), MinLength(3, ErrorMessage = "Min 3 Char Requried")]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password Not Match")]
        public string CPassword { get; set; }

    }
}
