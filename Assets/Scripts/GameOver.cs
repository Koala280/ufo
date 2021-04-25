using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;

    public void RestartGame()
    {
        ObjectPooler.instance.DeactivatePooledObjects();
        LayoutController.instance.EnterGame();
    }

    public void EnterStartscreen()
    {
        ObjectPooler.instance.DeactivatePooledObjects();
        LayoutController.instance.EnterMenu();
    }
}
