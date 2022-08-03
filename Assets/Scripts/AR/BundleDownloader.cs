using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Immersed.AR
{
    public class BundleDownloader : MonoBehaviour
    {
        private const string BundleFolder = "https://firebasestorage.googleapis.com/v0/b/immersed-test.appspot.com/o/AssetBundles%2F";
        private const string Token = "?alt=media&token=b6d1c63d-5e81-412b-ab59-c817842672cb";

        public void GetBundleObject(string assetName, UnityAction<GameObject> callback, Transform bundleParent)
        {
            StartCoroutine(GetDisplayBundleRoutine(assetName, callback, bundleParent));
        }

        private IEnumerator GetDisplayBundleRoutine(string assetName, UnityAction<GameObject> callback, Transform bundleParent)
        {

            string bundleURL = BundleFolder + assetName + "-";

            // Append platform to asset bundle name
#if UNITY_ANDROID
        bundleURL += "Android" + Token;
#else
            bundleURL += "IOS" + Token;
#endif

            //Debug.Log("Requesting bundle at " + bundleURL);

            // Request asset bundle
            UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Network error");
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                if (bundle != null)
                {
                    string rootAssetPath = bundle.GetAllAssetNames()[0];
                    GameObject arObject = Instantiate(bundle.LoadAsset(rootAssetPath) as GameObject);
                    bundle.Unload(false);
                    callback(arObject);
                }
                else
                {
                    Debug.Log("Not a valid asset bundle");
                }
            }
        }
    }
}