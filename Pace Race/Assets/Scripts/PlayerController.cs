using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int playerNumber;
    public CameraController camera;
    public CarController[] carControllers;
    public GameObject[] carObjects;
    public GameObject finishPanel;
    public Text finishText;
    public int active;

    private bool handled;

    // Use this for initialization
    void Start()
    {
        active = GameState.getCar(playerNumber);
        carObjects[active].SetActive(true);
        carControllers[active].setPlayer(playerNumber);
        camera.setPlayer(active);
        handled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void finish()
    {
        int place = GameState.getPlace();
        finishPanel.SetActive(true);
        camera.setUICull(true);
        string placeText;
        //finishText = finishPanel.add<TextMeshPro>();
        //finishText.colorGradientPreset = new TMP_ColorGradient(new Color(0xB9, 0x00, 0x00), new Color(0x5E, 0x00, 00), new Color(0x5E, 0x00, 0x00), new Color(0xB9, 0x00, 0x00));
        Debug.Log(place);
        if (place == 1)
            finishText.text = "You finished too soon";
        if (place == 2)
            finishText.text = "You win";
        if (place == 2 && !handled)
        {
            StartCoroutine(goToMenuSoon());
        }
    }

    private IEnumerator goToMenuSoon()
    {
        handled = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Opening Menu Scene");
    }

}
