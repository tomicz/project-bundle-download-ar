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

        [Header("Dependencies")]
        [SerializeField] private LineRenderer _lineRenderer;    

        private Raycaster _raycaster;
        private Camera _camera;

        private IARPointerEnter _onPointerEnter;
        private IARPointerExit _onPointerExit;
        private IARPointerSelect _onPointerSelect;
        private IARPointerDrag[] _onPointerDrag;
        private IARPointerUp _onPointerUp;

        private bool _hasEnteredInteraction = false;
        private Vector3 _hitPosition;

        private void Awake()
        {
            _raycaster = new Raycaster();

            // In newer unity versions Camera.main is optimized and this is safe to use in Unity 2020+.
            // Here is the resource that confirms that https://blog.unity.com/technology/new-performance-improvements-in-unity-2020-2
            _camera = Camera.main;
        }

        private void Update()
        {
            _hitPosition = _raycaster.Cast(transform.position + _lineRenderer.GetPosition(0), _camera.transform.forward, _rayLength, _whatIsHitMask);

            if (_raycaster.IsTargetHit)
            {
                RegisterOnPointerEnter();
                OnPointerEnterEvent?.Invoke(_hitPosition);
            }
            else
            {
                RegisterOnPointerExit();
                OnPointerExitEvent?.Invoke();
            }
        }

        public void ChangeTarget(LayerMask layerMask) => _whatIsHitMask = layerMask;

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        public void ShowRaycaster(bool enable) => _lineRenderer.gameObject.SetActive(enable);

        public void RegisterOnPointerSelected(Vector2 inputPosition)
        {
            if(_onPointerSelect != null)
            {
                _onPointerSelect.OnPointerSelected(inputPosition);
            }
        }

        public void RegisterOnPointerDrag(Vector2 inputPosition)
        {
            if (_onPointerDrag.Length > 0)
            {
                foreach (var pointer in _onPointerDrag)
                {
                    pointer.OnPointerDrag(inputPosition);
                }
            }
        }

        public void RegisterOnPointerUp(Vector2 inputPosition)
        {
            if(_onPointerUp != null)
            {
                _onPointerUp.OnPointerUp(inputPosition);
            }
        }

        private void RegisterOnPointerEnter()
        {
            if(_onPointerEnter == null && _onPointerExit == null)
            {
                _onPointerEnter = _raycaster.target.GetComponent<IARPointerEnter>();
                _onPointerExit = _raycaster.target.GetComponent<IARPointerExit>();
                _onPointerSelect = _raycaster.target.GetComponent<IARPointerSelect>();
                _onPointerDrag = _raycaster.target.GetComponents<IARPointerDrag>();
                _onPointerUp = _raycaster.target.GetComponent<IARPointerUp>();

                if (_onPointerEnter != null)
                {
                    if (!_hasEnteredInteraction)
                    {
                        _onPointerEnter.OnPointerEnter();
                        _hasEnteredInteraction = true;
                    }
                }
            }
        }

        private void RegisterOnPointerExit()
        {
            if (_onPointerExit != null)
            {
                if (_hasEnteredInteraction)
                {
                    _onPointerExit.OnPointerExit();
                    _hasEnteredInteraction = false;
                }
            }

            _onPointerEnter = null;
            _onPointerExit = null;
            _onPointerSelect = null;
            _onPointerDrag = null;
        }
    }
}