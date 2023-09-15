using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Spawners
{
    public class PlaceForInstantiateItem : MonoBehaviour, IGetPosition
    {
        public Vector3 GetPosition()
        {
            var posX = Random.Range(-4f, 4f);
            var posY = transform.position.y;
            return new Vector3(posX, posY, 0);
        }
    }
}