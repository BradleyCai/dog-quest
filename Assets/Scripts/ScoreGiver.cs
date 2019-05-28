using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    [SerializeField] int scoreOnDeath;

    private GameObject statusUI;

    private void Start()
    {
        statusUI = GameObject.FindGameObjectWithTag("StatusUI");
    }

    private void OnDestroy()
    {
        statusUI.GetComponent<StatusUI>().scoreCount += scoreOnDeath;
    }
}
