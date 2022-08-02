using UnityEngine;

namespace Immersed.AR
{
    public class ARRotateTransform : MonoBehaviour, IARPointerDrag, IARPointerSelect
    {
        [SerializeField] private Transform _rotateObject;
        [SerializeField] private float _dragThreshold = 100f;
        [SerializeField] private float _rotationSpeed = 50f;

        private float _firstPressedValue;
        private float _nextDragValue;
        private bool _isRotatingRight = false;

        public void OnPointerDrag(Vector2 inputPosition)
        {
            _nextDragValue = inputPosition.x;

            if (_firstPressedValue + _dragThreshold < _nextDragValue)
            {
                _isRotatingRight = true;

                Rotate(_rotateObject, _isRotatingRight);
            }
            else if (_firstPressedValue + -_dragThreshold > _nextDragValue)
            {
                _isRotatingRight = false;

                Rotate(_rotateObject, _isRotatingRight);
            }
        }

        public void OnPointerSelected(Vector2 inputPosition)
        {
            _firstPressedValue = inputPosition.x;
        }

        private void Rotate(Transform transform, bool rotateRight)
        {
            if (rotateRight)
            {
                transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, -_rotationSpeed * Time.deltaTime, 0));
            }
        }
    }
}