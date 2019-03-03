using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public List<GameObject> items;
    private int randomIndex;
    private bool player1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            player1 = other.GetComponent<playerMovement>().isPlayer1;
            Debug.Log("Player : " + player1);
            randomIndex = Random.Range(0, items.Count);
            items[randomIndex].GetComponent<Items>().run(player1);
        }
    }
}
