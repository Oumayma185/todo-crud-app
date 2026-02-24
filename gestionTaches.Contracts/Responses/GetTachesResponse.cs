using gestionTaches.Contracts.Dtos;

namespace gestionTaches.Contracts.Responses;

public record GetTachesResponse(List<TacheDto> TachesDtos);
