using System.Collections;
using UnityEngine;

public class EndMenuHandler : MonoBehaviour
{
    public GameObject contenant;
    private Score score;
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        score = score = FindObjectOfType<Score>();
        if (score.numberWinP1 > score.numberWinP2 || (score.numberWinP1 == score.numberWinP2 && score.scoreP1 > score.scoreP2))
        {
            player2.SetActive(false);
        }
        else
        {
            player1.SetActive(false);
        }
        StartCoroutine("updateRotation");
    }


    public IEnumerator updateRotation()
    {
        while (true)
        {
            contenant.transform.Rotate(new Vector3(0, 0, -3));
            contenant.transform.Rotate(new Vector3(0, 1, 0));
            yield return new WaitForSeconds(0.01f);

        }

    }
}
