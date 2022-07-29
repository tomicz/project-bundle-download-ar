using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action OnButtonPressDownEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnButtonPressDownEvent?.Invoke();
        }
    }
}