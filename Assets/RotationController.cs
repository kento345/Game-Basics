using UnityEngine;
using UnityEngine.InputSystem;

public class RotationController : MonoBehaviour
{
    [SerializeField] private GameObject model;        //自身のモデル
    [SerializeField] private float Rotspeed = 100.0f;  //回転速度
     
    private Vector2 inputVer;                          //X,Y軸の入力値
    

    public void OnRotate(InputAction.CallbackContext context)
    {
        //X,Y軸の入力値取得
        inputVer = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        //回転
        Rota();
    }

    void Rota()
    {
        //
        Quaternion defaltrot = Quaternion.identity;
        defaltrot *= Quaternion.Euler(-inputVer.y, inputVer.x, 0);
        model.transform.rotation *= defaltrot;
    }
}
