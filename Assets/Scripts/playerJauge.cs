using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerJauge : MonoBehaviour
{
    public playerMovement player;
    private Text textPourcentage;
    private Image imageFull;

    // Start is called before the first frame update
    void Start()
    {
        textPourcentage = this.transform.Find("Pourcentage").GetComponent<Text>();
        imageFull = this.transform.Find("ImageFull").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        textPourcentage.text = System.Math.Round(player.pression,1).ToString();
        imageFull.fillAmount = player.pression / 100;
    }
}
