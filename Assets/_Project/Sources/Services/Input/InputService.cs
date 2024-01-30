using System;
using UnityEngine;

namespace Sources.Services.Input
{
    public class InputService : IInputService
    {
        private const int _leftMouseButtonIndex = 0;
        private const int _rightMouseButtonIndex = 1;

        public event Action LeftMouseButtonPressed;
        public event Action LeftMouseButtonReleased;
        public event Action RightMouseButtonPressed;
        public event Action RightMouseButtonReleased;

        public void Update()
        {
            LeftMouseButtonHandling();
            RightMouseButtonHandling();
        }

        public Vector2 GetScreenMousePosition() =>
            UnityEngine.Input.mousePosition;

        private void LeftMouseButtonHandling()
        {
            if(UnityEngine.Input.GetMouseButtonDown(_leftMouseButtonIndex))
                LeftMouseButtonPressed?.Invoke();
            else if(UnityEngine.Input.GetMouseButtonUp(_leftMouseButtonIndex))
                LeftMouseButtonReleased?.Invoke();
        }
        
        private void RightMouseButtonHandling()
        {
            if(UnityEngine.Input.GetMouseButtonDown(_rightMouseButtonIndex))
                RightMouseButtonPressed?.Invoke();
            else if(UnityEngine.Input.GetMouseButtonUp(_rightMouseButtonIndex))
                RightMouseButtonReleased?.Invoke();
        }
    }
}