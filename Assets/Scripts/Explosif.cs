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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            rbExplosif.GetComponent<MeshRenderer>().enabled = false;
            explosion.SetActive(true);
            if (collision.collider.name == "Player 1")
            {
                StartCoroutine(WaitGameOver(player1, panelPlayer1));

            }
            if (collision.collider.name == "Player 2")
            {
                StartCoroutine(WaitGameOver(player2, panelPlayer2));
            }

        }
    }

    IEnumerator WaitGameOver(GameObject player, GameObject panelPlayer)
    {
        Destroy(player);
        yield return new WaitForSeconds(1);
        panelPlayer.SetActive(true);
    }
}
