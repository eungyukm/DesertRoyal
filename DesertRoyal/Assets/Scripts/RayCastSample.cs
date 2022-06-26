using UnityEngine;

public class RayCastSample : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject Unit;
    public LayerMask LayerMask;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask))
            {
                Vector3 hitPos = hit.point;
                Instantiate(Unit, hitPos, Quaternion.identity);
            }
        }
    }
}
