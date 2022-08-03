using Immersed.Data;
using TMPro;
using UnityEngine;

namespace Immersed.UI.ARUI
{
    public class ARUIViewPopupData : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMP_Text _itemNameText;
        [SerializeField] private TMP_Text _colorText;
        [SerializeField] private TMP_Text _weightText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Transform _visualizer;

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
            _colorText.text = $"<color=#{ColorUtility.ToHtmlStringRGB(furnitureData.Color)}>color</color>";
            _weightText.text = furnitureData.Weight + "kg";
            _priceText.text = "$" + furnitureData.Price;
        }
    }
}