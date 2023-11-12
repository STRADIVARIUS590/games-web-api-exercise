using GamesStore.Api.Entities;

namespace GamesStore.Api.Repositories;


public class InMemoryGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new(){
    
    new Game()
    {
        Id = 1,
        Name = "Street Fightter 2",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1999, 2, 1),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 2,
        Name = "Ocarina of time",
        Genre = "Puzzle",
        Price = 13.99M,
        ReleaseDate = new DateTime(1995, 2, 1),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 3,
        Name = "Shin megami tensei",
        Genre = "Puzzle",
        Price = 16.99M,
        ReleaseDate = new DateTime(1991, 2, 1),
        ImageUri = "https://placehold.co/100"
    }};

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id); 
    }

    public void Create (Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;

        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);

    }
}