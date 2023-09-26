using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Items", fileName = nameof(ItemStaticData))]
    public class ItemStaticData : ScriptableObject
    {
        public ItemTypeID ItemTypeID;
        public AssetReferenceGameObject PrefabReference;
    }
}