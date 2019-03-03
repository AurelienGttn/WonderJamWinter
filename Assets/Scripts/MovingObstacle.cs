using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Rigidbody rbMovingObstacle;
    [SerializeField] private float asteroidSpeed = 400f;
    [SerializeField] private float barrelSpeed = 50f;

    private float randomDirectionX;
    private float randomDirectionY;

    private GameObject Player1;
    private GameObject Player2;
    private Vector3 positionPlayer1;
    private Vector3 positionPlayer2;
    private Vector3 rotation;
    
    
    void Start()
    {

        rbMovingObstacle = GetComponent<Rigidbody>();
        rotation = new Vector3(0.0f, 0.0f, Random.Range(0.1f, 1f));

        Player1 = GameObject.Find("Player 1");
        positionPlayer1 = Player1.transform.position; 
      
        Player2 = GameObject.Find("Player 2");
        positionPlayer2 = Player2.transform.position;

        randomDirectionX = Random.Range(positionPlayer1.x, positionPlayer2.x);
        randomDirectionY = Random.Range(positionPlayer1.y, positionPlayer2.y);

        transform.LookAt(new Vector3(randomDirectionX, randomDirectionY, 0.0f));

        if (name.Contains("meteor"))
        {
            rbMovingObstacle.AddForce(transform.forward * asteroidSpeed * rbMovingObstacle.mass);
            transform.localScale = new Vector3(Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.3f), Random.Range(0.1f, 0.3f));
        }
        else if (name.Contains("barrel"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            rbMovingObstacle.AddForce(transform.forward * barrelSpeed * rbMovingObstacle.mass);
        }
    }
    
    void Update()
    {
        transform.eulerAngles += rotation; 
    }
}
