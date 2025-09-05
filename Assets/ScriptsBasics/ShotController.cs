using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotController : MonoBehaviour
{
    [SerializeField] private float FocePw = 10.0f;       //弾の飛ばす強さ
    [SerializeField] private GameObject FirePos;        //発射位置
    [SerializeField] private GameObject bulletPrefab;   //弾Obj

    
    public void OnShto(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Shot();
        }
      
    }


    private void Start()
    {
        
    }

    void Shot()
    {
        //発射位置
        var setPos = FirePos.transform.position;
        //弾を一つ生成
        GameObject bullets = Instantiate(bulletPrefab,new Vector3(setPos.x,setPos.y,setPos.z),bulletPrefab.transform.rotation);
        //生成された弾のRigidBodyの習得
        Rigidbody  rb = bullets.GetComponent<Rigidbody>();
        //弾を前方に飛ばす
        rb.AddForce(bulletPrefab.transform.forward * FocePw,ForceMode.Impulse);
    }
        
}
