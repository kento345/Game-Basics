using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private GameObject models;

    [SerializeField] private float Rotspeed = 100.0f;
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
      
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }
}
