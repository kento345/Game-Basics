using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{ //ëOå„ç∂âEà⁄ìÆ
    [SerializeField] private float speed = 10.0f;
    private Vector2 inputVer;


    public void OnMove(InputAction.CallbackContext context)
    {
        inputVer = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 move_ = new Vector3(inputVer.x,0f,inputVer.y) * speed * Time.deltaTime;
        transform.position += move_;
    }
}
