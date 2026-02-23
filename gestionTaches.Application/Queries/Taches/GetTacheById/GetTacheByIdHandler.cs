using gestionTaches.Application.Queries.Taches.GetTaches;
using gestionTaches.Contracts.Responses;
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
            throw new Exception("Aucune Tache correspondante");
        }
        return tache.Adapt<GetTacheByIdResponse>();
    }
}