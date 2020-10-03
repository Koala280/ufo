using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject shop, settings, mainMenu;

    void Start()
    {
        shop.SetActive(false);
        settings.SetActive(false);
    }
    public void EnterGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnterShop()
    {
        mainMenu.SetActive(false);
        shop.SetActive(true);
    }

    public void EnterSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void LeaveSettings()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);

    }

    public void LeaveShop()
    {
        mainMenu.SetActive(true);
        shop.SetActive(false);
    }
}
