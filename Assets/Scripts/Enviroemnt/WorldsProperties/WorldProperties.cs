using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WorldProperties", order = 1)]
public class WorldProperties : ScriptableObject
{
    public static float Population = 50;
    [Range(0, 5)]
    public static float Pollution = 2;
    [Range(0, 5)]
    public static float Heat = 2;
    [Range(0, 5)]
    public static float Water = 2;
    [Range(0, 10)]
    public static float Food = 2;
}
