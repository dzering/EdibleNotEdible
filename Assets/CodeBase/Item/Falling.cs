using UnityEngine;

namespace CodeBase.Item
{
    public class Falling : MonoBehaviour
    {
        public float SpeedFall = 0.01f;
        private float _positionY;
        private bool _isDrugged;

        private void Update()
        {
            if (!_isDrugged)
                Fall();
        }

        private void Start() =>
            _positionY = transform.position.y;

        private void Fall()
        {
            _positionY -= Time.deltaTime + SpeedFall;
            transform.position = new Vector3(transform.position.x, _positionY, transform.position.z);
        }

        public void Drugged() =>
            _isDrugged = true;

        public void Dropped()
        {
            _isDrugged = false;
            _positionY = transform.position.y;
        }
    }
}