using Immersed.Data;
using Immersed.Debugging;
using Immersed.UI.ARUI;
using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BundleDownloader))]
    public class GetAssetBundleController : MonoBehaviour
    {
        [SerializeField] private ARUIViewShop _shop;
        [SerializeField] private CanvasGroup _shopCanvasGroup;
        [SerializeField] private ARContentPlacerController _contentPlacer;
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private ARRaycastDebugger _raycastDebugger;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private LayerMask _interactableMask;

        private BundleDownloader _bundleDownloader;

        private void Awake()
        {
            _bundleDownloader = GetComponent<BundleDownloader>();
        }

        private void OnEnable()
        {
            _shop.OnItemBoughtEvent += HandleOnItemBoughtEvent;
            _contentPlacer.OnContentPlacedEvent += HandleOnBundlePlacedEvent;
        }

        private void OnDisable()
        {
            _shop.OnItemBoughtEvent -= HandleOnItemBoughtEvent;
            _contentPlacer.OnContentPlacedEvent -= HandleOnBundlePlacedEvent;
        }

        public void HandleOnItemBoughtEvent(FurnitureData item)
        {
            _bundleDownloader.GetBundleObject(item.BundleName, OnBundleDownloaded, null);
        }

        private void OnBundleDownloaded(GameObject bundleObject)
        {
            _contentPlacer.SetItem(bundleObject.transform);
            _contentPlacer.Enable();
            _raycastDebugger.enabled = false;
            _arPointer.ShowRaycaster(false);
            _arPointer.ChangeTarget(_groundMask);
        }

        private void HandleOnBundlePlacedEvent(Vector3 placedPosition)
        {
            _raycastDebugger.enabled = true;
            _arPointer.ShowRaycaster(true);
            _arPointer.ChangeTarget(_interactableMask);
            _contentPlacer.Disable();
            _shopCanvasGroup.interactable = true;
        }
    }
}