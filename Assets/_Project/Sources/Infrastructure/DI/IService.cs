using System;
using UnityEngine;

namespace Sources.Infrastructure.DI
{
    public interface IService
    {
        event Action LeftMouseButtonPressed;
        event Action LeftMouseButtonReleased;
        event Action RightMouseButtonPressed;
        event Action RightMouseButtonReleased;
        Vector2 GetScreenMousePosition();
    }
}