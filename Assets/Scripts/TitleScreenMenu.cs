using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // The title screen at the start needs to be able to read what levels are available and disable the buttons as appropriate
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void GoToAutumn()
    {
        //SceneManager.LoadScene("LevelAutumn");
    }

    public void GoToWinter()
    {
        //SceneManager.LoadScene("LevelWinter");
    }

    public void GoToSpring()
    {
        //SceneManager.LoadScene("LevelSpring");
    }

    public void GoToSummer()
    {
        //SceneManager.LoadScene("LevelSummer");
    }

    public void GoToUnknown()
    {
        //SceneManager.LoadScene("LevelUnknown");
    }

}
