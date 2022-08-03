using Immersed.Data;
using Immersed.UI.ARUI;
using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BoxCollider))]
    public class ARItem : MonoBehaviour, IARPointerSelect, IARPointerEnter, IARPointerExit
    {
        private BoxCollider _boxCollider;
        private ARContentPlacerController _arContentPlacerController;
        private FurnitureData _furnitureData;
        private ARUIViewPopupData _arViewPopupData;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void SetItemController(ARContentPlacerController arContentPlacerController) => _arContentPlacerController = arContentPlacerController;

        public void SetFurnitureData(FurnitureData furnitureData) => _furnitureData = furnitureData;

        public void SetViewPopup(ARUIViewPopupData viewPopupData) => _arViewPopupData = viewPopupData;

        public void OnPointerSelected(Vector2 inputPosition)
        {
            _arViewPopupData.Disable();
            _arContentPlacerController.SetItem(transform);
        }

        public void OnPointerEnter()
        {
            _arViewPopupData.Enable(_furnitureData);
            _arViewPopupData.SetPosition(new Vector3(transform.position.x, transform.position.y + .8f, transform.position.z));
        }

        public void OnPointerExit()
        {
            _arViewPopupData.Disable();
        }
    }
}