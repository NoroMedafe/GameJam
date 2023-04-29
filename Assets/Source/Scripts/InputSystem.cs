using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";

    private Vector2 _moveDirection;
    public Vector2 MoveDirection => _moveDirection.magnitude > 1 ? _moveDirection.normalized : _moveDirection;

    void Update()
    {
       _moveDirection.x = Input.GetAxis(Horizontal);
       _moveDirection.y = Input.GetAxis(Vertical);
    }
}
