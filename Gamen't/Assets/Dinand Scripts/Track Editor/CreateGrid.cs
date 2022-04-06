using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public Vector3 gridsize;
    public GameObject gridNode;
    public List<Level> levels = new List<Level>();
    
    void Awake()
    {
        int i = 0;
        for (int y = 0; y < gridsize.y; y++)
        {
            levels.Add(new Level());
            for (int x = 0 ; x  < gridsize.x; x++)
            {
                for (int z = 0; z < gridsize.z; z++)
                {
                    i++;
                    GameObject newNode = Instantiate(gridNode, new Vector3((x - gridsize.x * 0.5f) * 20, y * 6, (z - gridsize.z * 0.5f) * 20), Quaternion.identity);
                    levels[y].level.Add(newNode.transform);
                    newNode.GetComponent<NodeInfo>().gridNodeValue = i;
                    newNode.GetComponent<NodeInfo>().gridLocation = new Vector3(x, y, z);
                    newNode.name = i.ToString();
                    if (y > 0)
                    {
                        newNode.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
        }
    }
}
[System.Serializable]
public class Level
{
    public List<Transform> level = new List<Transform>();
}