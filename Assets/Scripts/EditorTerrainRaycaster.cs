using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorTerrainRaycaster : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    private void OnDrawGizmosSelected()
    {
        int mask = 1 << 8;
        //mask = ~mask;
        Ray ray = new Ray(transform.position + new Vector3(0, 1000f, 0), Vector3.down);
        
        if(Physics.Raycast(ray, out hit, 1100f, mask))
        {
            transform.position = hit.point + new Vector3(0,5,0);
            Debug.Log("hit");
        }
        else
        {
            Debug.Log("Miss");
        }
        Gizmos.DrawWireCube(hit.point, Vector3.one);
        Gizmos.DrawLine(transform.position + new Vector3(0, 1000f, 0), hit.point);

    }

    private void OnDrawGizmos()
    {
        
    }
}
