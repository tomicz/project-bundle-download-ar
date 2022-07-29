using System;
using UnityEngine;

namespace Immersed.AR
{
    public class ARPointer : MonoBehaviour
    {
        public Action<Vector3> OnPointerEnterEvent;
        public Action OnPointerExitEvent;

        [Header("Raycast properties")]
        [SerializeField] private float _rayLength = 10f;
        [SerializeField] private LayerMask _whatIsHitMask;

        private Raycaster _raycaster;
        private Camera _camera;

        private void Awake()
        {
            _raycaster = new Raycaster();

            // In newer unity versions Camera.main is optimized and this is safe to use in Unity 2020+.
            // Here is the resource that confirms that https://blog.unity.com/technology/new-performance-improvements-in-unity-2020-2
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 hitPosition = _raycaster.Cast(_camera.transform.position, _camera.transform.forward, _rayLength, _whatIsHitMask);

            if (_raycaster.IsTargetHit)
            {
                OnPointerEnterEvent?.Invoke(hitPosition);
            }
            else
            {
                OnPointerExitEvent?.Invoke();
            }
        }

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);
    }
}