using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameObject grape;
    [SerializeField] Camera snapshotCamera;

    GameObject grapeInstance;
    BoundingBox boundingBox;
    RotateObject rotateObject;
    TakeSnapshot takeSnapshot;

    void Start()
    {
        grapeInstance = Instantiate(grape, grape.transform.position, grape.transform.rotation);
        boundingBox = grapeInstance.GetComponent<BoundingBox>();
        rotateObject = grapeInstance.GetComponent<RotateObject>();
        takeSnapshot = snapshotCamera.GetComponent<TakeSnapshot>();

        int rotationNumber = (int)Mathf.Ceil(360 / rotateObject.GetRotationDegree());
        RotateObjectAndTakeSnapshot(rotationNumber);
    }

    void RotateObjectAndTakeSnapshot(int rotationNumber)
    {
        for(int i = 0; i < rotationNumber; i++)
        {
            takeSnapshot.CaptureSnapshot(snapshotCamera, i);
            rotateObject.RotateGameObject();
        }
    }
}
