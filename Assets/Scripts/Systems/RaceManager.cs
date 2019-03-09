using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RaceManager : MonoBehaviour
{
    [SerializeField] private Image player1Image, player2Image, flag;
    private Transform player1, player2;

    // We use floats because we only need the x coordinate
    private float vaisseauFin;
    private float posP1, posP2;
    private float p1imgPos, p2imgPos;
    private float flagPos;

    
    void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
        flagPos = flag.GetComponent<RectTransform>().anchoredPosition.x;

        vaisseauFin = FindObjectOfType<TriggerFin>().transform.position.x;
    }
    
    void Update()
    {
        posP1 = player1.position.x;
        posP2 = player2.position.x;

        // Calculate new position for each image based on how far
        // from the finish line (vaisseauFin) each player is
        p1imgPos = posP1 / vaisseauFin * flagPos;
        p2imgPos = posP2 / vaisseauFin * flagPos;

        // Move each image
        player1Image.GetComponent<RectTransform>().anchoredPosition = new Vector3(p1imgPos, 20f, 0f);
        player2Image.GetComponent<RectTransform>().anchoredPosition = new Vector3(p2imgPos, -20f, 0f);
    }
}
