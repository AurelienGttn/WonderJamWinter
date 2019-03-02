using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroïde : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Rigidbody rbAsteroïde;
    public float speed;
    private int randomRotation;
    private Vector3 rotation; 

    // Start is called before the first frame update
    void Start()
    {
        rbAsteroïde = GetComponent<Rigidbody>();
        randomRotation = Random.Range(1, 3);
        Debug.Log(randomRotation); 
        switch (randomRotation)
        {
                        case 1:
                rotation = new Vector3(0.0f, 0.5f, 0.0f);
              
                break;
            case 2:
                rotation = new Vector3(0.0f, 0.0f, 0.5f);
               
                break; 
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += rotation; 

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rbPlayer = other.GetComponent<Rigidbody>();
            rbAsteroïde.velocity = rbPlayer.velocity;
            rbPlayer.velocity = rbPlayer.velocity * (-1.0f);
           
        }
    }
}
