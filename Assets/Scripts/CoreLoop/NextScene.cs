using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void FNC()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        WorldProperties.Population = 50;
        WorldProperties.Pollution = 2;
        WorldProperties.Food = 2;
        WorldProperties.Heat = 2;
        WorldProperties.Water = 2;
    }
}
