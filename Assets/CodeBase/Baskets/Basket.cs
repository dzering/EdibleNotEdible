using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Baskets
{
    [RequireComponent(typeof(TriggerObserver))]
    public class Basket : MonoBehaviour
    {
        [SerializeField] private Criterion _criterion;
        private PlayerProgress _playerProgress;
        private TriggerObserver _observer;

        public void Construct(IProgressService progressService, Criterion criterion)
        {
            _playerProgress = progressService.PlayerProgress;
            _criterion = criterion;
        }

        private void Awake()
        {
            _observer = GetComponentInChildren<TriggerObserver>();
            _observer.TriggerEnterEvent += Check;
        }

        private void Check(Collider2D obj)
        {
            IItems item = obj.GetComponentInParent<IItems>();
            if (_criterion == item.Criterion)
                Scoring();
            else
                Damaging();
        }

        private void Damaging()
        {
            _playerProgress.Lives.CurrentLives--;
        }

        private void Scoring() =>
            _playerProgress.Scores.CurrentScore++;
    }
}