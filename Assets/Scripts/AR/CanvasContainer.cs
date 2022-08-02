using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BoxCollider))]
    public class CanvasContainer : MonoBehaviour, IARPointerEnter, IARPointerExit, IARPointerDrag
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform _canvas;
        [SerializeField] private SpriteRenderer _circleSprite;
        [SerializeField] private Transform _visualizer;

        [Header("Properties")]
        [SerializeField] private Color _onSelectedColor;

        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = _circleSprite.color;
        }

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void OnPointerEnter()
        {
            _circleSprite.color = _onSelectedColor;
        }

        public void OnPointerExit()
        {
            _circleSprite.color = _defaultColor;
        }

        public void OnPointerDrag(Vector2 inputPosition)
        {
            transform.position = new Vector3(_visualizer.transform.position.x, transform.position.y, _visualizer.transform.position.z);
            _canvas.transform.position = new Vector3(_visualizer.transform.position.x, _canvas.transform.position.y, _visualizer.transform.position.z);
        }
    }
}