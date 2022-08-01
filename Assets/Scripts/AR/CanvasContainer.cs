using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BoxCollider))]
    public class CanvasContainer : MonoBehaviour, IARPointerEnter, IARPointerExit, IARPointerDrag
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform _canvas;
        [SerializeField] private SpriteRenderer _circleSprite;

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

        public void OnPointerDrag(Vector3 position)
        {
            transform.position = new Vector3(position.x, transform.position.y, position.z);
            _canvas.transform.position = new Vector3(position.x, _canvas.transform.position.y, position.z);
        }
    }
}