using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerJauge : MonoBehaviour
{
    public playerMovement player;
    private Text textPourcentage;

    // Start is called before the first frame update
    void Start()
    {
        textPourcentage = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textPourcentage.text = System.Math.Round(player.pression,2).ToString() + " %";
    }
}
