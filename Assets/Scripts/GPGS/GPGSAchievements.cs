using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GPGSAchievements : MonoBehaviour
{

    public void OpenAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }

    public static void IncrementStarAchievement()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_stern_level_1000, 1, null);
    }
    
    public static void IncrementAsteroidAchievement()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_asteroiden_zerstrer, 1, (bool success) =>
        {

        });
    }

    public static void UnlockSignInAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_google_sign_in, 100f, null); //0f to reveal a hidden achievement
    }
}
