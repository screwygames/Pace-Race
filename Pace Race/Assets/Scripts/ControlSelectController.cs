using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSelectController : MonoBehaviour
{
    public int playerNumber;
    public MainMenu panel;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void updateControls(int scheme)
    {
        Debug.Log(playerNumber);
        panel.setControls(playerNumber, scheme);
    }

}
