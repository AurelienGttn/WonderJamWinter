using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ItemFlouJoueur : MonoBehaviour, Items
{
    //public PostProcessingProfile;
    private GameObject player1;
    private GameObject player2;
    private GameObject p1Camera;
    private PostProcessingProfile p1PPP;
    private PostProcessingProfile p2PPP;

    private float flouTimer;
    private bool isPlayer1Cible;
    private bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void run(bool isPlayer1)
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        p1PPP = GameObject.Find("CameraJoueur1").GetComponent<PostProcessingBehaviour>().profile;
        p2PPP = GameObject.Find("CameraJoueur2").GetComponent<PostProcessingBehaviour>().profile;

        //BloomModel.Settings bloomTempSet;
        //= p1.bloom.settings;
        //bloomTempSet.bloom.intensity = 45.0f;
        //p1PPP.bloom.settings = bloomTempSet;

        bool player1First = false;
        float positionPlayer1 = player1.transform.position.x;
        float positionPlayer2 = player2.transform.position.x;

        if (positionPlayer1 > positionPlayer2)
        {
            player1First = true;
        }

        if (isPlayer1 && player1First)
        {
            flouTimer = 2.0f;
            isPlayer1Cible = false;
        }

        else if (isPlayer1 && !player1First)
        {
            flouTimer = 5.0f;
            isPlayer1Cible = false;
        }

        if (!isPlayer1 && !player1First)
        {
            flouTimer = 2.0f;
            isPlayer1Cible = true;
        }

        if (!isPlayer1 && player1First)
        {
            flouTimer = 5.0f;
            isPlayer1Cible = true;
        }
        
        if (isPlayer1Cible)
        {
            BloomModel.Settings bloomTempSet = p1PPP.bloom.settings;
            bloomTempSet.bloom.intensity = 45.0f;
            p1PPP.bloom.settings = bloomTempSet;
            StartCoroutine(Timer(flouTimer, isPlayer1Cible));
        }
        else
        {
            BloomModel.Settings bloomTempSet = p2PPP.bloom.settings;
            bloomTempSet.bloom.intensity = 45.0f;
            p2PPP.bloom.settings = bloomTempSet;
            StartCoroutine(Timer(flouTimer, isPlayer1Cible));

        }


    }

    IEnumerator Timer(float time, bool isPlayer1)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("TEST ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;");
        if(isPlayer1)
        {
            BloomModel.Settings bloomTempSet = p1PPP.bloom.settings;
            bloomTempSet.bloom.intensity = 0.91f;
            p1PPP.bloom.settings = bloomTempSet;
        } else
        {
            BloomModel.Settings bloomTempSet = p2PPP.bloom.settings;
            bloomTempSet.bloom.intensity = 0.91f;
            p2PPP.bloom.settings = bloomTempSet;
        }
		Destroy(this);
    }
    
}
