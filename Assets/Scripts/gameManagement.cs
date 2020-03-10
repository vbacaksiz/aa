using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagement : MonoBehaviour
{
    GameObject rotatingCircle;
    GameObject mainCircle;
    public Animator animator;
    public Text rotatingCircleLevel;
    public Text text;
    public Text text2;
    public Text text3;
    public int numOfSmallCircle;
    bool control = true;
    void Start()
    {
        PlayerPrefs.SetInt("save",int.Parse(SceneManager.GetActiveScene().name));
        rotatingCircle = GameObject.FindGameObjectWithTag("rotatingCircleTag");
        mainCircle = GameObject.FindGameObjectWithTag("mainCircleTag");
        rotatingCircleLevel.text = SceneManager.GetActiveScene().name;

        if(numOfSmallCircle<2)
        {
            text.text = numOfSmallCircle + "";
        }
        else if(numOfSmallCircle<3)
        {
            text.text = numOfSmallCircle + "";
            text2.text = (numOfSmallCircle-1) + "";
        }
        else
        {
            text.text = numOfSmallCircle + "";
            text2.text = (numOfSmallCircle - 1) + "";
            text3.text = (numOfSmallCircle - 2) + "";
        }
    }

    public void smallCircleText()
    {
        numOfSmallCircle--;
        if (numOfSmallCircle < 2)
        {
            text.text = numOfSmallCircle + "";
            text2.text = "";
            text3.text = "";
        }
        else if (numOfSmallCircle < 3)
        {
            text.text = numOfSmallCircle + "";
            text2.text = (numOfSmallCircle - 1) + "";
            text3.text = "";
        }
        else
        {
            text.text = numOfSmallCircle + "";
            text2.text = (numOfSmallCircle - 1) + "";
            text3.text = (numOfSmallCircle - 2) + "";
        }
        if(numOfSmallCircle==0)
        {
            StartCoroutine(newLevel());
        }
    }

    IEnumerator newLevel()
    {
        rotatingCircle.GetComponent<rotate>().enabled = false;
        mainCircle.GetComponent<mainCircleCode>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if(control)
        {
            animator.SetTrigger("newLevel");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
        
    }


    public void gameOver()
    {
        StartCoroutine(gameOverMethod());
    }
    
    IEnumerator gameOverMethod()
    {
        rotatingCircle.GetComponent<rotate>().enabled = false;
        mainCircle.GetComponent<mainCircleCode>().enabled = false;
        animator.SetTrigger("gameOver");
        control = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("mainMenu");
    }
}
