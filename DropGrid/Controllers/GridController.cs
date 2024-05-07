using DropGrid.Extensions;
using DropGrid.Models;
using DropGrid.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DropGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly IGameCacheService _gameCache;

        public GridController(IGameCacheService gameCache) 
        {
            _gameCache = gameCache;
        }

        [HttpGet("all")]
        public List<string> GetGamesList()
        {
            var games = _gameCache.GameList;

            return games;
        }

        [HttpGet]
        public GridModel Get()
        {
            var id   = Guid.NewGuid();
            var grid = _gameCache.LoadGame(id);

            return grid.ToGridModel(id);
        }

        [HttpGet("{id}")]
        public GridModel Get(Guid id)
        {
            var grid = _gameCache.LoadGame(id);

            return grid.ToGridModel(id);
        }

        [HttpPost("{id}/remove")]
        public GridModel Post(Guid id, [FromBody] List<string> targets)
        {
            var grid = _gameCache.LoadGame(id);

            var parsedTargets = targets.Select(t => ParseTarget(t)).ToArray();

            grid.Remove(parsedTargets);

            grid.Fall();

            return grid.ToGridModel(id);
        }

        private Vector2 ParseTarget(string target)
        {
            var parse = target.Split('-');

            return new Vector2(float.Parse(parse[0]), float.Parse(parse[1]));
        }

        [HttpPut("{id}/drop")]
        public GridModel Put(Guid id, [FromBody] DropModel drop)
        {
            var grid = _gameCache.LoadGame(id);

            grid.Drop(drop.Value, drop.Column);

            return grid.ToGridModel(id);
        }
    }
}
