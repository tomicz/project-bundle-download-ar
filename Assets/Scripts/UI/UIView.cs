using UnityEngine;

namespace Immersed.UI
{
    public class UIView : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);

        public virtual void Hide() => gameObject.SetActive(false);
    }
}