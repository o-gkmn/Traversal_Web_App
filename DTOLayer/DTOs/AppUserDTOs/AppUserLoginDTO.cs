using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserLoginDTO
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string password { get; set; }
    }
}
