using MediatR;

namespace gestionTaches.Application.Commands.Taches.DeleteTache;

public record UpdateTacheCommand(int Id,string title, string Description,bool isDone): IRequest<Unit>;

