using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCombinwe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Placetree();

        //Destroy(this);
    }

    //private void Start()
    //{
        //Combine(); 
    //}

    // Update is called once per frame
    void Update()
    {
        Combine();
    }

    void Combine() {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = transform.worldToLocalMatrix * meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        Debug.Log(combine.Length);

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);



        Renderer[] renderers = new Renderer[1];
        renderers[0] = GetComponent<Renderer>();
        LOD[] lods = new LOD[1] { (new LOD(.15f, renderers)) };

        GetComponent<LODGroup>().SetLODs(lods);

        Destroy(this);
    }

    public void Placetree() {
        float offsetValue = 10f;


        Transform[] childTrees = GetComponentsInChildren<Transform>();

        int i = 0;
        while (i < childTrees.Length)
        {
            
            Vector3 offset = new Vector3(Random.Range(-offsetValue, offsetValue), 0f, Random.Range(-offsetValue, offsetValue));
            Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
            Vector3 scale = Vector3.one * Random.Range(0.75f, 1.2f);


            childTrees[i].transform.SetParent(transform);
            childTrees[i].transform.position += offset;
            childTrees[i].transform.eulerAngles = rotation;
            childTrees[i].transform.localScale = scale;
            
            CheckTreePlacement(childTrees[i]);
            i++;
        }

        //Combine();
    }

    private void CheckTreePlacement(Transform tree) { 
        int layerMask = 1 << 7;
        //layerMask = ~layerMask;

        float distance; 
        RaycastHit hit;
        float height = 12.5f * transform.localScale.y;
        Vector3 origin = new Vector3(tree.position.x, tree.position.y + height, tree.position.z);

        //if (Physics.Raycast(origin, -Vector3.up, out hit, 5000f, layerMask))
        if (Physics.Raycast(origin, -tree.up, out hit, 1000f, layerMask))
        {
            //Debug.DrawLine(origin, hit.point, Color.red, 1000f);
            Destroy(tree.gameObject);
        }
        else
        {
            //Debug.DrawRay(origin, -tree.up * 1000f, Color.blue, 1000f);

            //Debug.Log("Mietje");
            //distance = Vector3.Distance(transform.localPosition, hit.point);
            //Debug.Log(distance);
            tree.position = new Vector3(tree.position.x, 0f, tree.position.z);
            //Debug.DrawRay(tree.position, Vector3.up * 100f, Color.yellow, 1000f);
            //Debug.DrawLine(origin, hit.point, Color.yellow, 1000f);
            //Destroy(this);
            //}
        }
    }

}
