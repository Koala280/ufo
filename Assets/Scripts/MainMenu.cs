using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject shop, settings, mainMenu, game, game_over;

    void Start()
    {
        GameScript.instance.game_running = false;
        shop.SetActive(false);
        settings.SetActive(false);
        game.SetActive(false);
        game_over.SetActive(false);
    }

    public void EnterGame()
    {
        GameScript.instance.game_running = true;
        mainMenu.SetActive(false);
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
}
