using UnityEngine;
using TMPro;
using System;

namespace Immersed.UI
{
    public class UIViewConfirmAction : MonoBehaviour
    {
        [SerializeField] private TMP_Text _description;

        private Action ConfirmAction;
        private Action CancelAction;

        public void Yes()
        {
            ConfirmAction?.Invoke();
            Disable();
        }

        public void No()
        {
            CancelAction?.Invoke();
            Disable();
        }

        public void AddAction(string actionDescription, Action action)
        {
            gameObject.SetActive(true);
            _description.text = actionDescription;
            ConfirmAction = action;
        }

        private void Enable() => gameObject.SetActive(true);

        private void Disable() => gameObject.SetActive(false);
    }
}