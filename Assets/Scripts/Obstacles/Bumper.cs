using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Rigidbody rbPlayer;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play(); 
            rbPlayer = other.collider.GetComponent<Rigidbody>();
            rbPlayer.velocity = -rbPlayer.velocity * 2.0f;
        }
    }
   
}
