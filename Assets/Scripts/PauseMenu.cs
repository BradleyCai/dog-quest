using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;
    public bool onOff; // I just wanted a value that is separate from canvas.enabled in case that causes problems
     private bool isMute;
    public Button soundBt;
    public Sprite mute_img;
    public Sprite sound_img;
    public AudioSource background_music; //change this public interface into a suitable music
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        onOff = false;
        Time.timeScale = 1.0f;
        isMute = false;
        btn = soundBt.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            isMute = !isMute;
            MuteControl(isMute);
            if (isMute)
            {
                btn.GetComponent<Image>().sprite = mute_img;
            }
            else
            {
                btn.GetComponent<Image>().sprite = sound_img;
            }
        }); //change the image when click on the sound button
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
private void MuteControl(bool flag)//control on and off of BGM
    {
        if (!isMute)
        {
            background_music.Play();
        }
        else
        {
            background_music.Pause();
        }
    }
}
