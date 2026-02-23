using gestionTaches.Application.Commands.Taches.CreateTache;
using gestionTaches.Application.Commands.Taches.DeleteTache;
using gestionTaches.Application.Queries.Taches.GetTacheById;
using gestionTaches.Application.Queries.Taches.GetTaches;
using gestionTaches.Contracts.Requests.Taches;
using MediatR;

namespace gestionTaches.Presentation.Modules;

public static class TachesModule
{
    public static void AddTachesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/taches", async(IMediator mediator, CancellationToken ct) =>
        {
            var taches = await mediator.Send(new GetTachesQuery(), ct);
            return Results.Ok(taches);
        }).WithTags("Taches");
        
        app.MapGet("/api/taches/{id}", async(IMediator mediator,int id, CancellationToken ct) =>
        {
            var tache = await mediator.Send(new GetTacheByIdQuery(id));
            return Results.Ok(tache);
        }).WithTags("Taches");
        
        app.MapPost("/api/taches", async(IMediator mediator, CreateTacheRequest createTacheRequest,
            CancellationToken ct) =>
        {
            var command = new CreateTacheCommand(createTacheRequest.title, createTacheRequest.description);
            var result=await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Taches");
        
        app.MapPut("/api/taches/{id}",async (IMediator mediator ,int id ,UpdateTacheRequest updateTacheRequest
            ,CancellationToken ct) =>
        {
            var command = new UpdateTacheCommand(id,updateTacheRequest.title, updateTacheRequest.Description,updateTacheRequest.isDone);
            var result=await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Taches");
        
        app.MapDelete("/api/taches/{id}",async (IMediator mediator ,int id,CancellationToken ct) =>
        {
            var command = new DeleteTacheCommand(id);
            var result=await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Taches");
    }
    
}