using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroïde : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Rigidbody rbAsteroïde;
    private float randomDirectionX;
    private float randomDirectionY;
    private GameObject Player1;
    private GameObject Player2;
    private Vector3 positionPlayer1;
    private Vector3 positionPlayer2;
    private Vector3 rotation;
    

    // Start is called before the first frame update
    void Start()
    {
        rbAsteroïde = GetComponent<Rigidbody>();
        rotation = new Vector3(0.0f, 0.0f, Random.Range(0.1f, 1f));

        Player1 = GameObject.Find("Player 1");
        positionPlayer1 = Player1.transform.position; 
      
        Player2 = GameObject.Find("Player 2");
        positionPlayer2 = Player2.transform.position;

        randomDirectionX = Random.Range(positionPlayer1.x, positionPlayer2.x);
        randomDirectionY = Random.Range(positionPlayer1.y, positionPlayer2.y);

        transform.LookAt(new Vector3(randomDirectionX, randomDirectionY, 0.0f));
        rbAsteroïde.AddForce(transform.forward*200); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += rotation; 
    }
   
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Asteroïde"))
        {
            rbPlayer = other.GetComponent<Rigidbody>();
          
            rbPlayer.velocity = -rbPlayer.velocity + rbAsteroïde.velocity;
            rbAsteroïde.velocity = -rbAsteroïde.velocity;

        }
    }
    */
}
