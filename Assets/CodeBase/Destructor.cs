using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase
{
    public class Destructor : MonoBehaviour
    {
        public IProgressService ProgressService;
        public TriggerObserver TriggerObserver;

        public void Awake()
        {
            if (TriggerObserver == null)
                TriggerObserver = GetComponentInChildren<TriggerObserver>();
            TriggerObserver.TriggerEnterEvent += DecreaseLives;
        }

        private void DecreaseLives(Collider2D other)
        {
            if (other.TryGetComponent(out IDestroyable destructible))
            {
                ProgressService.PlayerProgress.Lives.CurrentLives--;
                destructible.Destroy();
            }
                
        }
    }
}


