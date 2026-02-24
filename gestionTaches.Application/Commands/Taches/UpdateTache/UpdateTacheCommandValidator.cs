using FluentValidation;
using gestionTaches.Application.Commands.Taches.DeleteTache;
using gestionTaches.Domain.Entities;

namespace gestionTaches.Application.Commands.Taches.UpdateTache;

public class UpdateTacheCommandValidator : AbstractValidator<UpdateTacheCommand>
    {
        public UpdateTacheCommandValidator()
        {
            RuleFor(x=>x.title)
                .NotEmpty()
                .WithMessage("Ne peut pas etre vide")
                .MaximumLength(50)
                .WithMessage("Ne peut pas depasser 50 caracteres");
            RuleFor(x=>x.Description)
                .MaximumLength(500)
                .WithMessage("Ne peut pas depasser 500 caracteres");
            RuleFor(x=>x.Id)
                .NotEmpty()
                .WithMessage($"{nameof(Tache.Id)} aucune tache correspondante");
            
        }
        
    }
