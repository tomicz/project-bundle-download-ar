using Immersed.Data;
using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BoxCollider))]
    public class ARItem : MonoBehaviour, IARPointerSelect
    {
        private BoxCollider _boxCollider;
        private ARContentPlacerController _arContentPlacerController;
        private FurnitureData _furnitureData;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void SetItemController(ARContentPlacerController arContentPlacerController) => _arContentPlacerController = arContentPlacerController;

        public void SetFurnitureData(FurnitureData furnitureData) => _furnitureData = furnitureData;

        public void OnPointerSelected(Vector2 inputPosition)
        {
            _arContentPlacerController.SetItem(transform);
        }
    }
}