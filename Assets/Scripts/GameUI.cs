using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Slider healthbar;

    public GameObject menu;

    public Text kill_text;
    private int kill_num;

    private EnemyHP enemy1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the following codes are just for testing the show of text
         kill_num++;
         kill_text.GetComponent<Text>().text = kill_num.ToString();
    }

    public void scoreSystem()
    {
        //when the interface between enemies and player is finished, this function can be called to handle the scoring system
    }

    public void onPause()
    {
        Time.timeScale = 0; //this doesn't affect Update()
        menu.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }

    public void onRestart()
    {
        SceneManager.LoadScene(0);
    }
}
