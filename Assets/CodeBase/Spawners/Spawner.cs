using CodeBase.Factories;
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

        public void Spawn(Vector3 position)
        {
            _gameFactory.CreateGameItem(position);
        }
    }
}