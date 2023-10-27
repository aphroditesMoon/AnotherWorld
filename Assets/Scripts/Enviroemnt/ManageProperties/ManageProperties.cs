using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ManageProperties : MonoBehaviour
{
    public bool pop, pol, heat, water, food;
    public int popM, polM, heatM, waterM, foodM;
    
    private float _timer = 0f;
    
    private void Update()
    {
        Debug.Log(WorldProperties.Population);
        Debug.Log(WorldProperties.Pollution);
        
        _timer += Time.deltaTime;
        
        Switchs();
    }

    public void Switchs()
    {
        if (_timer >= 1f)
        {
            _timer = 0f;
            
            if (pop)  WorldProperties.Population += 1 * popM;
        
            if (pol)  WorldProperties.Pollution += 1 * polM;
        
            if (heat) WorldProperties.Heat += 1 * heatM;
        
            if (water) WorldProperties.Water += 1 * waterM;
        
            if (food) WorldProperties.Food += 1 * foodM;
        }
    }
    
    // public bool inCasualSituation;
    //
    // private void CasualSituations()
    // {
    //     if (timer >= 1f)
    //     {
    //         timer = 0f;
    //         if (inCasualSituation)
    //         {
    //             WorldProperties.Population += 1;
    //         }
    //     }
    // }
}
