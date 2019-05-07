using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public Canvas titleMenu;

    public Button autumnB;
    public Button winterB;
    public Button springB;
    public Button summerB;
    public Button unknownB;

    public enum Unlocks { L1, L2, L3, L4, L5 };
    public Unlocks u;

    

    // Start is called before the first frame update
    void Start()
    {
        u = Unlocks.L1;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (u)
        {
            case Unlocks.L1:
                autumnB.interactable = true;
                winterB.interactable = false;
                springB.interactable = false;
                summerB.interactable = false;
                unknownB.interactable = false;
                unknownB.image.enabled = false;
                unknownB.gameObject.transform.Find("Text").GetComponent<Text>().enabled = false;
                break;
            case Unlocks.L2:
                autumnB.interactable = true;
                winterB.interactable = true;
                springB.interactable = false;
                summerB.interactable = false;
                unknownB.enabled = false;
                unknownB.image.enabled = false;
                unknownB.gameObject.transform.Find("Text").GetComponent<Text>().enabled = false;
                break;
            case Unlocks.L3:
                autumnB.interactable = true;
                winterB.interactable = true;
                springB.interactable = true;
                summerB.interactable = false;
                unknownB.enabled = false;
                unknownB.image.enabled = false;
                unknownB.gameObject.transform.Find("Text").GetComponent<Text>().enabled = false;
                break;
            case Unlocks.L4:
                autumnB.interactable = true;
                winterB.interactable = true;
                springB.interactable = true;
                summerB.interactable = true;
                unknownB.enabled = false;
                unknownB.image.enabled = false;
                unknownB.gameObject.transform.Find("Text").GetComponent<Text>().enabled = false;
                break;
            case Unlocks.L5:
                autumnB.interactable = true;
                winterB.interactable = true;
                springB.interactable = true;
                summerB.interactable = true;
                unknownB.interactable = true;
                unknownB.image.enabled = true;
                unknownB.gameObject.transform.Find("Text").GetComponent<Text>().enabled = true;
                break;
            default:
                break;
        }
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

    public void GoBack()
    {
        titleMenu.enabled = true;
        this.GetComponent<Canvas>().enabled = false;
    }

    
}
