using FluentValidation;

namespace gestionTaches.Application.Commands.Taches.CreateTache;

public class CreateTacheCommandValidator : AbstractValidator<CreateTacheCommand>
{
    public CreateTacheCommandValidator()
    {
        RuleFor(x=>x.title)
         .NotEmpty()
         .WithMessage("Ne peut pas etre vide")
         .MaximumLength(50)
         .WithMessage("Ne peut pas depasser 50 caracteres");
        RuleFor(x=>x.Description)
            .MaximumLength(500)
            .WithMessage("Ne peut pas depasser 500 caracteres");
    }
}
