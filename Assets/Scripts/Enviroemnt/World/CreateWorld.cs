using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorld : MonoBehaviour
{
    public GameObject Building;
    public GameObject Pollution;
    public GameObject Heat;
    public GameObject Water;
    public GameObject Food;

    private void Start()
    {
        if (Pollution != null)
        {
            MeshRenderer pollutionRenderer = Pollution.GetComponent<MeshRenderer>();
            if (pollutionRenderer != null)
            {
                pollutionRenderer.material.color = Color.red;
            }
        }
    }
}
