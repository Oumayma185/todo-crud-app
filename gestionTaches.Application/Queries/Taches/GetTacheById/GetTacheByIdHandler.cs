using gestionTaches.Application.Queries.Taches.GetTaches;
using gestionTaches.Contracts.Exceptions;
using gestionTaches.Contracts.Responses;
using gestionTaches.Domain.Entities;
using gestionTaches.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace gestionTaches.Application.Queries.Taches.GetTacheById;

public class GetTacheByIdHandler : IRequestHandler<GetTacheByIdQuery, GetTacheByIdResponse>
{
    private TachesDBContext _tachesDbContext;

    public GetTacheByIdHandler(TachesDBContext tachesDbContext)
    {
        _tachesDbContext = tachesDbContext;
    }

    public async Task<GetTacheByIdResponse> Handle(GetTacheByIdQuery request, CancellationToken cancellationToken)
    {
        var tache = await _tachesDbContext.Taches
            .FirstOrDefaultAsync(x => x.Id ==request.Id,cancellationToken);
        
        if (tache == null)
        {
            throw new NotFoundException("Aucune Tache correspondante");
           // throw new NotFoundException($"{nameof(tache)}" +
                                       // $"with {nameof(tache.Id)} : {request.Id}" +
                                       // "n'est pas trouvé!");

        }
        return tache.Adapt<GetTacheByIdResponse>();
    }
}