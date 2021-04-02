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
        if (!GPGSAuth.signedIn)
        {
            GPGSAuth.instance.SignIn();
        }

        Social.ShowLeaderboardUI();
    }

    public static void UpdateLeaderboardScore(long newScore)
    {
        if (!Social.localUser.authenticated)
        {
            GPGSAuth.instance.AuthenticateUser();
        }
        if (!GPGSAuth.signedIn)
        {
            GPGSAuth.instance.SignIn();
        }

        if (newScore == 0)
        {
            return;
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
