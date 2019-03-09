using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                    GameObject item = Instantiate(items[randomIndex]);
					other.gameObject.GetComponent<playerMovement>().item = item.GetComponent<Items>();
                    
					switch (item.name) {
						case "ItemJauge(Clone)":
							GameObject.Find("PressionJ1").GetComponent<Image>().enabled = true;
							break;
						case "ItemInvulnerabilite(Clone)":
							GameObject.Find("InvulnerabiliteJ1").GetComponent<Image>().enabled = true;
							break;
						case "ItemPushAsteroid(Clone)":
							GameObject.Find("RepoussoirJ1").GetComponent<Image>().enabled = true;
							break;
						case "ItemFlouJoueur(Clone)":
							GameObject.Find("FlouJ1").GetComponent<Image>().enabled = true;
							break;
					}
                }
            } else
            {
                if (!playerPassage[1])
                {
                    playerPassage[1] = true;
                    GameObject item = Instantiate(items[randomIndex]);
                    //item.GetComponent<Items>().run(player1);
					other.gameObject.GetComponent<playerMovement>().item = item.GetComponent<Items>();
                    
					switch (item.name) {
						case "ItemJauge(Clone)":
							GameObject.Find("PressionJ2").GetComponent<Image>().enabled = true;
							break;
						case "ItemInvulnerabilite(Clone)":
							GameObject.Find("InvulnerabiliteJ2").GetComponent<Image>().enabled = true;
							break;
						case "ItemPushAsteroid(Clone)":
							GameObject.Find("RepoussoirJ2").GetComponent<Image>().enabled = true;
							break;
						case "ItemFlouJoueur(Clone)":
							GameObject.Find("FlouJ2").GetComponent<Image>().enabled = true;
							break;
					}
				}
            }
        }
    }
}