using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCond : MonoBehaviour
{
    private ManageProperties _manageProperties;
    private EventSystem _eventSystem;

    public GameObject deadScreen;

    private void Start()
    {
        _manageProperties = GetComponent<ManageProperties>();
        _eventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        LoseConditions();
    }

    private void LoseConditions()
    {
        if (WorldProperties.Heat == 5 || WorldProperties.Heat == 0 || WorldProperties.Water == 0 || WorldProperties.Food == 0)
        {
            _manageProperties.popM = -3;
        }

        if (WorldProperties.Population == 0)
        {
            deadScreen.SetActive(true);
        }
    }
}
