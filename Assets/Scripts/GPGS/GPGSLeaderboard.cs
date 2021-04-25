using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPGSLeaderboard : MonoBehaviour
{

    public void OpenLeaderboard()
    {
        if (!Social.localUser.authenticated)
        {
            GPGSAuth.instance.AuthenticateUser();
        }

        Social.ShowLeaderboardUI();
    }

    public static void UpdateLeaderboardScore(long newScore)
    {
        if (PlayerPrefs.GetInt("GPGSSignIn") == 0 || newScore == 0)
        {
            return;
        }

        if (!Social.localUser.authenticated)
        {
            GPGSAuth.instance.AuthenticateUser();
        }


        Social.ReportScore(newScore, GPGSIds.leaderboard_die_besten_flieger, (bool success) =>
        {
            if (success)
            {
                //TODO Do Something
                Debug.Log("Posted new score to leaderboard");
            }
            else
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }
        });
    }
}
