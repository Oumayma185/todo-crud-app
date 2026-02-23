namespace gestionTaches.Contracts.Dtos;

public record TacheDto(int Id, int UserId,string Title,string Description,
    bool isDone,DateTime createdAt);