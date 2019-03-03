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
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.IsInputEnabled = false;
        bulle1explode = false;
        bulle2explode = false;
        bulle3explode = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!bulle3explode)
        {
            
            if(bulle1explode == false && bulle2explode == false )
            {  
                StartCoroutine(ExplodeBulle(Bulle1));
            }
         

            if(bulle1explode == true && bulle2explode == false )
            {
                StartCoroutine(ExplodeBulle(Bulle2));
            }
        

            if(bulle1explode == true && bulle2explode == true )
            {
                StartCoroutine(ExplodeBulle(Bulle3));
            }
            
        }
        
    }

    IEnumerator ExplodeBulle(Image bulle) 
    {   
        GameObject effets =  bulle.transform.Find("CFX_Poof").gameObject;
        effets.SetActive(true);
        ParticleSystem ps =   effets.GetComponent<ParticleSystem>();
        ps.Play();
        yield return new WaitForSeconds(1);
        if(bulle == Bulle1)
        {
            GetComponent<AudioSource>().enabled = true; 
            this.bulle1explode = true;
            Destroy(Bulle1);
        }
        else if(bulle == Bulle2)
        {
            this.bulle2explode = true;
            Destroy(Bulle2);
        }
        else if(bulle == Bulle3)
        {
            this.bulle3explode = true;
            Destroy(Bulle3);
            playerMovement.IsInputEnabled = true;
        }
      
        
       
        
    }

}
