using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFin : MonoBehaviour
{
    private Score score;
    public string NomLevel;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<playerMovement>().enabled == true)
        {
            score.SetScores();
            SceneManager.LoadScene(NomLevel, LoadSceneMode.Single);
        }
    }
}
