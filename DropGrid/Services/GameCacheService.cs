using DropGrid.Extensions;
using DropGrid.Logic;
using DropGrid.Models;

namespace DropGrid.Services
{
    public interface IGameCacheService
    {
        List<string> GameList { get; }
        List<Grid> AllGames { get; }

        Grid LoadGame(Guid uuid);
    }

    public class GameCacheService : IGameCacheService
    {
        private Dictionary<string, Grid> ActiveGames { get; set; } = new Dictionary<string, Grid>();

        public List<string> GameList => ActiveGames.Select(g => g.Key).ToList();
        public List<Grid> AllGames   => ActiveGames.Select(a => a.Value).ToList();

        public Grid LoadGame(Guid uuid)
        {
            var id = uuid.ToString();

            if (ActiveGames.ContainsKey(id))
            {
                var grid = ActiveGames[id];

                return grid;
            }

            var fresh = new Grid(5, 12);

            ActiveGames[id] = fresh;

            return fresh;
        }
    }
}
