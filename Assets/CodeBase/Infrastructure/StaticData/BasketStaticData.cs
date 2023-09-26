using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Baskets", fileName = nameof(BasketStaticData))]
    public class BasketStaticData : ScriptableObject
    {
        public BasketTypeID _basketTypeID;
        public AssetReferenceGameObject PrefabReference;
    }
}