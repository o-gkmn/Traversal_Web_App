using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinnessLayer.ValidationRule.AnnouncementValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen içeriği boş geçmeyin");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapın");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapın");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapın");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 50 karakter veri girişi yapın");
        }
    }
}
