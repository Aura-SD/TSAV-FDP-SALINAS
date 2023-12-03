using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Salir();
        }
    }

    public void Salir()
    {
        Application.Quit();
    }
}
