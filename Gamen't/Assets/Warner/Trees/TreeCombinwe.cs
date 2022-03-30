using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCombinwe : MonoBehaviour
{
    public Transform lowPolyTree;
    public Material lowPolyTreeMaterial;

    private GameObject lowPolyGroup;
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
        CombineLowPoly();
        Combine();
    }

    private void CombineLowPoly() {
        MeshFilter[] meshFilters = lowPolyGroup.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = lowPolyGroup.transform.worldToLocalMatrix * meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        lowPolyGroup.GetComponent<MeshFilter>().mesh = new Mesh();
        lowPolyGroup.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        lowPolyGroup.gameObject.SetActive(true);
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

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);



        Renderer[] highPoly = new Renderer[1];
        Renderer[] lowPoly = new Renderer[1];
        highPoly[0] = GetComponent<Renderer>();
        lowPoly[0] = lowPolyGroup.GetComponent<Renderer>();
        LOD[] lods = new LOD[2] { 
            (new LOD(.5f, highPoly)),
            (new LOD(.15f, lowPoly))
        };

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
            
            // Create low poly tree
            //Transform lowPolyTree = Instantiate(lowPolyTree, )


            i++;
        }

        lowPolyGroup = new GameObject("lowPolyGroup");
        lowPolyGroup.AddComponent<MeshRenderer>();
        lowPolyGroup.AddComponent<MeshFilter>();
        lowPolyGroup.GetComponent<Renderer>().material = lowPolyTreeMaterial;
        lowPolyGroup.transform.SetParent(transform.parent);
        lowPolyGroup.transform.localPosition = this.transform.position;

        int j = 0;
        while (j < childTrees.Length) {
            if (childTrees[j].transform.position != lowPolyGroup.transform.position) {
                Transform newLowPolyTree = Instantiate(lowPolyTree, childTrees[j].transform.position, childTrees[j].transform.rotation);
                newLowPolyTree.transform.SetParent(lowPolyGroup.transform);

                newLowPolyTree.transform.localScale = childTrees[j].transform.localScale;
                newLowPolyTree.transform.rotation = childTrees[j].transform.rotation;

                CheckTreePlacement(newLowPolyTree);
            } else {
                // Skip
            }

            j++;
        }

        //Combine();
    }

    private void CheckTreePlacement(Transform tree) { 
        int layerMask = 1 << 7;
        //layerMask = ~layerMask;

        float distance; 
        RaycastHit hit;
        float height = 20f * transform.localScale.y;
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
