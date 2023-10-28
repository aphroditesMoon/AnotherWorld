using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public string[] accidents;
    public string[] positiveResponses;
    public string[] negativeResponses;

    private int x;

    private float _eventTimer = 0f;
    
    private float timer = 0f;

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
        timer += Time.deltaTime;
        
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
                _manageProperties.polM = 3;
                _manageProperties.waterM = -2;
                _manageProperties.foodM = -2;
                break;
            case 1:
                _manageProperties.popM = 7;
                _manageProperties.polM = 2;
                _manageProperties.waterM = 2;
                break;
            case 2:
                _manageProperties.polM = 3;
                _manageProperties.waterM = -2;
                _manageProperties.foodM = -2;
                break;
            case 3:
                _manageProperties.polM = 2;
                _manageProperties.heatM = 2;
                break;
            case 4:
                _manageProperties.popM = 5;
                _manageProperties.foodM = 5;
                _manageProperties.waterM = 5;
                _manageProperties.polM = -5;
                break;
            case 5:
                _manageProperties.popM = 5;
                _manageProperties.polM = -5;
                _manageProperties.foodM = -1;
                _manageProperties.waterM = -1;
                break;
            case 6:
                _manageProperties.popM = 2;
                _manageProperties.polM = 2;
                _manageProperties.heatM = 1;
                _manageProperties.waterM = -3;
                _manageProperties.foodM = -3;
                break;
            case 7:
                _manageProperties.popM = 3;
                _manageProperties.polM = 10;
                _manageProperties.waterM = 2;
                _manageProperties.foodM = 2;
                break;
            case 8:
                _manageProperties.popM = 3;
                _manageProperties.polM = 10;
                _manageProperties.waterM = 2;
                _manageProperties.foodM = 2;
                break;
            case 9:
                _manageProperties.popM = 3;
                _manageProperties.foodM = 5;
                _manageProperties.waterM = 5;
                _manageProperties.polM = 2;
                _manageProperties.heatM = 5;
                break;
        }

        ResetAllProperties();
        eventObject.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Neg()
    {
        switch (x)
        {
            case 0:
                _manageProperties.popM = -5;
                _manageProperties.polM = -2;
                _manageProperties.heatM = -1;
                break;
            case 1:
                _manageProperties.popM = -15;
                _manageProperties.polM = 5;
                _manageProperties.foodM = 5;
                break;
            case 2:
                _manageProperties.popM = -5;
                _manageProperties.polM = -2;
                _manageProperties.foodM = 3;
                _manageProperties.waterM = -1;
                break;
            case 3:
                _manageProperties.popM = -4;
                _manageProperties.polM = -2;
                _manageProperties.heatM = -2;
                break;
            case 4:
                _manageProperties.popM = -5;
                _manageProperties.foodM = -5;
                _manageProperties.waterM = -5;
                _manageProperties.polM = 5;
                _manageProperties.heatM = 5;
                break;
            case 5:
                _manageProperties.polM = 1;
                _manageProperties.foodM = 1;
                _manageProperties.waterM = 1;
                break;
            case 6:
                _manageProperties.popM = -2;
                _manageProperties.polM = -1;
                _manageProperties.waterM = 1;
                _manageProperties.foodM = 1;
                break;
            case 7:
                _manageProperties.popM = -3;
                _manageProperties.polM = -5;
                _manageProperties.waterM = -2;
                _manageProperties.foodM = -2;
                break;
            case 8:
                _manageProperties.popM = -3;
                _manageProperties.polM = -5;
                _manageProperties.waterM = -2;
                _manageProperties.foodM = -2;
                break;
            case 9:
                _manageProperties.popM = -3;
                _manageProperties.foodM = -5;
                _manageProperties.waterM = -5;
                _manageProperties.polM = -2;
                _manageProperties.heatM = -5;
                break;
        }
        
        ResetAllProperties();
        eventObject.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public async void ResetAllProperties()
    {
        await Task.Delay(1000);
        _manageProperties.popM = 0;
        _manageProperties.polM = 0;
        _manageProperties.heatM = 0;
        _manageProperties.waterM = 0;
        _manageProperties.foodM = 0;
    }
}
