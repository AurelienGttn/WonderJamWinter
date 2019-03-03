using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFin : MonoBehaviour
{
    private Score score;
    public string NomLevel;

    private void Start()
    {
        score = FindObjectOfType<Score>();

        //p1PP = GameObject.Find("CameraJoueur1").GetComponent<PostProcessingBehaviour>().profile;
        //p2PPP = GameObject.Find("CameraJoueur2").GetComponent<PostProcessingBehaviour>().profile;
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
