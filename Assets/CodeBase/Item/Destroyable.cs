using UnityEngine;

namespace CodeBase.Item
{
    public class Destroyable : MonoBehaviour, IDestroyable
    {
        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }
    }
}