using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goals : PlayerController
{

    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && count == 4)
        {
            winText.gameObject.SetActive(true);
        }
        else
        {
            findMoreKeysText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        findMoreKeysText.gameObject.SetActive(false);
    }
}
