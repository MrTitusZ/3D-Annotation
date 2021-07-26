using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] GameObject grape;
    [SerializeField] Camera snapshotCamera;

    BoundingBox boundingBox;
    RotateObject rotateObject;
    TakeSnapshot takeSnapshot;

    void Start()
    {
        boundingBox = grape.GetComponent<BoundingBox>();
        rotateObject = grape.GetComponent<RotateObject>();
        takeSnapshot = snapshotCamera.GetComponent<TakeSnapshot>();
    }
}
