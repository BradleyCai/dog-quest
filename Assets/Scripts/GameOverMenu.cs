using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject player;

    public Canvas canvas;
    public Text gameOverText;
    public Text continueText;

    public Color c1, c2, c3, c4;
    public float colorPeriod1;
    public float colorPeriod2;
    private bool colorPhase1;
    private bool colorPhase2;

    private float time1;
    private float time2;
    

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;

        gameOverText.color = c1;
        continueText.color = c3;

        time1 = 0;
        time2 = 0;

        colorPhase1 = true;
        colorPhase2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.Log("player destroyed");
            canvas.enabled = true;
        }

        // text color change 

        if (colorPhase1)
        {
            gameOverText.color = Color.Lerp(c1, c2, time1 / colorPeriod1);
            if (time1 >= colorPeriod1)
            {
                time1 = 0;
                colorPhase1 = false;
            }
        }
        else
        {
            gameOverText.color = Color.Lerp(c2, c1, time1 / colorPeriod1);
            if (time1 >= colorPeriod1)
            {
                time1 = 0;
                colorPhase1 = true;
            }
        }

        if (colorPhase2)
        {
            continueText.color = Color.Lerp(c3, c4, time2 / colorPeriod2);
            if (time2 >= colorPeriod2)
            {
                time2 = 0;
                colorPhase2 = false;
            }
        }
        else
        {
            continueText.color = Color.Lerp(c4, c3, time2 / colorPeriod2);
            if (time2 >= colorPeriod2)
            {
                time2 = 0;
                colorPhase2 = true;
            }
        }
        

        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
    }

    public void Retry()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Return()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("TitleScreen");
    }
}
