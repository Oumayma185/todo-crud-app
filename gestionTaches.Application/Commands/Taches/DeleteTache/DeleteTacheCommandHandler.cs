using gestionTaches.Contracts.Exceptions;
using gestionTaches.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gestionTaches.Application.Commands.Taches.DeleteTache;

public class DeleteTacheCommandHandler: IRequestHandler<DeleteTacheCommand,Unit>
{
    private readonly TachesDBContext _tachesDbContext;

    public DeleteTacheCommandHandler(TachesDBContext tachesDbContext)
    {
        _tachesDbContext = tachesDbContext;
    }


    public async Task<Unit> Handle(DeleteTacheCommand request, CancellationToken cancellationToken)
    {
        var tacheToDelete =
            await _tachesDbContext.Taches.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (tacheToDelete is null)
        {
            throw new NotFoundException("Aucune tache correspondante");
        }

        _tachesDbContext.Taches.Remove(tacheToDelete);
        await _tachesDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}