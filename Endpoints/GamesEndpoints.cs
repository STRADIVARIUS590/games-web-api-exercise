using GamesStore.Api.Dtos;
using GamesStore.Api.Entities;
using GamesStore.Api.Repositories;
using GameStore.Api.Entities;

namespace GamesStore.Api.Endpoints;

public static class GamesEndpoints 
{


    const string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
                    .WithParameterValidation();

        group.MapGet("/", (IGamesRepository repository) => repository.GetAll().Select(game => game.asDto()));


        group.MapGet("/{id}", (int id, IGamesRepository repository) => 
        {
            Game? game = repository.Get(id);

            return game is not null ? Results.Ok(game.asDto()) : Results.NotFound();

        }).WithName(GetGameEndpointName);

        group.MapPost("/", (CreateGameDto gameDto, IGamesRepository repository) => 
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };
            repository.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id}, game);
        });

        group.MapPut("/{id}", (UpdateGameDto updatedGameDto, int id, IGamesRepository repository) => {

            Game? existingGame = repository.Get(id);

            if(existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            repository.Update(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id, IGamesRepository repository) => {
            
            Game? existingGame = repository.Get(id);

            if(existingGame is not null)
            {
                repository.Delete(id);
            }

            return Results.NoContent();

        });

        return group;
    }
}