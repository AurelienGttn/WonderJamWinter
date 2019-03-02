using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroïde : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Rigidbody rbAsteroïde;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rbAsteroïde = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            rbPlayer = other.GetComponent<Rigidbody>();
            rbPlayer.AddForce(Vector3.down);
            rbAsteroïde.AddForce(Vector3.down); 
        }
    }
}
