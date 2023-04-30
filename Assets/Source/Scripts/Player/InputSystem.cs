using UnityEngine;


public class InputSystem : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private Jeck _jeck;

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
       _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!_jeck.IsJecking)
        {
            if (_moveDirection.x <= -0.5)
            {
                _animations.MoveLeft();
            }
            else if (_moveDirection.x >= 0.5)
            {
                _animations.MoveRight();
            }
            else if (_moveDirection.y <= -0.5)
            {
                _animations.MoveUp();
            }
            else if (_moveDirection.y >= 0.5)
            {
                _animations.MoveDown();
            }
            else if (_moveDirection.y == 0)
            {
                _animations.Stop();
            }
        }

    }
    public Vector2 GetCursorDirection(Transform transform)
    {
        Vector2 heading = (_mousePosition - (Vector2)transform.position);
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;
        return direction;
    }
}
