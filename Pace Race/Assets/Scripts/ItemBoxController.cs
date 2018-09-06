using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour
{
	void Start()
    {
		
	}
	
	void Update()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        Invoke("Respawn", 3);
    }

    void Respawn()
    {
        gameObject.SetActive(true);
    }
}
