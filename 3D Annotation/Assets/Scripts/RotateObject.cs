using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour   
{
    [SerializeField] float rotationDegree = 15f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RotateGameObject();
        }
    }

    public void RotateGameObject()
    {
        transform.Rotate(0, -rotationDegree, 0);
    }
}
