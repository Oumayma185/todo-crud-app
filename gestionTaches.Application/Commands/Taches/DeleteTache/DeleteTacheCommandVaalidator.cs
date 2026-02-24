using FluentValidation;
using gestionTaches.Application.Commands.Taches.CreateTache;
using gestionTaches.Domain.Entities;

namespace gestionTaches.Application.Commands.Taches.DeleteTache;

public class DeleteTacheCommandVaalidator: AbstractValidator<DeleteTacheCommand>
{
    public DeleteTacheCommandVaalidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Tache.Id)} aucune tache correspondante");
    }
}
