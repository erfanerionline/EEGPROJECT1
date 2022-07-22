using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;

    private int nextUpdate = 1;
    private int nextGenerate = 1;
    private int multiply = 1;
    private int spaceBetween = 40;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 20; i++)
        {
            //Rand x,y position
            int X = Random.Range(-2, 2);
            int Y = Random.Range(-2, 2);

            Instantiate(Obstacle).transform.position = new Vector3(X, Y, i * spaceBetween);
        }
    }

    // Update is called once per frame
    void Update()
    {
        generateObstacle();
    }

    void generateObstacle()
    {
        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            //Change the next update(current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;

            if (Time.time >= nextGenerate)
            {
                GameObject obstacle = Instantiate(Obstacle);
                if (Time.time > 0 && Time.time <= 30)
                {
                    //obstacle.transform.localScale = new Vector3(3f, 3f, 0.5f);
                    Debug.Log("(PLAYING Level 1)"); //since i created level one with for loop at start
                    obstacle.transform.localScale = new Vector3(1f, 1f, 1f);
                    Debug.Log("Generating Level 2 obstacles" + obstacle.transform.localScale);
                }
                if (Time.time > 30 && Time.time < 90)
                {
                    obstacle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Debug.Log("(PLAYING Level 2)");
                    Debug.Log("Generating Level 3 obstacles" + obstacle.transform.localScale);
                }
                if (Time.time > 90)
                {
                    obstacle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    Debug.Log("Level 3 " + obstacle.transform.localScale);
                }


                //Rand x,y position
                int X = Random.Range(-5, 5);
                int Y = Random.Range(-2, 2);

                obstacle.transform.position = new Vector3(X, Y, (spaceBetween * 20) + spaceBetween * multiply);
                multiply++;
                nextGenerate = Mathf.FloorToInt(Time.time + 2f);
            }
        }
    }
}
