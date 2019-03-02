using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    private float xRotation, yRotation, zRotation;

    private void Start()
    {
        zRotation = Random.Range(0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotation, yRotation, zRotation);
    }
}
