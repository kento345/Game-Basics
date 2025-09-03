using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    Rigidbody rb;                                     // 自身にアタッチされているRigidbody（物理挙動用）
    [SerializeField] private float JumpPower = 5.0f;  // ジャンプの力（Inspectorから調整可能）
    [SerializeField] private LayerMask groundLayer;   // 「地面」として判定するLayerを指定
    bool isGround = false;                            // 現在、地面にいるかどうかのフラグ


    // ----- ジャンプ入力処理 -----
    // Input Systemで「Jump」アクションが呼ばれた時に実行される
    public void OnJump(InputAction.CallbackContext context)
    {
        // 入力が「performed」状態（押された瞬間）かつ地面にいる場合のみジャンプ可能
        if (context.performed && isGround)
        {
            // 上方向（Vector3.up）に力を加えてジャンプする
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

            // 空中状態に変更（連続ジャンプ防止）
            isGround = false;
        }
    }


    // ----- 初期化処理 -----
    void Start()
    {
        // 自身のRigidbodyを取得
        rb = GetComponent<Rigidbody>();
    }


    // ----- 接触判定 -----
    private void OnCollisionEnter(Collision collision)
    {
        // 接触したオブジェクトのlayerが groundLayer に含まれているか判定
        // 「1 << collision.gameObject.layer」でそのオブジェクトのlayerをビットに変換
        // groundLayer（LayerMask）とのANDを取って0でなければ「地面」とみなす
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGround = true; // 地面に着地したのでフラグをON
        }

        /*
        // ← シンプルに「Ground」という名前のLayer限定で判定したいならこちらでもOK
        //Layerの名前の打ちミスしやすい
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
        */
    }
}
