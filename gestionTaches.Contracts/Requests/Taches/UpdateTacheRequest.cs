namespace gestionTaches.Contracts.Requests.Taches;

public record UpdateTacheRequest(int Id,string title, string Description,bool isDone);