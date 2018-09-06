using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoiceController : MonoBehaviour {

    public GameObject[] carChoices;

    private int active;

	// Use this for initialization
	void Start ()
    {
	    if(carChoices.Length > 0)
        {
            carChoices[0].SetActive(true);
            for (int x = 1; x >= carChoices.Length; x++)
            {
                carChoices[x].SetActive(false);
            }
        }
        active = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void nextCar()
    {
        carChoices[active].SetActive(false);
        if (active + 1 == carChoices.Length)
        {
            active = 0;
        }
        else
        {
            active++;
        }
        carChoices[active].SetActive(true);
    }

    public void lastCar()
    {
        carChoices[active].SetActive(false);
        if (active - 1 == -1)
        {
            active = carChoices.Length - 1;
        }
        else
        {
            active--;
        }
        carChoices[active].SetActive(true);
    }

    public int getActive()
    {
        return active;
    }
}
