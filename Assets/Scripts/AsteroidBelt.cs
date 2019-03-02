using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    private float xRotation, yRotation, zRotation;

    private void Start()
    {
        xRotation = Random.Range(0, 10);
        yRotation = Random.Range(0, 10);
        zRotation = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotation, yRotation, zRotation);
    }
}
