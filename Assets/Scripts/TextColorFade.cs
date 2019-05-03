using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorFade : MonoBehaviour
{
    private Text t;

    public List<Color> colors;
    private int colorsIndex;

    public List<float> cycles;
    private int cyclesIndex;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        t = this.GetComponent<Text>();
        t.color = colors[0];

        time = 0.0f;

        colorsIndex = 0;

        // The following code is for correcting mismatches between the number of cycles and colors

        if (cycles.Count < colors.Count)
        {
            Debug.Log("Number of cycles and colors do not match");
            int j = colors.Count - cycles.Count;
            for (int i = 0; i < j; i++)
            {
                cycles.Add(1.0f);
            }
        }

        if (colors.Count < cycles.Count)
        {
            Debug.Log("Number of cycles and colors do not match");
            int j = cycles.Count - colors.Count;
            for (int i = 0; i < j; i++)
            {
                colors.Add(Color.black);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Interpolates Colors

        if (colorsIndex < colors.Count - 1)
        {
            t.color = Color.Lerp(colors[colorsIndex], colors[colorsIndex + 1], time / cycles[cyclesIndex]);
        }
        else
        {
            t.color = Color.Lerp(colors[colorsIndex], colors[0], time / cycles[cyclesIndex]);
        }

        // Updates Indeces

        if (time >= cycles[cyclesIndex])
        {
            colorsIndex++;
            cyclesIndex++;
            if (colorsIndex >= colors.Count)
            {
                colorsIndex = 0;
                cyclesIndex = 0;
            }
            time = 0;
        }

        // Tracks time

        time += Time.deltaTime;
    }
}
