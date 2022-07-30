using UnityEngine;
using TMPro;
using System;

namespace Immersed.UI
{
    public class UIViewConfirmAction : UIView
    {
        [SerializeField] private TMP_Text _description;

        private Action ConfirmAction;
        private Action CancelAction;

        public void Yes()
        {
            ConfirmAction?.Invoke();
            Hide();
        }

        public void No()
        {
            CancelAction?.Invoke();
            Hide();
        }

        public void AddAction(string actionDescription, Action action)
        {
            gameObject.SetActive(true);
            _description.text = actionDescription;
            ConfirmAction = action;
        }
    }
}