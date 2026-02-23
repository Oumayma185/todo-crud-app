using gestionTaches.Application.Commands.Taches.CreateTache;
using gestionTaches.Application.Commands.Taches.DeleteTache;
using gestionTaches.Domain.Entities;
using gestionTaches.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gestionTaches.Application.Commands.Taches.UpdateTache;

public class UpdateTacheCommandHandler :IRequestHandler<UpdateTacheCommand,Unit>
{
    private readonly TachesDBContext _tachesDbContext;

    public UpdateTacheCommandHandler(TachesDBContext tachesDbContext)
    {
        _tachesDbContext = tachesDbContext;
    }


    public async Task<Unit> Handle(UpdateTacheCommand request, CancellationToken cancellationToken)
    {
        var tacheToUpdate =
            await _tachesDbContext.Taches.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (tacheToUpdate is null)
        {
            throw new Exception();
            
        }

        tacheToUpdate.Description = request.Description;
        tacheToUpdate.Title = request.title;
        tacheToUpdate.IsDone=request.isDone;
        _tachesDbContext.Taches.Update(tacheToUpdate);
        await _tachesDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}