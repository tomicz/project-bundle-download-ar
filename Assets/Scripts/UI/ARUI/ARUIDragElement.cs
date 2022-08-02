using Immersed.AR;
using UnityEngine;
using UnityEngine.UI;

namespace Immersed.UI.ARUI
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(BoxCollider))]
    public class ARUIDragElement : MonoBehaviour, IARPointerSelect, IARPointerUp
    {
        [SerializeField] private Transform _objectToMove;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private Transform _visualizer;

        private BoxCollider _boxCollider;
        private RectTransform _rectTransform;

        private bool _canDrag = false;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rectTransform = GetComponent<RectTransform>();

            MatchColliderWithButton();
        }

        private void Update()
        {
            if (_canDrag)
            {
                float a = _visualizer.transform.position.y;
                float b = a + (_objectToMove.transform.position.y - transform.position.y);

                Vector3 newPosition = new Vector3(_objectToMove.transform.position.x, b, _objectToMove.transform.position.z);

                _objectToMove.transform.position = newPosition;
            }
        }

        public void OnPointerSelected(Vector2 inputPosition)
        {
            if (!_canDrag)
            {
                _canDrag = true;
            }
        }

        public void OnPointerUp(Vector2 inputPosition)
        {
            _canDrag = false;
        }

        private void MatchColliderWithButton()
        {
            Vector3 matchingSize = new Vector3(_rectTransform.rect.width, _rectTransform.rect.height, 0.0001f);
            _boxCollider.size = matchingSize;
            _boxCollider.center = _rectTransform.rect.center;
            _boxCollider.isTrigger = true;
        }
    }
}