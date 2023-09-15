using CodeBase.Baskets;
using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        
        private const string BASKET = "Basket";

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateGameItem(Vector3 position) => 
            _assetProvider.Instantiate(AssetPath.ITEM, position);

        public GameObject CreateBasket(Vector3 position, IProgressService progressService, Criterion criterion)
        {
            GameObject gameObject = _assetProvider.Instantiate(AssetPath.BASKET);
            Basket basket = gameObject.GetComponent<Basket>();
            basket.Construct(progressService, criterion);
            return gameObject;
        }
    }
}
