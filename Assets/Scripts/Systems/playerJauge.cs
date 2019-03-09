using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerJauge : MonoBehaviour
{
    public playerMovement player;
    private Text textPourcentage;
    private Image imageFull;
    
    void Start()
    {
        imageFull = transform.Find("ImageFull").GetComponent<Image>();
    }
    
    void Update()
    {
        imageFull.fillAmount = player.pression / 100;
    }
}
