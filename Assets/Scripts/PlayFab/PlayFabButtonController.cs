using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabButtonController : MonoBehaviour
{
    public Button accountButton;
    public TextMeshProUGUI accountButtonText;
    public GameObject noNetwork;

    public GameObject playFabLogin;
    public GameObject gameTitle;
    public GameObject mainMenuButton;
    public GameObject shop;
    public GameObject collectorsHallButton;
    public GameObject playFabManagerButton;
    public GameObject alreadyLoginPanel;
    public GameObject loginRegisterPanel;
    public GameObject playFabButtonController;

    string getUsername;
    bool usernameFound = false;


    void Start()
    {
        InvokeRepeating(nameof(CheckNetwork), 0f, 2.5f);
    }

    void OnEnable()
    {
        StartCoroutine(GetAccountInformation());
    }


    public void CheckNetwork()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - Checking internet reachability");
#endif
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - Internet connection not reachable");
#endif
                accountButton.interactable = false;
            if (playFabManagerButton.activeSelf)
            {
                noNetwork.SetActive(true);
            }
            accountButtonText.text = "No Internet";
            var newColorBlock = accountButton.colors;
            newColorBlock.disabledColor = new Color(1, 1, 1, 1);
            accountButton.colors = newColorBlock;
        }
        else
        {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - Internet connection reachable");
#endif
            accountButton.interactable = true;
            noNetwork.SetActive(false);
            if (!usernameFound)
            {
                accountButtonText.text = "Account";
            }
        }
    }

    public void OpenPlayFabMenu()
    {
        StartCoroutine(GetAccountInformation());
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return;
        }
        else
        {
            if (usernameFound)
            {
                playFabLogin.SetActive(true);
                alreadyLoginPanel.SetActive(true);
                loginRegisterPanel.SetActive(false);
                noNetwork.SetActive(false);
                gameTitle.SetActive(false);
                shop.SetActive(false);
                mainMenuButton.SetActive(false);
                collectorsHallButton.SetActive(false);
                playFabManagerButton.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                playFabLogin.SetActive(true);
                alreadyLoginPanel.SetActive(false);
                loginRegisterPanel.SetActive(true);
                noNetwork.SetActive(false);
                gameTitle.SetActive(false);
                shop.SetActive(false);
                mainMenuButton.SetActive(false);
                collectorsHallButton.SetActive(false);
                playFabManagerButton.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator GetAccountInformation()
    {
        yield return new WaitForSeconds(1f);
        GetAccountInfo();
    }

    void exitPlayFabMenuNoConnection()
    {
        playFabLogin.SetActive(false);
        noNetwork.SetActive(true);
        gameTitle.SetActive(true);
        shop.SetActive(true);
        mainMenuButton.SetActive(true);
        collectorsHallButton.SetActive(true);
        playFabManagerButton.SetActive(true);
    }

    public void GetAccountInfo()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - Requesting Account Info");
#endif
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnPlayFabError);
    }

    private void OnGetAccountInfoSuccess(GetAccountInfoResult resultData)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - <color=green><b>,- RECIEVED ACCOUNT INFORMATION</b></color>");
        Debug.Log("<color=white>PlayFabButtonController</color> - <b><color=green>|--></color> Username: </b>" + resultData.AccountInfo.Username);
        Debug.Log("<color=white>PlayFabButtonController</color> - <b><color=green>|--></color> Created: </b>" + resultData.AccountInfo.Created);
        Debug.Log("<color=white>PlayFabButtonController</color> - <b><color=green>'--></color> PlayFabId: </b>" + resultData.AccountInfo.PlayFabId);
#endif
        getUsername = resultData.AccountInfo.Username;
        accountButtonText.text = resultData.AccountInfo.Username;
        usernameFound = true;
    }


    private void OnPlayFabError(PlayFabError obj)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - PlayFab Error: " + obj.Error);
#endif
        string output = "";
        switch (obj.Error)
        {
            case PlayFabErrorCode.AccountBanned:
                output = "Bye bye. You're account has been banned";
                break;
            case PlayFabErrorCode.EmailAddressNotAvailable:
                output = "Email address already in use";
                break;
            case PlayFabErrorCode.InvalidEmailAddress:
                output = "Invalid email address";
                break;
            case PlayFabErrorCode.InvalidParams:
                output = "Invalid email or password";
                break;
            case PlayFabErrorCode.InvalidUsernameOrPassword:
                output = "Invalid username or password";
                break;
            case PlayFabErrorCode.InvalidEmailOrPassword:
                output = "Invalid email or password";
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                output = "Username not available";
                break;
            case PlayFabErrorCode.AccountNotFound:
                output = "Account not found";
                break;
            case PlayFabErrorCode.SmtpServerLimitExceeded:
                output = "SMPT Server Limit Exceeded";
                break;
            case PlayFabErrorCode.ServiceUnavailable:
                output = "No internet connection";
                break;
            default:
                break;
        }
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabButtonController</color> - PlayFab Error Output: " + output);
#endif
        }

        public void LogoutAndBack()
        {
            playFabButtonController.SetActive(true);
            StartCoroutine(WaitToLogout());
            StartCoroutine(GetAccountInformation());
        }

        IEnumerator WaitToLogout()
        {
            SaveManager.SetRememberAccount(0);
            PlayFabClientAPI.ForgetAllCredentials();
            SecurePlayerPrefs.SetString("PlayerUsername", "null", "Username");
            PlayerPrefs.Save();
            SecurePlayerPrefs.SetString("PlayerPassword", "null", "Password");
            PlayerPrefs.Save();
            yield return new WaitForSeconds(2f);
            usernameFound = false;
            gameTitle.SetActive(true);
            shop.SetActive(true);
            mainMenuButton.SetActive(true);
            playFabLogin.SetActive(false);
            playFabManagerButton.SetActive(true);
            collectorsHallButton.SetActive(true);
            alreadyLoginPanel.SetActive(false);
            loginRegisterPanel.SetActive(false);
        }

        public void BackToMenu()
        {
            gameTitle.SetActive(true);
            mainMenuButton.SetActive(true);
            shop.SetActive(true);
            collectorsHallButton.SetActive(true);
            playFabManagerButton.SetActive(true);
            collectorsHallButton.SetActive(true);
            playFabButtonController.SetActive(true);
            playFabLogin.SetActive(false);
            SFXManager.sfxInstance.audioSource.PlayOneShot(SFXManager.sfxInstance.UIClick);
        }
}