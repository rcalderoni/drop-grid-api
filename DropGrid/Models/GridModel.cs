using System;
using System.Text.Json.Serialization;

namespace DropGrid.Models
{
    public class GridModel
    {
        public string Id { get; set; }

        public GridModel(int[,] grid, string? uuid = null) 
        {
            Id   = uuid ?? Guid.NewGuid().ToString();
            Grid = grid;
        }

        [JsonIgnore]
        public int[,] Grid { get; set; }

        // converts to JSON serializable form
        public Dictionary<int, List<int>> JsonGrid 
        { 
            get 
            {
                return Enumerable.Range(0, Grid.GetLength(1))
                        .ToDictionary(
                            x => x,
                            x => Enumerable.Range(0, Grid.GetLength(0))
                                .Select(y => Grid[y, x]).ToList()
                            );
            } 
        }
    }
}
