using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EventSystem : MonoBehaviour
{
    private ManageProperties _manageProperties; 
    
    public GameObject eventObject;

    private TextMeshProUGUI _accidentText;
    private TextMeshProUGUI _positiveChoice;
    private TextMeshProUGUI _negativeChoice;

    public Button posButton;
    public Button negButton;

    public string[] accidents;
    public string[] positiveResponses;
    public string[] negativeResponses;

    private int x;

    private float _eventTimer = 0f;

    private void Start()
    {
        _manageProperties = GetComponent<ManageProperties>();
        
        _accidentText = eventObject.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
        _positiveChoice = eventObject.transform.GetChild(2).gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
        _negativeChoice = eventObject.transform.GetChild(3).gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    private void Update()
    {
        _eventTimer += Time.deltaTime;
        
        EventManage();
    }
    
    private void EventManage()
    {
        if (_eventTimer >= 5f)
        {
            _eventTimer = 0f;
            eventObject.SetActive(true);
            Time.timeScale = 0f;
            
            x = Random.Range(0, accidents.Length);
            _accidentText.text = accidents[x];
            _positiveChoice.text = positiveResponses[x];
            _negativeChoice.text = negativeResponses[x];
        }
    }

    public void Pos()
    {
        switch (x)
        {
            case 0:
                _manageProperties.polM = 5;
                break;
            case 1:
                _manageProperties.polM = 10;
                break;
            case 2:
                _manageProperties.polM = 15;
                break;
        }
    }
    
    public void Neg()
    {
        switch (x)
        {
            case 0:
                _manageProperties.polM = -5;
                break;
            case 1:
                _manageProperties.polM = -10;
                break;
            case 2:
                _manageProperties.polM = -15;
                break;
        }
    }
}
