using UnityEngine;
using UnityEngine.InputSystem;

public class DraggDroppController : MonoBehaviour
{
    private GameObject selectObject = null;
    private Vector3 offset;
    private float dragDistance;
    private float originalY = 1f;

    [SerializeField] private LayerMask Dragglayer;
    private RaycastHit hit;

    
    //-----Ray-----
    private Ray ray;


    public void OnMouse1(InputAction.CallbackContext context)
    {
        // ���N���b�N
        if (context.performed)
        {
            Dragg();
        }
        // �h���b�O�I��
        if (context.canceled)
        {
            selectObject = null;
        }
    }

 


    void Update()
    {
       ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // �h���b�O��
        if (selectObject != null)
        {
            if (((1 << selectObject.gameObject.layer) & Dragglayer) != 0)
            {
                // DraggLayer�̃I�u�W�F�N�g�͈ړ�
                Vector3 worldPos = ray.GetPoint(dragDistance);
                selectObject.transform.position = new Vector3(worldPos.x + offset.x, originalY, worldPos.z + offset.z);

            }
        }
    }

    void MoveObject()
    {

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
