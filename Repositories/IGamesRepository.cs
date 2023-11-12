using GamesStore.Api.Entities;
namespace GamesStore.Api.Repositories;
public interface IGamesRepository 
{
    void Create(Game game);
    void Delete(int id);
    Game? Get(int id);
    IEnumerable<Game> GetAll();
    void Update(Game game);
}