using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject object0, object1;
    
    public void LevelLoad()
    {
        SceneManager.LoadScene("MechanicsProttype");
    }

    public void Credits()
    {
        object0.SetActive(false);
        object1.SetActive(true);
    }

    public void CreditsBack()
    {
        object0.SetActive(true);
        object1.SetActive(false);
    }

    public void Quitting()
    {
        Application.Quit();
    }
}
