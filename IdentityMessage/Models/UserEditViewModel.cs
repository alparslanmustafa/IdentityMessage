using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace IdentityMessage.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir")]
        [StringLength(20,ErrorMessage ="Lütfen en fazla 20 karakter giriniz")]
        [DisplayName("Kullanıcının Adı")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [DisplayName("Kullanıcının Soyadı")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Email alanı gereklidir")]
        [DisplayName("Kullanıcının Emaili")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı gereklidir")]
        [DisplayName("Kullanıcının telefon numarası")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [DisplayName("Kullanıcının Şifresi")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [DisplayName("Kullanıcının Şifresi Tekrar")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Görsel gereklidir")]
        [DisplayName("Kullanıcının Görseli")]
        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }
    }
}
