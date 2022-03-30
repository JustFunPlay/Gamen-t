using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForest : MonoBehaviour
{


    private void Awake()
    {
        Placetree();
    }

    public void Placetree()
    {


        int layerMask = 1 << 7;
        //layerMask = ~layerMask;


        RaycastHit hit;
        float height = 12.5f * transform.localScale.y;
        Vector3 origin = transform.position;
        if (Physics.Raycast(origin, -Vector3.up, out hit, 10000f, layerMask))
        {
            Debug.DrawRay(origin, hit.point, Color.red);
            
            if (hit.transform.tag == "Road")
            {
                Debug.Log("Haaaj");
                Destroy(gameObject);
            }
            
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10000f, transform.position.z);
            Destroy(this);
        }
    }

}
