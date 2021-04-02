using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;


public class GPGSAuth : MonoBehaviour
{
    public static GPGSAuth instance;
    public static PlayGamesPlatform platform;
    public GameObject[] signedInBTN;
    public GameObject[] signedOutBTN;
    public static bool signedIn;
    
    void Start()
    {
        instance = this;
        AuthenticateUser();
    }

    public void AuthenticateUser()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
            PlayGamesPlatform.InitializeInstance(config);
            platform = PlayGamesPlatform.Activate();
            Debug.Log("Authenticated");

            SignIn();
        }
    }

    public void SignIn()
    {
        Social.Active.localUser.Authenticate((bool success, string err) =>
        {
            signedIn = success;

            if (success)
            {
                GPGSAchievements.UnlockSignInAchievement();
                foreach (var btn in signedInBTN)
                {
                    btn.SetActive(true);
                }
                foreach (var btn in signedOutBTN)
                {
                    btn.SetActive(false);
                }
                GPGSSaveGameState.instance.OpenSave(false);
                Debug.Log("Logged in successfully!");
            }
            else
            {
                foreach (var btn in signedInBTN)
                {
                    btn.SetActive(false);
                }
                foreach (var btn in signedOutBTN)
                {
                    btn.SetActive(true);
                }
                Debug.Log("Failed to login: " + err);
            }
        });
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }
}
