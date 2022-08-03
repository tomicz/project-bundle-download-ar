using Immersed.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Immersed.UI.ARUI
{
    public class ARUIViewPopupData : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private Image _colorImage;
        [SerializeField] private TMP_Text _weightText;
        [SerializeField] private TMP_Text _priceText;

        public void Enable(FurnitureData furnitureData)
        {
            gameObject.SetActive(true);
            SetData(furnitureData);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void SetPosition(Vector3 position)
        {
            transform.localPosition = position;
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }

        private void SetData(FurnitureData furnitureData)
        {
            _itemNameText.text = furnitureData.name;
            _colorImage.color = furnitureData.Color;
            _weightText.text = furnitureData.Weight + "kg";
            _priceText.text = "$" + furnitureData.Price;
        }
    }
}