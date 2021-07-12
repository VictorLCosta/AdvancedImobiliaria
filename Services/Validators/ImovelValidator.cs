using AdvancedImobiliaria.Models.Entities;
using FluentValidation;

namespace AdvancedImobiliaria.Services.Validators
{
    public class ImovelValidator : AbstractValidator<Imovel>
    {
        public ImovelValidator()
        {
            RuleFor(x => x.areaComum);
        }
    }
}