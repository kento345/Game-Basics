using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    Rigidbody rb;                                     // ���g�ɃA�^�b�`����Ă���Rigidbody�i���������p�j
    [SerializeField] private float JumpPower = 5.0f;  // �W�����v�̗́iInspector���璲���\�j
    [SerializeField] private LayerMask groundLayer;   // �u�n�ʁv�Ƃ��Ĕ��肷��Layer���w��
    bool isGround = false;                            // ���݁A�n�ʂɂ��邩�ǂ����̃t���O


    // ----- �W�����v���͏��� -----
    // Input System�ŁuJump�v�A�N�V�������Ă΂ꂽ���Ɏ��s�����
    public void OnJump(InputAction.CallbackContext context)
    {
        // ���͂��uperformed�v��ԁi�����ꂽ�u�ԁj���n�ʂɂ���ꍇ�̂݃W�����v�\
        if (context.performed && isGround)
        {
            // ������iVector3.up�j�ɗ͂������ăW�����v����
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

            // �󒆏�ԂɕύX�i�A���W�����v�h�~�j
            isGround = false;
        }
    }


    // ----- ���������� -----
    void Start()
    {
        // ���g��Rigidbody���擾
        rb = GetComponent<Rigidbody>();
    }


    // ----- �ڐG���� -----
    private void OnCollisionEnter(Collision collision)
    {
        // �ڐG�����I�u�W�F�N�g��layer�� groundLayer �Ɋ܂܂�Ă��邩����
        // �u1 << collision.gameObject.layer�v�ł��̃I�u�W�F�N�g��layer���r�b�g�ɕϊ�
        // groundLayer�iLayerMask�j�Ƃ�AND�������0�łȂ���΁u�n�ʁv�Ƃ݂Ȃ�
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGround = true; // �n�ʂɒ��n�����̂Ńt���O��ON
        }

        /*
        // �� �V���v���ɁuGround�v�Ƃ������O��Layer����Ŕ��肵�����Ȃ炱����ł�OK
        //Layer�̖��O�̑ł��~�X���₷��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
        */
    }
}
