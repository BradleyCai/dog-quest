using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorFade : MonoBehaviour
{
    private Text t;

    public Color color1, color2;

    private bool swap;

    private float time;
    public float cycle = 1;

    // Start is called before the first frame update
    void Start()
    {
        t = this.GetComponent<Text>();
        t.color = color1;

        time = 0.0f;

        swap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (swap)
        {
            t.color = Color.Lerp(color1, color2, time / cycle);
            if (time >= cycle)
            {
                swap = false;
                time = 0;
            }
        }
        else
        {
            t.color = Color.Lerp(color2, color1, time / cycle);
            if (time >= cycle)
            {
                swap = true;
                time = 0;
            }
        }
         
        time += Time.deltaTime;
    }
}
