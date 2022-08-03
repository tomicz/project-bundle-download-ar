using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BoxCollider))]
    public class ARItem : MonoBehaviour, IARPointerSelect
    {
        private BoxCollider _boxCollider;
        private ARContentPlacerController _arContentPlacerController;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void SetItemController(ARContentPlacerController arContentPlacerController) => _arContentPlacerController = arContentPlacerController;

        public void OnPointerSelected(Vector2 inputPosition)
        {
            _arContentPlacerController.SetItem(transform);
            _arContentPlacerController.Enable();
        }
    }
}