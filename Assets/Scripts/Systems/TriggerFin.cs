using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

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

            BloomModel.Settings p1PPP = GameObject.Find("CameraJoueur1").GetComponent<PostProcessingBehaviour>().profile.bloom.settings;
            BloomModel.Settings p2PPP = GameObject.Find("CameraJoueur2").GetComponent<PostProcessingBehaviour>().profile.bloom.settings;
            BloomModel.Settings bloomTempSet = p1PPP;
            bloomTempSet.bloom.intensity = 0.91f;
            p1PPP = bloomTempSet;
            p2PPP = bloomTempSet;

            SceneManager.LoadScene(NomLevel, LoadSceneMode.Single);
        }
    }
}
