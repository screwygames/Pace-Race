using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mm;
    public GameObject css;
    public Button startButton;
    public Button cssBackButton;
    public Button cssNextButton;


    public CharacterSelectScreenController cssc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playGame()
    {
        Debug.Log(mm.ToString());
        Debug.Log(cssc.ToString());
        Debug.Log(cssc.p1cs.ToString());
        Debug.Log(cssc.p1cs.cc.ToString());
        Debug.Log(cssc.p1cs.cc.getActive().ToString());
        GameState.setCars(cssc.p1cs.cc.getActive(), cssc.p2cs.cc.getActive(), cssc.p3cs.cc.getActive(), cssc.p4cs.cc.getActive());
        GameState.setLaps(3);
        SceneManager.LoadScene("Textured Level");
    }

    public void playGame2()
    {
        Debug.Log(mm.ToString());
        Debug.Log(cssc.ToString());
        Debug.Log(cssc.p1cs.ToString());
        Debug.Log(cssc.p1cs.cc.ToString());
        Debug.Log(cssc.p1cs.cc.getActive().ToString());
        GameState.setCars(cssc.p1cs.cc.getActive(), cssc.p2cs.cc.getActive(), cssc.p3cs.cc.getActive(), cssc.p4cs.cc.getActive());
        GameState.setLaps(6);
        SceneManager.LoadScene("SampleScene");
    }

    public void toCSS()
    {
        mm.SetActive(false);
        css.SetActive(true);
        cssNextButton.Select();
    }

    public void toMM()
    {
        mm.SetActive(true);
        css.SetActive(false);
        startButton.Select();
    }

    public void gtfo()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}