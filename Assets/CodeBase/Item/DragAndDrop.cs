using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Item
{
    public class DragAndDrop : MonoBehaviour, IItems
    {
        [FormerlySerializedAs("_criterion")] [SerializeField] private BasketTypeID _basketTypeID;

        public BasketTypeID BasketTypeID => _basketTypeID;
        private Vector3 _mousePosition;
        private Falling _component;

        private void OnMouseDown()
        {
            _mousePosition = Input.mousePosition - GetMouse();
            _component = GetComponentInParent<Falling>();
            if(_component == null)
                return;
            
            _component.Drugged();
        }

        private void OnMouseDrag()
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
        }

        private void OnMouseUp()
        {
            _component.Dropped();
        }

        private Vector3 GetMouse() =>
            Camera.main.WorldToScreenPoint(transform.position);
    }
}