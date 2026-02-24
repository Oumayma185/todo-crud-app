using FluentValidation;
using gestionTaches.Domain.Entities;

namespace gestionTaches.Application.Queries.Taches.GetTacheById;

public class GetTacheByIdQueryValidator : AbstractValidator<GetTacheByIdQuery>
{
    public GetTacheByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Tache.Id)} aucune tache correspondante");
    }
    
}