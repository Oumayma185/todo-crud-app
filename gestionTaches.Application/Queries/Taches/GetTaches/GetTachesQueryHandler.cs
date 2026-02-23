using gestionTaches.Contracts.Responses;
using gestionTaches.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gestionTaches.Application.Queries.Taches.GetTaches;


public class GetTachesQueryHandler: IRequestHandler<GetTachesQuery,GetTachesResponse>
{
    private TachesDBContext _tachesDbContext;

    public GetTachesQueryHandler(TachesDBContext tachesDbContext)
    {
        _tachesDbContext = tachesDbContext;
    }
    public async Task<GetTachesResponse> Handle(GetTachesQuery request, CancellationToken cancellationToken)
    {
        var taches=await _tachesDbContext.Taches.ToListAsync(cancellationToken);
        return taches.Adapt<GetTachesResponse>();
    }
    
    
}