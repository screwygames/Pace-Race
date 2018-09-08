using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private const int CONT = 0;
    private const int WASD = 1;
    private const int ARROW = 2;


    public GameObject mm;
    public GameObject css;
    public GameObject om;
    public Button startButton;
    public Button cssBackButton;
    public Button cssNextButton;
    public TMP_Dropdown optionsDefault;

    private int[] controls = new int[4];

    public CharacterSelectScreenController cssc;
    // Use this for initialization
    void Start()
    {
        //set default controls
        GameState.setControls(1, "C1LeftJoyX", "C1Triggers");
        GameState.setControls(2, "C2LeftJoyX", "C2Triggers");
        GameState.setControls(3, "C3LeftJoyX", "C3Triggers");
        GameState.setControls(4, "C4LeftJoyX", "C4Triggers");
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
        om.SetActive(false);
        startButton.Select();
        Debug.Log(GameState.getControls(1)[0]);
        Debug.Log(GameState.getControls(2)[0]);
        Debug.Log(GameState.getControls(3)[0]);
        Debug.Log(GameState.getControls(4)[0]);
    }

    public void toOptions()
    {
        om.SetActive(true);
        mm.SetActive(false);
        optionsDefault.Select();
    }

    public void gtfo()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void setControls(int pnum, int controlScheme)
    {
        int nextController = 1;
        controls[pnum - 1] = controlScheme;
        for(int i = 0; i < 4; i++)
        {
            GameState.setControls(i + 1, getControlsByScheme(controls[i], nextController));
            if(controls[i] == CONT)
            {
                nextController++;
            }
        }
    }

    //nextController tracks how many previous players use controllers. For example p1 = wasd, p2 = controller, nextController = 2, so it knows to assign p3 controller 2 inputs
    public string[] getControlsByScheme(int scheme, int nextController)
    {
        switch(scheme)
        {
            case WASD:
                return new string[] { "KeyHorizontal", "KeyVertical" };
            case ARROW:
                return new string[] { "ArrowHorizontal", "ArrowVertical" };
            case CONT:
            default:
                return new string[] { string.Format("C{0}LeftJoyX", nextController), string.Format("C{0}Triggers", nextController) };
        }
    }
}