using TMPro;
using UnityEngine;

public class DisplayScores : MonoBehaviour
{

    private Score score;

    private TextMeshProUGUI scoreTextWinner;
    private TextMeshProUGUI scoreTextLooser;


    void Start()
    {


        score = FindObjectOfType<Score>();

        if (score == null)
        {
            return;
        }
        if (score.scoreP1 > score.scoreP2)
        {
            score.numberWinP1++;
        }
        else
        {
            score.numberWinP2++;
        }

        scoreTextWinner = GameObject.Find("text winner").GetComponent<TextMeshProUGUI>();
        scoreTextLooser = GameObject.Find("text looser").GetComponent<TextMeshProUGUI>();


        if (score.numberWinP1 > score.numberWinP2 || (score.numberWinP1 == score.numberWinP2 && score.scoreP1 > score.scoreP2))
        {
            scoreTextWinner.text = "Player 1 : " + score.numberWinP1 + "  wins    score : " + Mathf.FloorToInt(score.scoreP1);
            scoreTextLooser.text = "Player 2 : " + score.numberWinP2 + "  wins    score : " + Mathf.FloorToInt(score.scoreP2);
        }
        else
        {
            scoreTextLooser.text = "Player 1 : " + score.numberWinP1 + "  wins    score : " + Mathf.FloorToInt(score.scoreP1);
            scoreTextWinner.text = "Player 2 : " + score.numberWinP2 + "  wins    score : " + Mathf.FloorToInt(score.scoreP2);
        }
    }



}
