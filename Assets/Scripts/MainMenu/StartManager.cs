using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Panel;
    [SerializeField]
    public Toggle fixationPoint;
    public bool isfixationPoint;
    public GameObject fixationPointImage;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartClick()
    {
        player.SetActive(true);
        Panel.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void TogglePoint()
    {
       fixationPoint.Select();
       isfixationPoint = fixationPoint.isOn;
       fixationPointImage.SetActive(isfixationPoint);
    }
}
