using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Text;
using UnityEngine;

public class GPGSSaveGameState : MonoBehaviour
{
    public static GPGSSaveGameState instance;
    private bool isSaving = false;

    void Start()
    {
        instance = this;
    }

    private string GetSaveDataString()
    {
        string temp = "";

        //Username
        temp += PlayerPrefs.GetString("username", "guest");
        temp += "|";
        //Money
        temp += PlayerPrefs.GetInt("money", 0);
        temp += "|";


        //Highscores
        temp += PlayerPrefs.GetInt("highscore1", 0);
        temp += "|";
        temp += PlayerPrefs.GetInt("highscore2", 0);
        temp += "|";
        temp += PlayerPrefs.GetInt("highscore3", 0);
        temp += "|";
        temp += PlayerPrefs.GetString("highscore1_username", "guest");
        temp += "|";
        temp += PlayerPrefs.GetString("highscore2_username", "guest");
        temp += "|";
        temp += PlayerPrefs.GetString("highscore3_username", "guest");
        temp += "|";

        //Weapons
        temp += PlayerPrefs.GetInt("raygun_lvl", 1);
        temp += "|";
        temp += PlayerPrefs.GetInt("star_lvl", 1);
        temp += "|";
        temp += PlayerPrefs.GetInt("nuclear_lvl", 1);

        return temp;
    }

    private void LoadSavedDataString(string savedDataString)
    {
        string[] savedData = savedDataString.Split('|');

        PlayerPrefs.SetString("username", savedData[0]);
        PlayerPrefs.SetInt("money", int.Parse(savedData[1]));

        PlayerPrefs.SetInt("highscore1", int.Parse(savedData[2]));
        PlayerPrefs.SetInt("highscore2", int.Parse(savedData[3]));
        PlayerPrefs.SetInt("highscore3", int.Parse(savedData[4]));

        PlayerPrefs.SetString("highscore1_username", savedData[5]);
        PlayerPrefs.SetString("highscore2_username", savedData[6]);
        PlayerPrefs.SetString("highscore3_username", savedData[7]);

        PlayerPrefs.SetInt("raygun_lvl", int.Parse(savedData[8]));
        PlayerPrefs.SetInt("star_lvl", int.Parse(savedData[9]));
        PlayerPrefs.SetInt("nuclear_lvl", int.Parse(savedData[10]));
    }

    private void decideWhichData()
    {

    }

    public void OpenSave(bool saving)
    {
        if (PlayerPrefs.GetInt("GPGSSignIn") == 0)
        {
            return;
        }

        if (!Social.localUser.authenticated)
        {
            GPGSAuth.instance.AuthenticateUser();
        }

        if (Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(
                "Ufo",
                GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime,
                SaveGameOpened
            );
        }
    }

    private void SaveGameOpened(SavedGameRequestStatus requestStatus, ISavedGameMetadata meta)
    {
        if (requestStatus == SavedGameRequestStatus.Success)
        {
            if (isSaving) //writing
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSaveDataString());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();

                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
            }
            else //reading
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
            }
        }
    }

    // Load
    private void SaveRead(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string saveData = System.Text.ASCIIEncoding.ASCII.GetString(data);
            LoadSavedDataString(saveData);
            Score.instance.UpdateHighscoreText();
        }
    }

    //Success save
    private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log(status);
    }
}