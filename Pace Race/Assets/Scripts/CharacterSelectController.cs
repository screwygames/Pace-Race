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

    public void OnEnable()
    {
        string[] controlsStr = GameState.getControls(playerNumber);
        horizontalAxis = controlsStr[0];
    }

    public void setPlayer(int pn)
    {
        playerNumber = pn;
        string[] controlsStr = GameState.getControls(pn);
        horizontalAxis = controlsStr[0];
        Debug.Log(GameState.getControls(playerNumber)[0]);
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
