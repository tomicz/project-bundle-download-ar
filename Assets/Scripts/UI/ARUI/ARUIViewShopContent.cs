using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Immersed.UI.ARUI
{
    public class ARUIViewShopContent : ARUIView
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private Transform _downloadHandler;

        public void UpdateData(string itemSpriteLink)
        {
            StartCoroutine(DownloadTexture(itemSpriteLink));
        }

        private IEnumerator DownloadTexture(string url)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
            webRequest.SendWebRequest();
            _downloadHandler.gameObject.SetActive(true);

            while (!webRequest.isDone)
            {
                yield return null;
            }

            if(webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Couln't download texture.");
            }
            else
            {
                _downloadHandler.gameObject.SetActive(false);
                var downloadedTexture = DownloadHandlerTexture.GetContent(webRequest);
                var sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), new Vector2(downloadedTexture.width / 2, downloadedTexture.height / 2));

                UpdateItemImageSprite(sprite);
            }
        }

        private void UpdateItemImageSprite(Sprite sprite) => _itemImage.sprite = sprite;
    }
}