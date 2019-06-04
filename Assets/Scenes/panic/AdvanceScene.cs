using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{
    public string sceneName;

    void Start() {
        SceneManager.LoadScene(sceneName);
    }
}
