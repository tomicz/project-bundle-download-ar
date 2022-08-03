using Immersed.Data;
using Immersed.UI.ARUI;
using UnityEngine;

namespace Immersed.AR
{
    [RequireComponent(typeof(BundleDownloader))]
    public class GetAssetBundleController : MonoBehaviour
    {
        [SerializeField] private ARUIViewShop _shop;
        [SerializeField] private Transform _downloadHandler;
        [SerializeField] private CanvasGroup _shopCanvasGroup;
        [SerializeField] private ARContentPlacerController _contentPlacer;

        private BundleDownloader _bundleDownloader;
        private FurnitureData _furnitureData;

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

        public void HandleOnItemBoughtEvent(FurnitureData data)
        {
            _furnitureData = data;
            _downloadHandler.gameObject.SetActive(true);
            _bundleDownloader.GetBundleObject(data.BundleName, OnBundleDownloaded, null);
        }

        private void OnBundleDownloaded(GameObject bundleObject)
        {
            bundleObject.AddComponent<ARItem>();

            ARItem arItem = bundleObject.GetComponent<ARItem>();
            arItem.SetItemController(_contentPlacer);
            arItem.SetFurnitureData(_furnitureData);

            _contentPlacer.SetItem(bundleObject.transform);
            _downloadHandler.gameObject.SetActive(false);
        }

        private void HandleOnBundlePlacedEvent(Vector3 placedPosition)
        {
            _shopCanvasGroup.interactable = true;
        }
    }
}