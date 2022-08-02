using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<Vector2> OnPointerDownEvent;
    public Action<Vector2> OnPointerHoldEvent;
    public Action<Vector2> OnPointerUpEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDownEvent?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            OnPointerHoldEvent?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnPointerUpEvent?.Invoke(Input.mousePosition);
        }
    }
}