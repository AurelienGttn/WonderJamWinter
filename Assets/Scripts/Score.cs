using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score scoreInstance;

    private Transform player1, player2;
    [HideInInspector] public float scoreP1, scoreP2;

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

    public void SetScores()
    {
        scoreP1 = player1.position.x;
        scoreP2 = player2.position.x;
    }
}
