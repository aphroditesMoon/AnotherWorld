using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageProperties : MonoBehaviour
{
    public EventSystem eventSystem;
    
    public bool pop, pol, heat, water, food;
    public int popM, polM, heatM, waterM, foodM;
    
    public Slider PopImage;
    public Slider PolImage;
    public Slider HeatImage;
    public Slider WaterImage;
    public Slider FoodImage;

    public GameObject waterObject;
    private Vector3 preScale;
    private Vector3 newScale;

    public GameObject[] buildings;
    public GameObject[] plants;
    
    private float _timer = 0f;
    private float timer = 0f;

    private void Start()
    {
        preScale = waterObject.gameObject.transform.localScale;
    }

    private void Update()
    {
        Debug.Log(WorldProperties.Pollution);
        
        _timer += Time.deltaTime;
        timer += Time.deltaTime;

        newScale = new Vector3(preScale.x + WorldProperties.Water + 1f, preScale.y + WorldProperties.Water  + 1f,
            preScale.z + WorldProperties.Water + 1f);

        waterObject.transform.localScale = newScale;

        PopImage.value = WorldProperties.Population;
        PolImage.value = WorldProperties.Pollution;
        HeatImage.value = WorldProperties.Heat;
        WaterImage.value = WorldProperties.Water;
        FoodImage.value = WorldProperties.Food;
        
        Switchs();
        CheckCitySituation();
        CheckStaticSituations();
    }

    public void Switchs()
    {
        WorldProperties.Population += .1f * popM;
        string formattedValue0 = WorldProperties.Population.ToString("F0");
        PopImage.GetComponentInChildren<TextMeshProUGUI>().text = formattedValue0 + "/ 500";
        if (WorldProperties.Population <= 0)
        {
            WorldProperties.Population = 0;
        }
        
        WorldProperties.Pollution += .0005f * polM;
        string formattedValue1 = WorldProperties.Pollution.ToString("F2");
        PolImage.GetComponentInChildren<TextMeshProUGUI>().text = formattedValue1 + "/ 5.00";
        if (WorldProperties.Pollution <= 0)
        {
            WorldProperties.Pollution = 0;
        }
        
        WorldProperties.Heat += .0005f * heatM;
        string formattedValue2 = WorldProperties.Heat.ToString("F2");
        HeatImage.GetComponentInChildren<TextMeshProUGUI>().text = formattedValue2 + "/ 5.00";
        if (WorldProperties.Heat <= 0)
        {
            WorldProperties.Heat = 0;
        }
        
        WorldProperties.Water += .0005f * waterM;
        string formattedValue3 = WorldProperties.Water.ToString("F2");
        WaterImage.GetComponentInChildren<TextMeshProUGUI>().text = formattedValue3 + "/ 5.00";
        if (WorldProperties.Water <= 0)
        {
            WorldProperties.Water = 0;
        }
        
        WorldProperties.Food += .0005f * foodM;
        string formattedValue4 = WorldProperties.Food.ToString("F2");
        FoodImage.GetComponentInChildren<TextMeshProUGUI>().text = formattedValue4 + "/ 10.00";
        if (WorldProperties.Food <= 0)
        {
            WorldProperties.Food = 0;
        }
    }

    private void CheckCitySituation()
    {
        if (WorldProperties.Population >= 51)
        {
            buildings[0].SetActive(true);
            plants[0].SetActive(true);
        }

        if (WorldProperties.Population >= 100)
        {
            buildings[1].SetActive(true);
            plants[1].SetActive(true);
        }

        if (WorldProperties.Population >= 200)
        {
            buildings[2].SetActive(true);
            plants[2].SetActive(true);
        }

        if (WorldProperties.Population >= 300)
        {
            buildings[3].SetActive(true);
            plants[3].SetActive(true);
        }

        if (WorldProperties.Population >= 400)
        {
            buildings[4].SetActive(true);
            plants[4].SetActive(true);
            plants[5].SetActive(true);
        }

    }

    private bool x = true, xx = true;
    private void CheckStaticSituations()
    {
        if (WorldProperties.Food >= 10 && x)
        {
            polM = 1;
            popM = 5;
            x = false;
            eventSystem.ResetAllProperties();
        }

        if (WorldProperties.Pollution >= 5 && WorldProperties.Heat >= 5 && xx)
        {
            waterM = -3;
            popM = -10;
            xx = false;
            eventSystem.ResetAllProperties();
        }

        if (timer >= 5)
        {
            timer = 0f;
            foodM = -2;
            polM = -2;
            heatM = 1;                                                                                                                                                                                                                                                           
            eventSystem.ResetAllProperties();
        }

        if (WorldProperties.Food <= 0)
        {
            popM = -5;
            eventSystem.ResetAllProperties();
        }
        
        if (WorldProperties.Water <= 0)
        {
            popM = -30;
            eventSystem.ResetAllProperties();
        }
    }
}
