using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour   
{
    [SerializeField] float rotationDegree = 15f;

    // This method rotates the object
    public void RotateGameObject()
    {
        transform.Rotate(0, -rotationDegree, 0);
    }

    public float GetRotationDegree()
    {
        return rotationDegree;
    }
}
