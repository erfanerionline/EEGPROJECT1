using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour
{
    public ushort speed=15;
    private Rigidbody RB;


    public float turnSpeed = 4.0f;
    public float minTurnAngle = -40.0f;
    public float maxTurnAngle = 40.0f;
    private float rotX;

    //save output excel
    string filename = "";

    // Start is called before the first frame update
    void Start()
    {
        initCSV();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ////Add force
        RB.AddForce(transform.forward * speed);
        ////Rotation
        //transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        MouseAiming();

    }

    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collide :" + other.gameObject.name);
            WriteCSV(other);
        }
    }

    public void initCSV()
    {
        filename = Application.dataPath + "event_log.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("Time, Collide");
        tw.Close();
    }
    public void WriteCSV(Collider obj)
    {

        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine(Time.time+","+ obj.gameObject.name);

        tw.Close();
    }
}
