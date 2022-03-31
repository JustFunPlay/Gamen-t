using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public int forestSize = 25;
    public int elementSpacing = 3;

    public Element[] elements;

    public void Awake()
    {
        for(int x = -1100; x < forestSize; x += elementSpacing)
        {
            for (int z = -1100; z < forestSize; z += elementSpacing)
            {
                for(int i = 0; i < elements.Length; i++)
                {
                    Element element = elements[i];

                    if (element.CanPlace())
                    {
                        Vector3 position = new Vector3(x, 100f, z);
                        Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                        //Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                        //Vector3 scale = Vector3.one * Random.Range(0.75f, 1.2f);

                        GameObject newElement = Instantiate(element.GetRandom());
                        newElement.transform.SetParent(transform);
                        newElement.transform.position = position + offset;
                        //newElement.transform.eulerAngles = rotation;
                        //newElement.transform.localScale = scale;

                        break;
                    }
                }
            }
        }
    }
   /* void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        Debug.Log(meshFilters.Length);

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        //transform.GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
    }
*/

}

[System.Serializable]
public class Element
{
    public string name;
    [Range(1,10)]
    public int density;

    public GameObject[] prefabs;

    public bool CanPlace()
    {
        if (Random.Range(0,10) < density)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject GetRandom()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }

}