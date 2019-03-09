using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider oxygenSlider;
    public float duration = 120f;
    private float timer;
    
    void Start()
    {
        timer = duration;
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        float progress = Map(timer, 0f, duration, 0f, 1f);
        oxygenSlider.value = progress;

        if (timer <= 0)
        {
            EndOfTimer();
        }
    }

    void EndOfTimer()
    {
        GameObject.Find("Score").GetComponent<Score>().SetScores();
        SceneManager.LoadScene("Fin", LoadSceneMode.Single);
    }

    float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
