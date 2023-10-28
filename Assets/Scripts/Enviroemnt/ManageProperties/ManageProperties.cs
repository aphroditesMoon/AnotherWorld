using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public GameObject[] buildings;
    
    private float _timer = 0f;
    private float timer = 0f;
    
    private void Update()
    {
        Debug.Log(WorldProperties.Pollution);
        
        _timer += Time.deltaTime;
        timer += Time.deltaTime;

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
        if (WorldProperties.Population <= 0)
        {
            WorldProperties.Population = 0;
        }
        
        WorldProperties.Pollution += .0001f * polM;
        if (WorldProperties.Pollution <= 0)
        {
            WorldProperties.Pollution = 0;
        }
        
        WorldProperties.Heat += .0001f * heatM;
        if (WorldProperties.Heat <= 0)
        {
            WorldProperties.Heat = 0;
        }
        
        WorldProperties.Water += .0001f * waterM;
        if (WorldProperties.Water <= 0)
        {
            WorldProperties.Water = 0;
        }
        
        WorldProperties.Food += .0001f * foodM;
        if (WorldProperties.Food <= 0)
        {
            WorldProperties.Food = 0;
        }
    }

    private void CheckCitySituation()
    {
        switch (WorldProperties.Population)
        {
            case 20:
                buildings[0].SetActive(true);
                break;
            case 50:
                buildings[1].SetActive(true);
                break;
            case 80:
                buildings[2].SetActive(true);
                break;
            case 120:
                buildings[3].SetActive(true);
                break;
            case 150:
                buildings[4].SetActive(true);
                break;
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
            foodM = -1 * (int)WorldProperties.Population;
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
