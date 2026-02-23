using gestionTaches.Application.Queries.Taches.GetTacheById;
using gestionTaches.Contracts;
using gestionTaches.Domain.Entities;
using gestionTaches.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gestionTaches.Application.Commands.Taches.CreateTache;

public class CreateTacheCommandHandler:IRequestHandler<CreateTacheCommand,int>
{
    private readonly TachesDBContext _tachesDbContext;

    public CreateTacheCommandHandler(TachesDBContext tachesDbContext)
    {
        _tachesDbContext = tachesDbContext;
    }


    public async Task<int> Handle(CreateTacheCommand request, CancellationToken cancellationToken)
    {
        var tache = new Tache
        {
            Title = request.title,
            Description = request.Description,
            CreatedAt =DateTime.Now   
        };
        await _tachesDbContext.Taches.AddAsync(tache,cancellationToken);
        await _tachesDbContext.SaveChangesAsync(cancellationToken);
        return tache.Id;
    }
}