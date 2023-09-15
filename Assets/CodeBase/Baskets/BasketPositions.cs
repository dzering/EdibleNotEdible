using UnityEngine;

namespace CodeBase.Baskets
{
    [CreateAssetMenu(menuName = "Basket/Positions", fileName = nameof(BasketPositions))]
    public class BasketPositions : ScriptableObject
    {
        public Vector3 Left;
        public Vector3 Right;
    }
}