using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : MonoBehaviour
{
    public Canvas levelSelect;

    // Start is called before the first frame update
    void Start()
    {
        // The title screen at the start needs to be able to read what levels are available and disable the buttons as appropriate
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void GameStart()
    {
        SceneManager.LoadScene("AutumnLevel");
    }

    public void LevelSelect()
    {
        levelSelect.enabled = true;
        this.GetComponent<Canvas>().enabled = false;
    }

}
