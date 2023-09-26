using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Baskets
{
    [RequireComponent(typeof(TriggerObserver))]
    public class Basket : MonoBehaviour
    {
        [FormerlySerializedAs("_criterion")] [SerializeField] private BasketTypeID _basketTypeID;
        private PlayerProgress _playerProgress;
        private TriggerObserver _observer;

        public void Construct(IProgressService progressService, BasketTypeID basketTypeID)
        {
            _playerProgress = progressService.PlayerProgress;
            _basketTypeID = basketTypeID;
        }

        private void Awake()
        {
            _observer = GetComponentInChildren<TriggerObserver>();
            _observer.TriggerEnterEvent += Check;
        }

        private void Check(Collider2D obj)
        {
            IItems item = obj.GetComponentInParent<IItems>();
            if (_basketTypeID == item.BasketTypeID)
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