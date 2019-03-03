using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvulnerabilite : MonoBehaviour, Items
{

    private GameObject player1;
    private GameObject player2;
    private GameObject invulnerabiliteJ1;
    private GameObject invulnerabiliteJ2;
    float invulnerabiliteTime;
    public static bool isInvulnerable; 
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
        invulnerabiliteJ1 = player1.transform.Find("InvulnerabiliteJ1").gameObject;
        invulnerabiliteJ2 = player2.transform.Find("InvulnerabiliteJ2").gameObject;

        if (positionPlayer1 > positionPlayer2)
        {
            player1First = true;
        }

        if (isPlayer1 && player1First)
        {
            invulnerabiliteTime = 2; 
            invulnerabiliteJ1.SetActive(true);
            isInvulnerable = true; 
            StartCoroutine(TimeInvulnerabilite(invulnerabiliteJ1)); 
        }

        if (isPlayer1 && !player1First)
        {

            invulnerabiliteTime = 5;
            invulnerabiliteJ1.SetActive(true);
            isInvulnerable = true;
            StartCoroutine(TimeInvulnerabilite(invulnerabiliteJ1));
        }

        if (!isPlayer1 && !player1First)
        {
            invulnerabiliteTime = 2;
            invulnerabiliteJ2.SetActive(true);
            isInvulnerable = true;
            StartCoroutine(TimeInvulnerabilite(invulnerabiliteJ2));
        }

        if (!isPlayer1 && player1First)
        {
            invulnerabiliteTime = 5;
            invulnerabiliteJ2.SetActive(true);
            isInvulnerable = true;
            StartCoroutine(TimeInvulnerabilite(invulnerabiliteJ2));
        }
    }

    IEnumerator TimeInvulnerabilite(GameObject invulnerabilitePlayer)
    {
        yield return new WaitForSeconds(invulnerabiliteTime);
        invulnerabilitePlayer.SetActive(false);
        isInvulnerable = false; 
    }
}

  


