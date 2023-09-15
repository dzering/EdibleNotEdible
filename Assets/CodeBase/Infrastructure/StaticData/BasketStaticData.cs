using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Baskets", fileName = nameof(BasketStaticData))]
    public class BasketStaticData : ScriptableObject
    {
        public Criterion Criterion;
    }
}