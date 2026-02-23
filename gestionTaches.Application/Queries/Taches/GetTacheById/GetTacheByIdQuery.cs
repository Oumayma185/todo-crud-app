using gestionTaches.Contracts.Responses;
using MediatR;

namespace gestionTaches.Application.Queries.Taches.GetTacheById;

public record GetTacheByIdQuery(int Id):IRequest<GetTacheByIdResponse>;