using UnityEngine;
using UnityEngine.InputSystem;


public class DraggDroppController : MonoBehaviour
{
    

    private GameObject selectObject = null;
    private Vector3 offset;
    private float dragDistance;


    [SerializeField] private LayerMask Dragglayer;

    //-----Ray-----
    private Ray ray;
    private RaycastHit hit;


    public void OnMouse1(InputAction.CallbackContext context)
    {
        // 左クリック
        if (context.performed)
        {
            Dragg();
        }
        // ドラッグ終了
        if (context.canceled)
        {
            selectObject = null;
        }
    }

 


    void Update()
    {
       ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        // ドラッグ中
        if (selectObject != null)
        {
            if (((1 << selectObject.gameObject.layer) & Dragglayer) != 0)
            {
                // DraggLayerのオブジェクトは移動
                Vector3 worldPos = ray.GetPoint(dragDistance);
                selectObject.transform.position = new Vector3(worldPos.x + offset.x,0.5f, worldPos.z + offset.z);
            }
        }
    }

    void Dragg()
    {
        if(Physics.Raycast(ray,out hit))
        {
            if (((1 << hit.collider.gameObject.layer) & Dragglayer) != 0)
            {
                selectObject = hit.collider.gameObject;
                dragDistance = Vector3.Distance(Camera.main.transform.position, selectObject.transform.position);
                var worldPos = ray.GetPoint(dragDistance);
                offset       = selectObject.transform.position - worldPos;
            }
        }
    }
}
