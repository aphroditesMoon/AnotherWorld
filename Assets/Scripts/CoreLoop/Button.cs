using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject GameObject;
    public GameObject GameObject2;

    private void Update()
    {
        if (GameObject2.gameObject.activeInHierarchy)
        {
            GameObject.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else
        {
            GameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
}
