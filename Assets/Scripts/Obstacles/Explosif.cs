using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosif : MonoBehaviour
{
    public GameObject explosion;
    private GameObject player1;
    private GameObject player2; 
    
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
            explosion.SetActive(true);

            if (collision.collider.name == "Player 1")
            {
                StartCoroutine(WaitGameOver(player1));
            }
            if (collision.collider.name == "Player 2")
            {
                StartCoroutine(WaitGameOver(player2));
            }
        }
    }

    IEnumerator WaitGameOver(GameObject player)
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<playerMovement>().death();
    }
}
