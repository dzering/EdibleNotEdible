using System.Threading.Tasks;
using CodeBase.Baskets;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private const string BASKET = "Basket";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticDataService;
        
        public GameFactory(IAssetProvider assets, IStaticDataService staticDataService)
        {
            _assets = assets;
            _staticDataService = staticDataService;
        }

        public async Task<GameObject> CreateGameItemAsync(ItemTypeID typeID, Vector3 position)
        {
            ItemStaticData itemStaticData = _staticDataService.ForItem(typeID);

            GameObject prefab = await _assets.Load<GameObject>(itemStaticData.PrefabReference);
            
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public GameObject CreateBasket(Vector3 position, IProgressService progressService, BasketTypeID basketTypeID)
        {
            GameObject gameObject = _assets.Instantiate(AssetAddress.BASKET);
            Basket basket = gameObject.GetComponent<Basket>();
            basket.Construct(progressService, basketTypeID);
            return gameObject;
        }
    }
}
