using Immersed.AR;
using UnityEngine.UI;
using UnityEngine;

namespace Immersed.UI.ARUI
{
    [RequireComponent(typeof(BoxCollider))]
    public class ARUIButton : Button, IARPointerEnter, IARPointerExit, IARPointerSelect
    {
        private BoxCollider _boxCollider;
        private RectTransform _rectTransform;

        protected override void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rectTransform = GetComponent<RectTransform>();

            MatchColliderWithButton();
        }

        public void OnPointerEnter()
        {
            base.DoStateTransition(SelectionState.Highlighted, false);
        }

        public void OnPointerExit()
        {
            base.DoStateTransition(SelectionState.Normal, false);
        }

        public void OnPointerSelected(Vector2 inputPosition)
        {
            base.DoStateTransition(SelectionState.Pressed, false);
            onClick.Invoke();
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