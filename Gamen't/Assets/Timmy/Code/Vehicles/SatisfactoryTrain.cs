using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SatisfactoryTrain : MonoBehaviour {
    public Transform locomotive;
    public Transform wagonPrefab;
    public Transform wagonContainer;

    [Range(0, 100)]
    public int wagons;
    public List<Transform> train;

    private float wagonLength = 16f;

    private void Update() {
        if (train == null || train.Count == 0) {
            train = new List<Transform>() { locomotive };
        }


        if (train.Count != wagons + 1) {
            Debug.Log("Train needs to be updated! (Train Length: " + train.Count.ToString() + ", Wagons: " + (wagons + 1 ).ToString() + ")");
            UpdateWagons();
        }
    }

    private void UpdateWagons () {
        int currentWagons = train.Count - 1;

        train = new List<Transform>() { locomotive };
        DestroyImmediate(wagonContainer.gameObject);

        if (wagons > (train.Count - 1)) {
            for (int i = currentWagons; i < wagons; i++) {
                AddWagon(i);
            }
        }
    }

    private void AddWagon (int i) {
        if (!wagonContainer) {
            wagonContainer = new GameObject().transform;
            wagonContainer.name = "SatisfactoryTrainWagonContainer";
        }

        Transform newWagon = Instantiate(wagonPrefab, transform.position, transform.rotation, wagonContainer);
        newWagon.localScale = transform.localScale;
        newWagon.localPosition = train[i].position + transform.right * (wagonLength * 0.4f);
        HingeJoint hinge = newWagon.GetComponent<HingeJoint>();
        hinge.connectedBody = train[i].GetComponent<Rigidbody>();
        hinge.connectedAnchor = new Vector3(8, 2, 0);
        if (i == 0) {
            hinge.connectedAnchor = new Vector3(0, 0.5f, -3.2f);
        }
        

        train.Add(newWagon);
    }
}
