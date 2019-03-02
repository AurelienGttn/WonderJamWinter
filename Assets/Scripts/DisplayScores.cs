using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScores : MonoBehaviour
{

    private Score score;

    private TextMeshProUGUI scoreText;


    void Start()
    {
        score = FindObjectOfType<Score>();

        scoreText = GetComponent<TextMeshProUGUI>();

        scoreText.text = "Player 1 score : " + Mathf.FloorToInt(score.scoreP1)
            + "\nPlayer 2 score : " + Mathf.FloorToInt(score.scoreP2);
    }



}
