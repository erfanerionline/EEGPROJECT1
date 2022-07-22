using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;

    private int nextUpdate = 2; //start form 4 (because We already created obstacles at start)
    private int nextGenerate = 8;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        for (int i = 1; i <= 4; i++)
        {
            //Rand x,y position
            int X = Random.Range(-5, 5);
            int Y = Random.Range(-2, 2);

            Instantiate(Obstacle).transform.position = new Vector3(X, Y, i * 40);
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
            GameObject obstacle = Instantiate(Obstacle);
            if (Time.time > 0 && Time.time <= 30)
            {
                obstacle.transform.localScale = new Vector3(3f, 3f, 0.5f);
                Debug.Log("Level 1 " + obstacle.transform.localScale);
            }
            if (Time.time > 30 && Time.time < 90)
            {
                obstacle.transform.localScale = new Vector3(1.5f, 1.5f, 0.5f);
                Debug.Log("Level 2 " + obstacle.transform.localScale);
            }
            if (Time.time > 90)
            {
                obstacle.transform.localScale = new Vector3(1f, 1f, 0.5f);
                Debug.Log("Level 3 " + obstacle.transform.localScale);
            }
            Debug.Log(Time.time + ">=" + nextUpdate);
            //Change the next update(current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;

            //Rand x,y position
            int X = Random.Range(-5, 5);
            int Y = Random.Range(-2, 2);
            if (Time.time >= nextGenerate)
            {
                obstacle.transform.position = new Vector3(X, Y, nextUpdate * 25);
                nextGenerate = Mathf.FloorToInt(Time.time) + 2;
            }
        }
    }
}
