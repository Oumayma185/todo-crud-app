using MediatR;

namespace gestionTaches.Application.Commands.Taches.CreateTache;

public record CreateTacheCommand(string title, string Description): IRequest<int>;
