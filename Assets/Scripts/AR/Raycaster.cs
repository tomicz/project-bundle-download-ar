using UnityEngine;

namespace Immersed.AR
{
    public class Raycaster
    {
        public bool IsTargetHit => _isTargethit;
        public Transform target;

        private bool _isTargethit;
        private RaycastHit _hit;

        public Vector3 Cast(Vector3 origin, Vector3 direction, float rayLength, LayerMask whatRayCanHit)
        {
            _isTargethit = HasRayHitSomething(origin, direction, rayLength, whatRayCanHit);

            if (_isTargethit)
            {
                target = _hit.transform;
                return _hit.point;
            }

            return Vector3.zero;
        }

        private bool HasRayHitSomething(Vector3 origin, Vector3 direction, float rayLength, LayerMask layerMask) => Physics.Raycast(origin, direction, out _hit, rayLength, layerMask);
    }
}