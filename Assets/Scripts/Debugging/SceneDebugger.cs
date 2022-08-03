using Immersed.AR;
using UnityEngine;

namespace Immersed.UI
{
    public class SceneDebugger : MonoBehaviour
    {
        [SerializeField] private ARPointer _arPointer;
        [SerializeField] private ARContentPlacerController _arContentPlacerController;
        [SerializeField] private CanvasContainer _canvasContainer;
        [SerializeField] private Transform _debugARGround;

        private void Awake()
        {
#if UNITY_EDITOR
            _debugARGround.gameObject.SetActive(true);
#endif
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
      
            }
        }
    }
}