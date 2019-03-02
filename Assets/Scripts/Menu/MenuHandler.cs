using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasCredits;
    public GameObject canvasIntruction;
    public EventSystem eventSystem;
    public GameObject startButton;
    public GameObject backButton;

  
  

    public void Start()
    {
        canvasMenu.SetActive(true);
        canvasCredits.SetActive(false);


       
        ColorBlock colorBlock = new ColorBlock();
        colorBlock.normalColor = new Color(255, 255, 255, 0);
        colorBlock.highlightedColor = new Color(0, 0, 0, 101);


        Debug.Log(colorBlock.normalColor);
        Debug.Log(colorBlock.highlightedColor);
    }

    public void onClickbtn_Play()
    {
        SceneManager.LoadScene(1);
       
    }

    public void onClickIntructions()
    {
        StartCoroutine("MenutoIntrcution");
        eventSystem.SetSelectedGameObject(backButton);
    }

    public void onClickCredits()
    {
        StartCoroutine("menuToCredits");
        eventSystem.SetSelectedGameObject(backButton);
    }

    public void onClickMenu()
    {
        StartCoroutine("creditsToMenu");
        eventSystem.SetSelectedGameObject(startButton);

    

    }

    public IEnumerator menuToCredits()
    {
      
        float a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasMenu, a);
            a -= 0.05f;
        }
        canvasMenu.SetActive(false);
        

        yield return new WaitForSeconds(0.5f);
        canvasCredits.SetActive(true);
        setAlphaObject(canvasCredits, 0);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasCredits, a);
            a += 0.05f;
        }

      



    }

    public IEnumerator creditsToMenu()
    {
     
        float a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasCredits, a);
            a -= 0.05f;
        }
        canvasCredits.SetActive(false);



        yield return new WaitForSeconds(0.5f);
        canvasMenu.SetActive(true);
        setAlphaObject(canvasMenu, 0);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasMenu, a);
            a += 0.05f;
        }

    }


    public IEnumerator IntructionToMenu()
    {

        float a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasIntruction, a);
            a -= 0.05f;
        }
        canvasCredits.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        canvasMenu.SetActive(true);
        setAlphaObject(canvasMenu, 0);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasMenu, a);
            a += 0.05f;
        }


    }


        public IEnumerator MenutoIntrcution()
        {

        float a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasMenu, a);
            a -= 0.05f;
        }
        canvasMenu.SetActive(false);


        yield return new WaitForSeconds(0.5f);
        canvasIntruction.SetActive(true);
        setAlphaObject(canvasIntruction, 0);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasIntruction, a);
            a += 0.05f;
        }



    }

    public void setAlphaObject(GameObject myObject, float a)
    {
        foreach (Transform child in myObject.transform)
        {
            if (child.GetComponent<CanvasRenderer>() != null)
            {
                child.GetComponent<CanvasRenderer>().SetAlpha(a);
            }
            setAlphaObject(child.gameObject, a);
        }

       
    }

    public void Exit() {

        Application.Quit();
    }
}
