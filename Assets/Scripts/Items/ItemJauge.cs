using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJauge : MonoBehaviour, Items
{
    private GameObject player1;
    private GameObject player2;
    private float malus;

    private void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    public void run(bool isPlayer1)
    {
        bool player1First = false; 
        float positionPlayer1 = player1.transform.position.x;
        float positionPlayer2 = player2.transform.position.x;

        if (positionPlayer1 > positionPlayer2)
        {
            player1First = true; 
        }

        if (isPlayer1)
        {
            if (player1First)
                malus = 15f;
            else
                malus = 35f;

            player2.GetComponent<playerMovement>().pression -= malus;
        }

        else
        {
            if (!player1First)
                malus = 15f;
            else
                malus = 35f;

            player1.GetComponent<playerMovement>().pression -= malus;
        }

		Destroy(this);

    }
}
