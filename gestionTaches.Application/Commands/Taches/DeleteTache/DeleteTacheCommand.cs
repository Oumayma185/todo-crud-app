using MediatR;

namespace gestionTaches.Application.Commands.Taches.DeleteTache;

public record DeleteTacheCommand(int Id):IRequest<Unit>;
