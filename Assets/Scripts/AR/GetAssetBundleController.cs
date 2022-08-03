using Immersed.Data;
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
            bundleObject.AddComponent<ARItem>();
            bundleObject.GetComponent<ARItem>().SetItemController(_contentPlacer);

            _contentPlacer.SetItem(bundleObject.transform);
        }

        private void HandleOnBundlePlacedEvent(Vector3 placedPosition)
        {
            _shopCanvasGroup.interactable = true;
        }
    }
}