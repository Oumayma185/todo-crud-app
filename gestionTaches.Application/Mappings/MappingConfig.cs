using gestionTaches.Contracts.Responses;
using gestionTaches.Domain.Entities;
using Mapster;

namespace gestionTaches.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Tache>, GetTachesResponse>.NewConfig()
            .Map(dest => dest.TachesDtos, src => src);
        
        TypeAdapterConfig<Tache, GetTacheByIdResponse>.NewConfig()
            .Map(dest => dest.TacheDto, src => src);
    }
}