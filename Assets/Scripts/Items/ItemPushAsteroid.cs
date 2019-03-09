using UnityEngine;

public class ItemPushAsteroid : MonoBehaviour, Items
{
    private GameObject player1;
    private GameObject player2;
    private float time;

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
            time = 10.0f;
            player1.GetComponent<playerMovement>().pushAsteroids(time);
        }

        else if (isPlayer1 && !player1First)
        {
            time = 30.0f;
            player1.GetComponent<playerMovement>().pushAsteroids(time);
        }

        if (!isPlayer1 && !player1First)
        {
            time = 10.0f;
            player2.GetComponent<playerMovement>().pushAsteroids(time);
        }

        if (!isPlayer1 && player1First)
        {
            time = 30.0f;
            player2.GetComponent<playerMovement>().pushAsteroids(time);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
