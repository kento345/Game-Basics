using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{ //前後左右移動
    [SerializeField] private float speed = 10.0f;  //移動速度
    private Vector2 inputVer;                      //X,Y軸の移動入力値を保持

    //-----移動入力-----
    public void OnMove(InputAction.CallbackContext context)
    {
        //X,Y軸の移動入力値の取得
        inputVer = context.ReadValue<Vector2>();
    }

    void Update()
    {
        //移動処理実行
        Move();
    }

    //-----移動処理関数-----
    void Move()
    {
        //入力を3Dに変換
        Vector3 move_ = new Vector3(inputVer.x,0f,inputVer.y) * speed * Time.deltaTime;
        //現在地に移動量の加算
        transform.position += move_;
    }
}
