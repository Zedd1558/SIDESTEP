
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject FR;
    public GameObject FL;
    public GameObject RR;
    public GameObject RL;
    public GameObject RB;

    public float forwardForce = 1000;
    public float sidewaysForce = 500;
    public float sidewaysForce1 = 500;
    public bool rightForce = false;
    public bool leftForce = true;
    private bool rightC, leftC;
    public void leftClick()
    {
        Debug.Log("left");
        leftC = true;
    }
    public void rightClick()
    {
        Debug.Log("right");
        rightC = true;
    }


    void Update()
    {

        if (Input.GetKey("d"))
        {
            rightForce = true;
        }    
        if(Input.GetKey("a"))
        {
            leftForce = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    /*
       if(!rightForce && !leftForce && !rightC && !leftC)
        {
            FR.transform.rotation = transform.rotation * Quaternion.Euler(0, 0,0);
            FL.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            RR.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            RL.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
        }
     */   
        FR.transform.Rotate(Vector3.down * Time.deltaTime*1000);
        FL.transform.Rotate(Vector3.down * Time.deltaTime * 1000);
        RR.transform.Rotate(Vector3.down * Time.deltaTime * 1000);
        RL.transform.Rotate(Vector3.down * Time.deltaTime * 1000);
        RB.transform.Rotate(Vector3.forward * Time.deltaTime * 100);

        if (rightForce)
        {
            
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); rightForce = false;

            float turnAngle = transform.eulerAngles.z + 10;
            if (turnAngle > 180 && turnAngle < 360 - 60)
                    turnAngle = 360 - 60;
            else if (turnAngle < 180 && turnAngle > 60)
                    turnAngle = 60;

            Debug.Log(turnAngle);

            FR.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, turnAngle);
            FL.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, turnAngle);

        }
        if(leftForce)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange); leftForce = false;
            float turnAngle = transform.eulerAngles.z - 10;
            if (turnAngle > 180 && turnAngle < 360 - 60)
                turnAngle = 360 - 60;
            else if (turnAngle < 180 && turnAngle > 60)
                turnAngle = 60;

            Debug.Log(turnAngle);

            FR.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, turnAngle);
            FL.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, turnAngle);
        }
        if (rightC)
        {
            rb.AddForce(sidewaysForce1 * Time.deltaTime, 0, 0, ForceMode.VelocityChange); rightC = false;
           
        }
        if (leftC)
        {
            rb.AddForce(-sidewaysForce1 * Time.deltaTime, 0, 0, ForceMode.VelocityChange); leftC = false;
           
        }
        if (rb.position.y < 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
