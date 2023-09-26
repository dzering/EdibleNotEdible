using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Spawners
{
    public class Spawner
    {
        private readonly IGameFactory _gameFactory;
        public Spawner(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public async void SpawnAsync(ItemTypeID typeID, Vector3 position)
        {
            await _gameFactory.CreateGameItemAsync(typeID, position);
        }
    }
}