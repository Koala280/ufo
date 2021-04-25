using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;


public class GPGSAuth : MonoBehaviour
{
    public static GPGSAuth instance;
    public static PlayGamesPlatform platform;
    public GameObject[] signedInBTN;
    public GameObject[] signedOutBTN;
    
    void Start()
    {
        instance = this;
        //AutoLogin only first time and if Autologin is activated
        if (!PlayerPrefs.HasKey("GPGSSignIn") || PlayerPrefs.GetInt("GPGSSignIn") == 1)
        {
            AuthenticateUser();
        }
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
                PlayerPrefs.SetInt("GPGSSignIn", 1);
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
                PlayerPrefs.SetInt("GPGSSignIn", 0);
                Debug.Log("Failed to login: " + err);
            }
        });
    }

    public void SignOut()
    {
        PlayerPrefs.SetInt("GPGSSignIn", 0);
        PlayGamesPlatform.Instance.SignOut();
    }
}
