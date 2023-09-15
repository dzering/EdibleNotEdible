using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEnterEvent;
        private void OnTriggerEnter2D(Collider2D other)
        {
            TriggerEnterEvent?.Invoke(other);
        }
    }
}