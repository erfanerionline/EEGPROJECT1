using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    private int speed = 2;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0, speed);
        //if (Time.time >= nextUpdate)
        //{
        //    // Change the next update (current second+1)
        //    nextUpdate = Mathf.FloorToInt(Time.time) + 8;
        //    transform.position = new Vector3(0,0, transform.position.z+40);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Destroy " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
