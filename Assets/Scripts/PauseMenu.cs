using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;
    public bool onOff; // I just wanted a value that is separate from canvas.enabled in case that causes problems
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        onOff = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onOff)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() // resumes pause screen
    {
        Time.timeScale = 1.0f;
        canvas.enabled = false;
        onOff = false;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        canvas.enabled = true;
        onOff = true;
    }

    public void Reload() // reloads level
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Return() // returns to title screen
    {
        SceneManager.LoadScene("TitleScreen"); // this means scene 0 needs to be the title screen
    }
}
