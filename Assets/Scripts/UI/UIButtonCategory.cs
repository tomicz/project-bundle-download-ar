using System;
using Immersed.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Immersed.UI
{
    public class UIButtonCategory : MonoBehaviour
    {
        public int ButtonIndex => _buttonIndex;
        public Action<int> OnButtonClickedEvent;

        [SerializeField] private TMP_Text _categoryNameText;

        private int _buttonIndex = 0;

        public void SetCategoryName(string name) => _categoryNameText.text = name;

        public void SetIndex(int index) => _buttonIndex = index;

        public void HandleOnClickEvent()
        {
            OnButtonClickedEvent.Invoke(_buttonIndex);
        }
    }
}