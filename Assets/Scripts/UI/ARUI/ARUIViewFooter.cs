using TMPro;
using UnityEngine;

namespace Immersed.UI.ARUI
{
    public class ARUIViewFooter : ARUIView
    {
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private TMP_Text _priceText;

        public void UpdateData(string itemName, float price)
        {
            _itemNameText.text = itemName;
            _priceText.text = "$" + price;
        }

        public void Buy()
        {

        }
    }
}