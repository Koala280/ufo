using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public TMP_InputField usernameInput;
    private string username;

    void Start()
    {
        username = PlayerPrefs.GetString("username", "guest");
        usernameInput.text = username;
    }

    public void ResetGameStats()
    {
        bool deleteCloudData = PlayerPrefs.GetInt("GPGSSignIn") == 1;
        PlayerPrefs.DeleteAll();
        if (deleteCloudData)
        {
            PlayerPrefs.SetInt("GPGSSignIn", 1);
            GPGSSaveGameState.instance.OpenSave(true);
            PlayerPrefs.DeleteAll();
        }
        SceneManager.LoadScene("MainScene");
    }

    public void Apply()
    {
        if (string.IsNullOrEmpty(usernameInput.text))
        {
            PlayerPrefs.SetString("username", "guest");
        } else
        {
            PlayerPrefs.SetString("username", usernameInput.text);
        }
        LayoutController.instance.LeaveSettings();
    }
}
