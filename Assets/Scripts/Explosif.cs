using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosif : MonoBehaviour
{
    private Rigidbody rbExplosif;
    public GameObject explosion;
    public GameObject barrel;
    public GameObject panelPlayer1;
    public GameObject panelPlayer2;
    public GameObject player1;
    public GameObject player2; 

    // Start is called before the first frame update
    void Start()
    {
        rbExplosif = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rbExplosif.GetComponent<MeshRenderer>().enabled = false; 
            explosion.SetActive(true); 
            if(other.name == "Player 1")
            {
                StartCoroutine(WaitGameOver(player1, panelPlayer1));
                
            }
            if (other.name == "Player 2")
            {
               StartCoroutine(WaitGameOver(player2, panelPlayer2));
            }

        }

        if (other.CompareTag("Asteroïde"))
        {
            rbExplosif.velocity = -rbExplosif.velocity;

        }
    }

    IEnumerator WaitGameOver(GameObject player, GameObject panelPlayer)
    {
        Destroy(player);
        yield return new WaitForSeconds(1);
        panelPlayer.SetActive(true);
    }
}
