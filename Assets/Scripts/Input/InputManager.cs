using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action OnPointerDownEvent;
    public Action OnPointerHoldEvent;
    public Action OnPointerUpEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDownEvent?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            OnPointerHoldEvent?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnPointerUpEvent?.Invoke();
        }
    }
}