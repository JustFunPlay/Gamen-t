using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetObjectsToDirty : MonoBehaviour
{
    public ScriptableObject[] scriptableObjects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < scriptableObjects.Length; i++)
        {
            EditorUtility.SetDirty(scriptableObjects[i]);
        }
    }
}
