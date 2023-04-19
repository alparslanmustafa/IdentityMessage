using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IdentityMessage.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını boş geçmeyin.")]
        public string Username { get; set; }
        
        
        [Required(ErrorMessage ="Lütfen şifre kısmını boş geçmeyin.")]
        public string Password { get; set; }
    }
}
