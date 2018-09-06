using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    public int playerNumber;
    public CarChoiceController cc;
    public float sleepTime;
    public Text playerHeader;
    public Text carName;

    private string horizontalAxis;
    private string aButton;
    private string bButton;
    private float lastTime;
    private string[] carNames;
    private int carIndex;

    // Use this for initialization
    void Start()
    {
        setPlayer(playerNumber);
        lastTime = Time.time;
        carNames = new string[] { "Flamin' Boxcar", "Popemobile", "Banana Supreme", "Spicy Sedan" };
        playerHeader.text = "Player " + playerNumber;
        carName.text = carNames[0];
        carIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        if (moveHorizontal > 0 && Time.time - lastTime > sleepTime)
        {
            updateCarIndex(1);
            cc.nextCar();
            carName.text = carNames[carIndex];
            lastTime = Time.time;
        }
        if (moveHorizontal < 0 && Time.time - lastTime > sleepTime)
        {
            updateCarIndex(-1);
            cc.lastCar();
            carName.text = carNames[carIndex];
            lastTime = Time.time;
        }
    }

    public void setPlayer(int pn)
    {
        playerNumber = pn;
        switch (playerNumber)
        {
            case 1:
                horizontalAxis = "C1XAxis";
                aButton = "C1AButton";
                bButton = "C1BButton";
                break;
            case 2:
                horizontalAxis = "C2XAxis";
                aButton = "C2AButton";
                bButton = "C2BButton";
                break;
            case 3:
                horizontalAxis = "C3XAxis";
                aButton = "C3AButton";
                bButton = "C3BButton";
                break;
            case 4:
                horizontalAxis = "C4XAxis";
                aButton = "C4AButton";
                bButton = "C4BButton";
                break;
            default:
                horizontalAxis = "C1XAxis";
                aButton = "C1AButton";
                bButton = "C1BButton";
                break;

        }
    }
    public void updateCarIndex(int u)
    {
        carIndex += u;
        if (carIndex < 0)
        {
            carIndex = 3;
        }
        if (carIndex > 3)
        {
            carIndex = 0;
        }
    }
}
