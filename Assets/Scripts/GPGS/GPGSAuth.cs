using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;


public class GPGSAuth : MonoBehaviour
{
    public static GPGSAuth instance;
    public static PlayGamesPlatform platform;
    public GameObject signInBTN;
    public GameObject signOutBTN;
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
                signInBTN.SetActive(false);
                signOutBTN.SetActive(true);
                GPGSSaveGameState.instance.OpenSave(false);
                Debug.Log("Logged in successfully!");
            }
            else
            {
                signInBTN.SetActive(true);
                signOutBTN.SetActive(false);
                Debug.Log("Failed to login: " + err);
            }
        });
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }
}
