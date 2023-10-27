using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WorldProperties", order = 1)]
public class WorldProperties : ScriptableObject
{
    [Range(0, 100)]
    public static int Population;
    [Range(0, 100)]
    public static int Pollution;
    [Range(0, 100)]
    public static int Heat;
    [Range(0, 100)]
    public static int Water;
    [Range(0, 100)]
    public static int Food;
}
