using UnityEngine;

namespace CodeBase.Item
{
    public class DragAndDrop : MonoBehaviour, IItems
    {
        [SerializeField] private Criterion _criterion;

        public Criterion Criterion => _criterion;
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