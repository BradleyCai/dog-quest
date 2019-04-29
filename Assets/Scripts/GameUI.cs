using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthbar;
    private int HP;
    private int maxHP;

    public Text kill_text;
    private int kill_num;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 1000;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreSystem();
    }

    private void ScoreSystem()
    {
        //the following codes are just for testing the show of text and slider
        kill_num++;
        kill_text.GetComponent<Text>().text = kill_num.ToString();

        HP--;
        healthbar.value = (float)HP / maxHP;

        //when the interface between enemies and player is finished, this function can be called to handle the scoring system
    }
}
