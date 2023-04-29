using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";

    private Vector2 _moveDirection;
    public Vector2 MoveDirection => _moveDirection;

    void Update()
    {
       _moveDirection.x = Input.GetAxis(Horizontal);
       _moveDirection.y = Input.GetAxis(Vertical);
    }
}
