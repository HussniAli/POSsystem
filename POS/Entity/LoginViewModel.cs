using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
namespace POS.Entity
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        public bool RememberMe {get;set;}
    }
}