using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour   
{
    // This method rotates the object
    public void RotateGameObject(float rotationDegree)
    {
        transform.Rotate(0, -rotationDegree, 0);
    }

    // This method returns the rotation degree
    public float GetRotationDegree(float rotationDegree)
    {
        return rotationDegree;
    }
}
