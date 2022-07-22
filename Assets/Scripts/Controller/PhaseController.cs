using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhaseController : MonoBehaviour
{
    public Text phase;
    public GameObject player;
    public GameObject Panel;
    private bool isPhase = false;
    private bool isOkClick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= 30) isPhase = true;

        if (Time.time >= 0 && !isPhase)
        {
            showPhase(1);
        }
        else if (Time.time >= 30 && isPhase)
        {
            Time.timeScale = 0;
            showPhase(2);
        }
        else if (Time.time >= 60)
        {
            isPhase = true;
            Time.timeScale = 0;
            showPhase(3);
        }
        //if (Time.time >= 120)
        //{
        //    Time.timeScale = 0;
        //    showPhase("Level 4");
        //}
    }

    void showPhase(byte Text)
    {
        switch (Text)
        {
            case 1: //Level 1
                break;
            case 2: //Level 2
                if (isPhase && !isOkClick)
                {
                    Cursor.visible = true;
                    player.SetActive(false);
                    Panel.SetActive(true);
                }
                else
                {
                    phase.text = "Level 2";
                    phase.CrossFadeAlpha(0f, 0.5f, false);
                }
                break;
            case 3: //Level 3
                break;
            default:
                break;
        }
    }

    public void continuePhase()
    {
        isOkClick = true;
        Cursor.visible = false;
        player.SetActive(true);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
}
