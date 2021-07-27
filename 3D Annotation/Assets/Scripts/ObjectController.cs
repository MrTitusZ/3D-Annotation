using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameObject grapeModel;
    [SerializeField] Camera snapshotCamera;
    [SerializeField] public int resWidth = 1920;
    [SerializeField] public int resHeight = 1080;
    [SerializeField] float rotationDegree = 15f;
    [SerializeField] Transform[] wayPoints;

    GameObject grapeInstance;
    TakeSnapshot takeSnapshot;
    BoundingBox boundingBox;
    RotateObject rotateObject;
    CreateFile createFile;

    void Start()
    {
        grapeInstance = Instantiate(grapeModel, grapeModel.transform.position, grapeModel.transform.rotation);
        takeSnapshot = snapshotCamera.GetComponent<TakeSnapshot>();
        boundingBox = grapeInstance.GetComponent<BoundingBox>();
        createFile = GetComponent<CreateFile>();
        rotateObject = grapeInstance.GetComponent<RotateObject>();

        int rotationNumber = (int)Mathf.Ceil(360 / rotationDegree);
        RotateObjectAndTakeSnapshot(rotationNumber);
    }

    void RotateObjectAndTakeSnapshot(int rotationNumber)
    {
        for(int viewPointCounter = 0; viewPointCounter < wayPoints.Length; viewPointCounter++)
        {
            Camera.main.transform.position = wayPoints[viewPointCounter].transform.position;
            Camera.main.transform.rotation = wayPoints[viewPointCounter].transform.rotation;
            for (int rotationCounter = 0; rotationCounter < rotationNumber; rotationCounter++)
            {
                takeSnapshot.CaptureSnapshot(snapshotCamera, viewPointCounter, rotationCounter, resWidth, resHeight);
                createFile.CreateTextFile(boundingBox.GUI2dRectWithObject(grapeInstance), viewPointCounter, rotationCounter, resWidth, resHeight);
                rotateObject.RotateGameObject(rotationDegree);
            }
        }
    }
}
