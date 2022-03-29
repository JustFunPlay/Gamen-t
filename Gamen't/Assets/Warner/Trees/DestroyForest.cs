using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Henk());
    }
    IEnumerator Henk()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Collider>().enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Road")
        {
            Destroy(gameObject);
        }
    }
}
