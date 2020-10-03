using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_InputField usernameInput;
    private string username;

    void Start()
    {
        username = PlayerPrefs.GetString("username", "guest");
        usernameInput.text = username;
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
        
    }
}
