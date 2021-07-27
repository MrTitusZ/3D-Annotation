using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour   
{
    // This method rotates the object by the given amount
    public void RotateGameObject(float rotationDegree)
    {
        transform.Rotate(0, -rotationDegree, 0);
    }
}
