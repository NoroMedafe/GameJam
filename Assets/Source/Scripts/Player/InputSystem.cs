using UnityEngine;


public class InputSystem : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";

    private Vector2 _moveDirection;
    public Vector2 MoveDirection => _moveDirection.magnitude > 1 ? _moveDirection.normalized : _moveDirection;

    private Vector2 _mousePosition;
    public Vector2 MousePosition => _mousePosition;

   
    void Update()
    {
       _moveDirection.x = Input.GetAxis(Horizontal);
       _moveDirection.y = Input.GetAxis(Vertical);
       _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

    }
    public Vector2 GetCursorDirection(Transform transform)
    {
        Vector2 heading = (_mousePosition - (Vector2)transform.position);
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;
        return direction;
    }
}
