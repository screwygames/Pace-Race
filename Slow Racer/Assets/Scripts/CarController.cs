using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed;
    public float minSpeed;
    public float maxSpeed;
    public PlayerController player;

    public int lapNum;
    public int lapPosition;

    private string horizontalAxis;
    private string gasAxis;
    private Rigidbody rb;
    private int playerNumber;
    private Vector3 velocity = Vector3.zero;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        lapNum = 1;
        lapPosition = -1;
    }
	
	void FixedUpdate ()
    {
        //rb.angularVelocity = new Vector3(0, 0, 0);
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(gasAxis);

        Vector3 oldAV = rb.angularVelocity;
        Vector3 rotation = new Vector3(0.0f, moveHorizontal, 0.0f);
        Vector3 movement = rb.transform.forward * acceleration * moveVertical;
        float oldy = transform.eulerAngles.y;
        
        //rotate correctly
        rb.transform.Rotate(new Vector3(0.0f, moveHorizontal * Time.deltaTime * turnSpeed, 0.0f));

        //accelerate if its upright
        if (!isAirborne() && !isFalling())
        {
            rb.velocity = Quaternion.Euler(0, transform.eulerAngles.y - oldy, 0) * rb.velocity;
            rb.AddForce(movement * acceleration, ForceMode.Acceleration);
        }

        //check for falling into the abyss
        if (isFalling() || isTilted())
        {
            switch(lapPosition)
            {
                //sends you forward a checkpoint if you fall off
                case -1:
                    transform.position = new Vector3(40, -141, -440);
                    transform.eulerAngles = new Vector3(0, -75, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 0:
                    transform.position = new Vector3(-147, -141, -320);
                    transform.eulerAngles = new Vector3(0, 30, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 1:
                    transform.position = new Vector3(-11, -141, -271);
                    transform.eulerAngles = new Vector3(0, 3, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 2:
                    transform.position = new Vector3(0, -141, -2);
                    transform.eulerAngles = new Vector3(0, 352, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 3:
                    transform.position = new Vector3(19, -141, 149);
                    transform.eulerAngles = new Vector3(0, 141, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 4:
                    transform.position = new Vector3(136, -141, -131);
                    transform.eulerAngles = new Vector3(0, 165, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 5:
                    transform.position = new Vector3(369, -141, -175);
                    transform.eulerAngles = new Vector3(0, 250, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 6:
                    transform.position = new Vector3(223, -141, -487);
                    transform.eulerAngles = new Vector3(0, -75, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
                case 7:
                    transform.position = new Vector3(40, -141, -440);
                    transform.eulerAngles = new Vector3(0, -75, 0);
                    rb.velocity = new Vector3(0, 0, 0);
                    break;
            }
        }

        //cap speed
        if (Math.Abs(rb.velocity.magnitude) > maxSpeed)
        {
            rb.velocity = rb.velocity * maxSpeed / rb.velocity.magnitude;
        }

        //ensure you are going the minimum speed
        //if (Math.Abs(rb.velocity.magnitude) < minSpeed && !isFalling() && !isAirborne())
        //{
        //    Vector3 moveFaster = rb.transform.forward * acceleration * minSpeed;
        //    rb.AddForce(moveFaster * acceleration, ForceMode.Acceleration);
        //}

        //correct angular velocity
        //if (rb.angularVelocity.magnitude > 10)
        //{
        //    rb.angularVelocity = oldAV;
        //}
    }

    bool isTilted()
    {
        if (isGoodNumber(transform.eulerAngles.x) || isGoodNumber(transform.eulerAngles.z))
            return true;
        return false;
    }

    void UpdateLap()
    {
        if(lapNum == GameState.getLaps())
        {
            player.finish();
        }
        lapNum++;
    }

    //returns true if the vehicle isn't falling of into the void
    Boolean isFalling()
    {
        if(transform.position.y <= -142.25)
        {
            return true; 
        }
        return false;
    }

    Boolean isAirborne()
    {
        if(transform.position.y >= 1)
        {
            return true;
        }
        return false;
    }

    Boolean isGoodNumber(float x)
    {
        if (x > 75 && x < 285)
            return true;
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("itembox"))
        {
            print("you got an item");
        }
        else
        {
            switch (lapPosition)
            {
                case -1:
                    if (other.gameObject.CompareTag("trigger0"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 0:
                    if (other.gameObject.CompareTag("trigger1"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 1:
                    if (other.gameObject.CompareTag("trigger2"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 2:
                    if (other.gameObject.CompareTag("trigger3"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 3:
                    if (other.gameObject.CompareTag("trigger4"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 4:
                    if (other.gameObject.CompareTag("trigger5"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 5:
                    if (other.gameObject.CompareTag("trigger6"))
                    {
                        print("here");
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 6:
                    if (other.gameObject.CompareTag("trigger7"))
                    {
                        lapPosition++;
                        print(lapPosition);
                    };
                    break;
                case 7:
                    if (other.gameObject.CompareTag("trigger0"))
                    {
                        lapPosition = 0;
                        print(lapPosition);
                        UpdateLap();
                    };
                    break;
            }
        }
    }

    public void setPlayer(int pn)
    {
        playerNumber = pn;
        switch (playerNumber)
        {
            case 1:
                horizontalAxis = "C1XAxis";
                gasAxis = "C1GasAxis";
                break;
            case 2:
                horizontalAxis = "C2XAxis";
                gasAxis = "C2GasAxis";
                break;
            case 3:
                horizontalAxis = "C3XAxis";
                gasAxis = "C3GasAxis";
                break;
            case 4:
                horizontalAxis = "C4XAxis";
                gasAxis = "C4GasAxis";
                break;
            default:
                horizontalAxis = "Horizontal";
                gasAxis = "Vertical";
                break;
        }
    }
}
