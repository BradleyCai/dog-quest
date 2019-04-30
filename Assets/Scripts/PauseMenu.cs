using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            canvas.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 1.0f;
            canvas.enabled = false;
        }
    }
}
