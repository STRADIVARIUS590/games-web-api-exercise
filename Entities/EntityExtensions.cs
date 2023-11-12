using GamesStore.Api.Dtos;
using GamesStore.Api.Entities;

namespace GameStore.Api.Entities;

public static class EntityExtensions
{
    public static GameDto asDto(this Game game){
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }
}
