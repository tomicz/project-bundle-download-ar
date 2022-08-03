using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BoxCollider))]
    public class CanvasContainer : MonoBehaviour, IARPointerEnter, IARPointerExit, IARPointerSelect
    {
        [Header("Dependencies")]
        [SerializeField] private SpriteRenderer _circleSprite;
        [SerializeField] private ARContentPlacerController _arContentPlacerController;

        [Header("Properties")]
        [SerializeField] private Color _onSelectedColor;

        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = _circleSprite.color;
        }

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        public void OnPointerEnter()
        {
            _circleSprite.color = _onSelectedColor;
        }

        public void OnPointerExit()
        {
            _circleSprite.color = _defaultColor;
        }

        public void OnPointerSelected(Vector2 inputPosition)
        {
            _arContentPlacerController.SetItem(transform);
        }
    }
}