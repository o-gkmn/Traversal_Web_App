using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinnessLayer.ValidationRule
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız.");
            RuleFor(x => x.Password).Equal(y => y.PasswordConfirm).WithMessage("Şifreler birbiriyle uyuşmuyor.");
        }
    }
}
