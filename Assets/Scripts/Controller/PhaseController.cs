using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PhaseController : MonoBehaviour
{
    public Text phase;
    public GameObject player;
    public GameObject Panel;
    public Slider[] slider;

    private bool isPhase = false;
    private bool isOkClick2, isOkClick3, isOkClick4 = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = Panel.GetComponentsInChildren<Slider>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= 30) isPhase = true;

        if (Time.time >= 0 && !isPhase)
        {
            showPhase(1);
        }
        else if (Time.time >= 30 && isPhase && !isOkClick2 && !isOkClick3)
        {
            Time.timeScale = 0;
            showPhase(2);
        }
        if (Time.time >= 60 && isOkClick2 && !isOkClick3)
        {
            Time.timeScale = 0;
            showPhase(3);
        }
        if (Time.time >= 90 && !isOkClick4)
        {
            Time.timeScale = 0;
            showPhase(4);
        }
        else if (isOkClick4)
        {
            Time.timeScale = 0;
            //SceneManager.E(SceneManager.GetActiveScene().buildIndex);
            Application.Quit();
        }
    }

    void showPhase(byte Text)
    {
        switch (Text)
        {
            case 1: //Level 1
                break;
            case 2: //Level 2
                if (isPhase && isOkClick2 == false)
                {
                    Cursor.visible = true;
                    player.SetActive(false);
                    Panel.SetActive(true);
                }
                    phase.text = "Level 2";
                    phase.CrossFadeAlpha(0f, 0.5f, false);
                break;
            case 3: //Level 3
                if (isPhase && isOkClick3 == false)
                {
                    Cursor.visible = true;
                    player.SetActive(false);
                    Panel.SetActive(true);
                }
                else
                {
                    phase.text = "Level 3";
                    phase.CrossFadeAlpha(0f, 0.5f, false);
                }
                break;
            case 4: //Level 4
                if (isPhase && isOkClick4 == false)
                {
                    Cursor.visible = true;
                    player.SetActive(false);
                    Panel.SetActive(true);
                }
                else
                {
                    phase.text = "Level 4";
                    phase.CrossFadeAlpha(0f, 0.5f, false);
                }
                break;
            default:
                break;
        }
    }

    public void continuePhase()
    {
        isOkClick2 = Time.time >= 30 && Time.time < 31 ? true : false;
        isOkClick3 = Time.time >= 60 && Time.time < 61 ? true : false;
        isOkClick4 = Time.time >= 90 ? true : false;

        //Write csv
        WriteCSV();

        Cursor.visible = false;
        player.SetActive(true);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void WriteCSV()
    {
        string filename = Application.dataPath + "event_log.csv";
        TextWriter tw = new StreamWriter(filename, true);
        foreach (var item in slider)
        {
            Debug.Log(item.value);
        }
        tw.WriteLine(Time.time + "," + " " + "," + slider[0].value);
        tw.WriteLine(Time.time + "," + " " + "," + slider[1].value);
        tw.WriteLine(Time.time + "," + " " + "," + slider[2].value);

        for (int i = 0; i < 3; i++)
        {
            slider[i].value = 5;
        }

        tw.Close();
    }
}
