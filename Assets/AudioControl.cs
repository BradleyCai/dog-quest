using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControl : MonoBehaviour
{
    public GameObject objPrefabInstantSource;
    private GameObject musicInstant = null;

    void Start()
    {
        musicInstant = GameObject.FindGameObjectWithTag("Sound");
        if (musicInstant == null)
        {
            musicInstant = (GameObject)Instantiate(objPrefabInstantSource);
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
    
}
