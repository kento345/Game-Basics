using UnityEngine;
using UnityEngine.InputSystem;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Vector2 inputVer;

    Rigidbody rb;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVer = context.ReadValue<Vector2>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 move = new Vector3(inputVer.x, inputVer.y, 0);
        transform.position += move;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }
}
