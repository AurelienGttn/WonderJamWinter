using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public List<GameObject> items;
    private int randomIndex;
    private bool player1;
    private bool[] playerPassage = { false, false };

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player1 = other.GetComponent<playerMovement>().isPlayer1;
            randomIndex = Random.Range(0, items.Count);
            if(player1)
            {
                if(!playerPassage[0])
                {
                    playerPassage[0] = true;
                    items[randomIndex].GetComponent<Items>().run(player1);
                }
            } else
            {
                if (!playerPassage[1])
                {
                    playerPassage[1] = true;
                    items[randomIndex].GetComponent<Items>().run(player1);
                }
            }
        }
    }
}

        if(other.tag == "Player")
        {
            player1 = other.GetComponent<playerMovement>().isPlayer1;
            randomIndex = Random.Range(0, items.Count);
            if(player1)
            {
                if(!playerPassage[0])
                {
                    playerPassage[0] = true;
                    GameObject item = Instantiate(items[randomIndex]);
                    item.GetComponent<Items>().run(player1);
                   
                }
            } else
            {
                if (!playerPassage[1])
                {
                    playerPassage[1] = true;
                    GameObject item = Instantiate(items[randomIndex]);
                    item.GetComponent<Items>().run(player1);
                }
            }