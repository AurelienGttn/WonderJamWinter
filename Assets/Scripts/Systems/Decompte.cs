using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decompte : MonoBehaviour
{
    YieldInstruction wait = new WaitForSeconds(1);
    public Image Bulle1;
    public Image Bulle2;
    public Image Bulle3;
    private bool bulle1explode;
    private bool bulle2explode;
    private bool bulle3explode;
    private Text three, two, one;

    public AudioClip a1;
    public AudioClip a2;
    public AudioClip a3;
    private AudioSource audios;

    void Start()
    {
        playerMovement.IsInputEnabled = false;
        bulle1explode = false;
        bulle2explode = false;
        bulle3explode = false;
        audios =  GetComponent<AudioSource>();

        three = Bulle1.GetComponentInChildren<Text>();
        two = Bulle2.GetComponentInChildren<Text>();
        one = Bulle3.GetComponentInChildren<Text>();

        three.enabled = false;
        two.enabled = false;
        one.enabled = false;
    }
    
    void Update()
    {
        if(!bulle3explode)
        {
            if(bulle1explode == false && bulle2explode == false )
            {  
                StartCoroutine(ExplodeBulle(Bulle1));
                three.enabled = true;
            }
         
            if(bulle1explode == true && bulle2explode == false )
            {
                StartCoroutine(ExplodeBulle(Bulle2));
                two.enabled = true;
            }
        
            if(bulle1explode == true && bulle2explode == true )
            {
                StartCoroutine(ExplodeBulle(Bulle3));
                one.enabled = true;
            }   
        }
    }

    IEnumerator ExplodeBulle(Image bulle) 
    {   
        yield return new WaitForSeconds(1);

        if(bulle == Bulle1 && !bulle1explode)
        {
            GameObject effets =  bulle.transform.Find("CFX_Poof").gameObject;
            GameObject number = bulle.transform.Find("Text").gameObject;
            number.SetActive(true);
            effets.SetActive(true);
            ParticleSystem ps =   effets.GetComponent<ParticleSystem>();
            audios.clip = a1;
            audios.Play();
            bulle1explode = true;
            ps.Play();
            Destroy(Bulle1.gameObject);
        }

        else if(bulle == Bulle2 && !bulle2explode)
        {
            GameObject effets =  bulle.transform.Find("CFX_Poof").gameObject;
            GameObject number = bulle.transform.Find("Text").gameObject;
            number.SetActive(true);
            effets.SetActive(true);
            ParticleSystem ps =   effets.GetComponent<ParticleSystem>();
            audios.clip = a2;
            audios.Play();
            bulle2explode = true;
            ps.Play();
            Destroy(Bulle2.gameObject);
        }

        else if(bulle == Bulle3 && !bulle3explode)
        {
            GameObject effets =  bulle.transform.Find("CFX_Poof").gameObject;
            GameObject number = bulle.transform.Find("Text").gameObject;
            number.SetActive(true);
            effets.SetActive(true);
            ParticleSystem ps =   effets.GetComponent<ParticleSystem>();
            audios.clip = a3;
            audios.Play();
            bulle3explode = true;
            Destroy(Bulle3.gameObject);
            ps.Play();
            playerMovement.IsInputEnabled = true;
        }
    }
}
