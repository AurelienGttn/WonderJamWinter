using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasCredits;
    public GameObject canvasIntruction;
    public EventSystem eventSystem;
    public GameObject startButton;
    public GameObject backButton;
    public GameObject backButton2;



    public void Start()
    {
        canvasMenu.SetActive(true);
        canvasCredits.SetActive(false);
        canvasIntruction.SetActive(false);
        eventSystem.SetSelectedGameObject(startButton);
    }

    public void onClickbtn_Play()
    {
        GameObject score = GameObject.Find("Score");
        if (score != null)
        {
            GameObject.DestroyImmediate(score);
        }
        SceneManager.LoadScene(1);

    }


    public void onClickbtn_Menu()
    {
        SceneManager.LoadScene(0);

    }

    public void onClickIntructions()
    {
        StartCoroutine("menuToIntructions");
        eventSystem.SetSelectedGameObject(backButton2);
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
    public void onClickMenu_Intructions()
    {
        StartCoroutine("IntructionToMenu");
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


    public IEnumerator menuToIntructions()
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
        canvasIntruction.SetActive(false);

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


    public static void setAlphaObject(GameObject myObject, float a)
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

    public void Exit()
    {

        Application.Quit();
    }
}
