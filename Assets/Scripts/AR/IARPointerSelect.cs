using UnityEngine;

namespace Immersed.AR
{
    public interface IARPointerSelect
    {
        void OnPointerSelected(Vector2 inputPosition);
    }
}