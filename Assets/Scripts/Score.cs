using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score scoreInstance;

    private bool p1IsDead = false;
    private bool p2IsDead = false;

    private Transform player1, player2;
    [HideInInspector] public float scoreP1, scoreP2, numberWinP1, numberWinP2;

    void Awake()
    {
        if (scoreInstance == null)
        {
            scoreInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
    }

    private void Update()
    {
        Debug.Log(numberWinP1 + "  " + numberWinP1);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            numberWinP1 = 0;
            numberWinP2 = 0;
        }
        if (SceneManager.GetActiveScene().name != "MainScene")
            return;
        else
        {
            if (player1 == null || player2 == null)
            {
                player1 = GameObject.Find("Player 1").transform;
                player2 = GameObject.Find("Player 2").transform;
                scoreP1 = 0;
                scoreP2 = 0;
                p1IsDead = false;
                p2IsDead = false;
            }
        }

        if (!p1IsDead && player1.gameObject.GetComponent<playerMovement>().enabled == false)
        {
            p1IsDead = true;
            scoreP1 = player1.position.x;
        }

        if (!p2IsDead && player2.gameObject.GetComponent<playerMovement>().enabled == false)
        {
            p2IsDead = true;
            scoreP2 = player2.position.x;
        }

        if ((player1.gameObject.GetComponent<playerMovement>().enabled == false && player2.gameObject.GetComponent<playerMovement>().enabled == false))
        {
            //SetScores();
            SceneManager.LoadScene("Fin", LoadSceneMode.Single);
        }



    }

    public void SetScores()
    {
        if (!p1IsDead)
            scoreP1 = player1.position.x;
        if (!p2IsDead)
            scoreP2 = player2.position.x;
    }
}
