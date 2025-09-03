using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{ //�O�㍶�E�ړ�
    [SerializeField] private float speed = 10.0f;  //�ړ����x
    private Vector2 inputVer;                      //X,Y���̈ړ����͒l��ێ�

    //-----�ړ�����-----
    public void OnMove(InputAction.CallbackContext context)
    {
        //X,Y���̈ړ����͒l�̎擾
        inputVer = context.ReadValue<Vector2>();
    }

    void Update()
    {
        //�ړ��������s
        Move();
    }

    //-----�ړ������֐�-----
    void Move()
    {
        //���͂�3D�ɕϊ�
        Vector3 move_ = new Vector3(inputVer.x,0f,inputVer.y) * speed * Time.deltaTime;
        //���ݒn�Ɉړ��ʂ̉��Z
        transform.position += move_;
    }
}
