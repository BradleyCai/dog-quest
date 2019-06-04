using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour
{
    public Text textObj;
    public float charDelay;
    [TextArea(3,10)]
    public string[] lines;

    private int lineIndex;
    private int charIndex;
    private float time;

    void resetLine()
    {
        charIndex = 0;
        time = 0;
        textObj.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        resetLine();
        lineIndex = 0;
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.unscaledDeltaTime;
        if (Input.GetButtonDown("Submit")) {
            if (charIndex < lines[lineIndex].Length) {
                textObj.text = lines[lineIndex];
                charIndex = lines[lineIndex].Length;
                time = 0;
            }
            else {
                resetLine();
                lineIndex++;
                if (lineIndex >= lines.Length) {
                    Time.timeScale = 1.0f;
                    Destroy(this.gameObject);
                }
            }
        }
        else if (charIndex < lines[lineIndex].Length) {
            if (time > charDelay) {
                textObj.text = lines[lineIndex].Substring(0, ++charIndex);
                time = 0;
            }
        }
    }
}
