using UnityEngine;

namespace CodeBase
{
    public abstract class PlayerScoreBase : MonoBehaviour
    {
        public abstract void Increase();
        public abstract void Decrease();
    }
}