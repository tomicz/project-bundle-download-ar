using System;
using Immersed.AR;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Immersed.UI
{
    public class UIButtonCategory : Button, IARPointerEnter, IARPointerExit, IARPointerSelect
    {
        public int ButtonIndex => _buttonIndex;
        public Action<int> OnButtonClickedEvent;

        [SerializeField] private TMP_Text _categoryNameText;

        private BoxCollider _boxCollider;
        private RectTransform _rectTransform;

        private int _buttonIndex = 0;

        protected override void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rectTransform = GetComponent<RectTransform>();
            image.raycastTarget = false;
            interactable = false;

            MatchColliderWithButton();
        }

        public void SetCategoryName(string name) => _categoryNameText.text = name;

        public void SetIndex(int index) => _buttonIndex = index;

        public void HandleOnClickEvent()
        {
            OnButtonClickedEvent.Invoke(_buttonIndex);
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
            HandleOnClickEvent();
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