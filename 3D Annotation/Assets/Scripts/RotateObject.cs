using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour   
{
    [SerializeField] float rotationDegree = 15f;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RotateGameObject();
            Debug.Log("Space pressed!");
        }
    }

    public void RotateGameObject()
    {
        transform.Rotate(0, -rotationDegree, 0);
    }
}
