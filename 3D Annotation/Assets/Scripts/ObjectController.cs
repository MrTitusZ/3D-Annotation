using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameObject grape;
    [SerializeField] Camera snapshotCamera;
    [SerializeField] public int resWidth = 1920;
    [SerializeField] public int resHeight = 1080;
    [SerializeField] float rotationDegree = 15f;

    GameObject grapeInstance;
    TakeSnapshot takeSnapshot;
    BoundingBox boundingBox;
    RotateObject rotateObject;
    CreateFile createFile;

    void Start()
    {
        grapeInstance = Instantiate(grape, grape.transform.position, grape.transform.rotation);
        takeSnapshot = snapshotCamera.GetComponent<TakeSnapshot>();
        boundingBox = grapeInstance.GetComponent<BoundingBox>();
        createFile = FindObjectOfType<CreateFile>();
        rotateObject = grapeInstance.GetComponent<RotateObject>();

        int rotationNumber = (int)Mathf.Ceil(360 / rotationDegree);
        RotateObjectAndTakeSnapshot(rotationNumber);
    }

    void RotateObjectAndTakeSnapshot(int rotationNumber)
    {
        for(int i = 0; i < rotationNumber; i++)
        {
            takeSnapshot.CaptureSnapshot(snapshotCamera, i, resWidth, resHeight);
            createFile.CreateTextFile(boundingBox.GUI2dRectWithObject(grapeInstance), i, resWidth, resHeight);
            rotateObject.RotateGameObject(rotationDegree);
        }
    }
}
