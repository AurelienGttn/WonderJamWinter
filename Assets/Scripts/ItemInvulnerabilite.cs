using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvulnerabilite : MonoBehaviour, Items
{

    private GameObject player1;
    private GameObject player2;
    public GameObject invulnerabiliteJ1; 
    public GameObject invulnerabiliteJ2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void run(bool isPlayer1)
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        bool player1First = false;
        float positionPlayer1 = player1.transform.position.x;
        float positionPlayer2 = player2.transform.position.x;
        if (positionPlayer1 > positionPlayer2)
        {
            player1First = true;
        }

        if (isPlayer1 && player1First)
        {
            invulnerabiliteJ1.SetActive(true); 
        }

        if (isPlayer1 && !player1First)
        {
            invulnerabiliteJ1.SetActive(true);
        }

        if (!isPlayer1 && !player1First)
        {
            invulnerabiliteJ2.SetActive(true);
        }

        if (!isPlayer1 && player1First)
        {
            invulnerabiliteJ2.SetActive(true);
        }
    }
}
