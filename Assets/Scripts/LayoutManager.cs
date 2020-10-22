using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayoutManager : MonoBehaviour
{
    public static LayoutManager instance;
    public GameObject shop, settings, menu, game, game_over, startscreen;
    public GameObject player;

    void Start()
    {
        instance = this;
        GameScript.instance.game_running = false;
        EnterMenu();
    }

    public void EnterGame()
    {
        GameScript.instance.game_running = true;
        startscreen.SetActive(false);
        game_over.SetActive(false);
        game.SetActive(true);
        player.SetActive(true);
        player.transform.position = new Vector3(0, -2.75f, -10);
    }

    public void EnterShop()
    {
        menu.SetActive(false);
        shop.SetActive(true);
    }

    public void LeaveShop()
    {
        EnterMenu();
        shop.SetActive(false);
    }

    public void EnterSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void LeaveSettings()
    {
        EnterMenu();
        settings.SetActive(false);
    }

    public void GameOver()
    {
        game_over.SetActive(true);
        player.SetActive(false);
    }

    public void EnterMenu()
    {
        shop.SetActive(false);
        settings.SetActive(false);
        game.SetActive(false);
        game_over.SetActive(false);
        startscreen.SetActive(true);
        menu.SetActive(true);   
    }
}
