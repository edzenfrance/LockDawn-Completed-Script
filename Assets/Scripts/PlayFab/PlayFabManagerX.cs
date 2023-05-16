using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabManagerX : MonoBehaviour
{
    public PlayFabButtonController playFabButtControl;
    public PlayFabSaveManager playFabSaveManager;

    [Header("UI TextMesh")]
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI infoUsername;
    public TextMeshProUGUI infoCreatedAt;

    [Header("Login InputField")]
    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;

    [Header("Register InputField")]
    public TMP_InputField registerUsername;
    public TMP_InputField registerEmail;
    public TMP_InputField registerPassword;
    public TMP_InputField registerAge;

    [Header("Reset InputField")]
    public TMP_InputField resetEmail;

    [Header("Panel")]
    public GameObject loginRegisterPanel;
    public GameObject loginPanel;
    public GameObject registerPanel;
    public GameObject rememberPanel;
    public GameObject saveSelectPanel;
    public GameObject resetPanel;

    [Header("GameObject")]
    public GameObject gameTitle;
    public GameObject mainMenuButton;
    public GameObject collectorsHallButton;
    public GameObject shopButton;
    public GameObject playFabLogin;
    public GameObject forgetPasswordButton;
    public GameObject playFabManagerButton;
    public GameObject noNetwork;
    public GameObject playFabButtonController;
    public Button loginButton;
    public TextMeshProUGUI loginButtonText;
    public Button showPasswordButton;
    public ToggleGroup toggleGroup;
    public Sprite[] showPasswordSprite;

    string emailStatus = "";

    string genderToggle = "Male";
    int ageInput = 12;

    string saveUN;
    string savePW;

    void Awake()
    {
        SaveManager.GetRememberAccount();
        if (SaveManager.rememberAccount == 1) AutoLoginAccount();
    }

    void Start()
    {
        loginPassword.contentType = TMP_InputField.ContentType.Password;
        registerPassword.contentType = TMP_InputField.ContentType.Password;
        registerAge.contentType = TMP_InputField.ContentType.IntegerNumber;
    }


    #region Check Internet Connection

    void CheckNetworkConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            StartCoroutine(ShowMessage(2, "No internet connection"));
            StartCoroutine(BackToMainMenu(1f));
            return;
        }
    }

    #endregion



    #region Register Account Then Send Verification Email

    public void RegisterButton()
    {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Registering the account");
#endif
        if (int.TryParse(registerAge.text, out ageInput))
        {
            // Do something with the result
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Correct age");
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Invalid age");
#endif
            StartCoroutine(ShowMessage(5, "Invalid or missing age input"));
            return;
        }
        if (ageInput < 12)
        {
            StartCoroutine(ShowMessage(5, "Your age must be 12 and up to play this game!"));
            return;
        }
        if (registerPassword.text.Length < 6)
        {
            StartCoroutine(ShowMessage(5, "Password is too short!"));
            return;
        }
        if (string.Equals(registerUsername.text, "lockdawn", StringComparison.OrdinalIgnoreCase))
        {
            StartCoroutine(ShowMessage(5, "Username is already in use"));
            return;
        }
        if (string.Equals(registerUsername.text, "l0ckdawn", StringComparison.OrdinalIgnoreCase))
        {
            StartCoroutine(ShowMessage(5, "Username is already in use"));
            return;
        }
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Creating RegisterPlayFabUserRequest");
#endif
        var request = new RegisterPlayFabUserRequest
        {
            TitleId = PlayFabSettings.TitleId,
            Username = registerUsername.text,
            Email = registerEmail.text,
            Password = registerPassword.text,
            RequireBothUsernameAndEmail = true
        };
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Register PlayFabUser");
#endif
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnPlayFabError);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Users successfully registered to PlayFab!");
#endif
        LoginAfterRegister();
    }

    void LoginAfterRegister()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = registerEmail.text,
            Password = registerPassword.text
        };
        var emailAddress = registerEmail.text;
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginResult =>
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Successfully logged in player with PlayFabId: " + OnLoginResult.PlayFabId);
#endif
            SaveGenderAndAge();
            AddOrUpdateContactEmail(emailAddress);
        }, OnPlayFabError);
    }

    void SaveGenderAndAge()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Gender",  genderToggle},
                {"Age", ageInput.ToString()}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend =>
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Successful User Data Send: Gender: " + genderToggle + " Age: " + ageInput.ToString());
#endif
        }, OnPlayFabError);
    }


    // This will send verification email to the registered account
    void AddOrUpdateContactEmail(string emailAddress)
    {
        var request = new AddOrUpdateContactEmailRequest
        {
            //PlayFabId = playFabId,
            EmailAddress = emailAddress
        };
        PlayFabClientAPI.AddOrUpdateContactEmail(request, SendVerificationSuccess, OnPlayFabError);
    }

    void SendVerificationSuccess(AddOrUpdateContactEmailResult result)
    {
        StartCoroutine(ShowMessage(5, "We have e-mailed your password reset link!"));
        registerUsername.text = "";
        registerEmail.text = "";
        registerPassword.text = "";
        registerAge.text = "";
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - The player's account has been updated with a contact email");
            Debug.Log("<color=white>PlayFabManagerX</color> - Forgetting Credentials");
#endif
        PlayFabClientAPI.ForgetAllCredentials();
        StartCoroutine(GotoLogin());
    }

    IEnumerator GotoLogin()
    {
        yield return new WaitForSeconds(5f);
        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void ToggleGender()
    {
        foreach (Toggle toggle in toggleGroup.ActiveToggles())
        {
            if (toggle.name == "Male")
            {
                genderToggle = "Male";
            }
            if (toggle.name == "Female")
            {
                genderToggle = "Female";
            }
        }
    }

    #endregion



    #region Auto Login Account

    public void AutoLoginAccount()
    {
        string playerUsername = SecurePlayerPrefs.GetString("PlayerUsername", "Username");
        string playerPassword = SecurePlayerPrefs.GetString("PlayerPassword", "Password");
        if (!string.IsNullOrWhiteSpace(playerUsername))
        {
            if (!string.IsNullOrWhiteSpace(playerPassword))
            {
                var request = new LoginWithEmailAddressRequest
                {
                    Email = playerUsername,
                    Password = playerPassword
                };
                PlayFabClientAPI.LoginWithEmailAddress(request, OnGetMainCredentialsBack =>
                    {
                        playFabButtControl.GetAccountInfo();
                        playFabSaveManager.LoadPlayerPrefs();
#if UNITY_EDITOR
                        Debug.Log("<color=white>PlayFabManagerX</color> - Auto Login Success!");
#endif
                    },
                    OnPlayFabError);
            }
        }
    }

    #endregion



    #region Login Account

    public void LoginButton()
    {
        if (loginEmail.text.Length == 0)
        {
            StartCoroutine(ShowMessage(5, "Invalid email address"));
            return;
        }
        if (loginPassword.text.Length == 0)
        {
            StartCoroutine(ShowMessage(5, "Invalid password"));
            return;
        }
        CheckNetworkConnection();
        var request = new LoginWithEmailAddressRequest
        {
            Email = loginEmail.text,
            Password = loginPassword.text
        };
        saveUN = loginEmail.text;
        savePW = loginPassword.text;
        StartCoroutine(HideLoginButton());
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnPlayFabError);
    }

    void OnLoginSuccess(LoginResult result)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Login Success!");
#endif
        GetAccountInfo();
    }

    IEnumerator HideLoginButton()
    {
        loginButtonText.color = new Color32(221, 64, 64, 255);
        loginButton.interactable = false;
        yield return new WaitForSeconds(1f);
        loginButtonText.color = new Color32(255, 255, 255, 255);
        loginButton.interactable = true;
    }

    // Check if account is verified
    public void GetAccountInfo()
    {
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnPlayFabError);
    }

    private void OnGetAccountInfoSuccess(GetAccountInfoResult resultData)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - <color=green><b>,- RECIEVED ACCOUNT INFORMATION</b></color>");
        Debug.Log("<color=white>PlayFabManagerX</color> - <b><color=green>|--></color> Username: </b>" + resultData.AccountInfo.Username);
        Debug.Log("<color=white>PlayFabManagerX</color> - <b><color=green>|--></color> Created: </b>" + resultData.AccountInfo.Created);
        Debug.Log("<color=white>PlayFabManagerX</color> - <b><color=green>|--></color> PlayFabId: </b>" + resultData.AccountInfo.PlayFabId);
        Debug.Log("<color=white>PlayFabManagerX</color> - <b><color=green>'--></color> Email: </b>" + resultData.AccountInfo.PrivateInfo.Email);
        //infoUsername.text = resultData.AccountInfo.Username.ToString();
        //infoCreatedAt.text = resultData.AccountInfo.Created.ToString();
        //infoCreatedAt.text = resultData.AccountInfo.PrivateInfo.Email.ToString();
#endif
        GetPlayerProfile(resultData.AccountInfo.PlayFabId);
    }

    void GetPlayerProfile(string playFabId)
    {
        var request = new GetPlayerProfileRequest
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowContactEmailAddresses = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetPlayerProfile(request, result =>
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Verification Status: " + result.PlayerProfile.ContactEmailAddresses[0].VerificationStatus);
#endif
            emailStatus = "" + result.PlayerProfile.ContactEmailAddresses[0].VerificationStatus;
            if (emailStatus == "Pending")
            {
                messageText.text = "Your account is not yet verified!";
                StartCoroutine(SendVerificationEmail());
            }
            else
            {
                loginEmail.text = "";
                loginPassword.text = "";
                messageText.text = "You are now logged in!";
                StartCoroutine(ProcessRememberAccount());
            }
        }, OnPlayFabError);
    }

    IEnumerator SendVerificationEmail()
    {
        yield return new WaitForSeconds(1f);
        AddOrUpdateContactEmail(saveUN);
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabManagerX</color> - Forgetting Credentials");
#endif
        PlayFabClientAPI.ForgetAllCredentials();
    }

    #endregion



    #region Remember Account

    IEnumerator ProcessRememberAccount()
    {
        yield return new WaitForSecondsRealtime(1f);
        messageText.text = "";
        loginPanel.SetActive(false);
        rememberPanel.SetActive(true);
    }

    public void RememberAccountYes()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Saving Username and Password using SecurePlayerPrefs");
#endif
        SecurePlayerPrefs.SetString("PlayerUsername", saveUN, "Username");
        PlayerPrefs.Save();
        SecurePlayerPrefs.SetString("PlayerPassword", savePW, "Password");
        PlayerPrefs.Save();
        SaveManager.SetRememberAccount(1);
        //string playerUsername = SecurePlayerPrefs.GetString("PlayerUsername", "Username");
        //Debug.Log(playerUsername );
        StartCoroutine(DataSelection());
    }

    public void RememberAccountNo()
    {
        SaveManager.SetRememberAccount(0);
        StartCoroutine(DataSelection());
    }

    #endregion



    #region Save Selection

    IEnumerator DataSelection()
    {
        yield return new WaitForSecondsRealtime(1f);
        rememberPanel.SetActive(false);
        saveSelectPanel.SetActive(true);
    }

    public void UseOnlineData()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Using online data and replacing offline data");
#endif
        StartCoroutine(GetOnlineAccountData());
    }

    public void UseOfflineData()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Using offline data and updating offline data");
#endif
        StartCoroutine(SetOfflineAccountData());
    }

    IEnumerator GetOnlineAccountData()
    {
        yield return new WaitForSeconds(1f);
        playFabSaveManager.LoadPlayerPrefs();
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Using online data and replacing offline data finished!");
#endif
        StartCoroutine(BackToMainMenu(1f));
    }

    IEnumerator SetOfflineAccountData()
    {
        yield return new WaitForSeconds(1f);
        playFabSaveManager.SavePlayerPrefs();
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Using offline data and updating offline data finished!");
#endif
        StartCoroutine(BackToMainMenu(1f));
    }

    #endregion



    #region Back to Main Menu

    IEnumerator BackToMainMenu(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        messageText.text = "";
        playFabLogin.SetActive(false);
        gameTitle.SetActive(true);
        mainMenuButton.SetActive(true);
        collectorsHallButton.SetActive(true);
        shopButton.SetActive(true);
        loginPanel.SetActive(false);
        rememberPanel.SetActive(false);
        playFabManagerButton.SetActive(true);
        playFabButtonController.SetActive(true);
    }

    #endregion



    #region Change Password

    public void ChangePassword()
    {
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoEmailSuccess, OnPlayFabError);
    }

    private void OnGetAccountInfoEmailSuccess(GetAccountInfoResult resultData)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Email: " + resultData.AccountInfo.PrivateInfo.Email);
#endif
        GetPlayerProfileEmail(resultData.AccountInfo.PrivateInfo.Email);
    }

    void GetPlayerProfileEmail(string email)
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email,
            TitleId = "D5450"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordChange, OnPlayFabError);
    }

    private void OnPasswordChange(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "We have e-mailed your password reset link!";
        StartCoroutine(BackToMainMenu(1f));
    }

#endregion



    #region Reset Password

    public void ForgotPasswordButton()
    {
        messageText.text = "";
        loginPanel.SetActive(false);
        resetPanel.SetActive(true);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = loginEmail.text,
            TitleId = "D5450"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnPasswordResetError);
    }

    void OnPasswordResetError(PlayFabError error)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - OnPasswordReset - PlayFabError: " + error);
#endif
        StartCoroutine(ShowMessage(3, "Invalid email address"));
    }

    private void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        StartCoroutine(ShowMessage(3, "We have e-mailed your password reset link!"));
    }

    #endregion



    #region Logout

    public void LogoutButton()
    {
        SaveManager.SetRememberAccount(0);
        PlayFabClientAPI.ForgetAllCredentials();
        SecurePlayerPrefs.SetString("PlayerUsername", "null", "Username");
        PlayerPrefs.Save();
        SecurePlayerPrefs.SetString("PlayerPassword", "null", "Password");
        PlayerPrefs.Save();
    }

    #endregion



    #region Leaderboards

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "LockDawnScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnPlayFabError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - Successful Leaderboard Sent");
#endif
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "LockDawnScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnPlayFabError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
#if UNITY_EDITOR
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
#endif
        }
    }

    #endregion



    #region OnPlayFabError

    private void OnPlayFabError(PlayFabError error)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabManagerX</color> - PlayFabError: " + error.Error);
#endif
        string output = "";
        int outputcode = 0;
        switch (error.Error)
        {
            case PlayFabErrorCode.AccountBanned:
                output = "You're account has been banned";
                outputcode = 1002;
                break;
            case PlayFabErrorCode.AccountDeleted:
                output = "Account is already deleted";
                outputcode = 1322;
                break;
            case PlayFabErrorCode.AccountNotFound:
                output = "Account not found";
                outputcode = 1001;
                break;
            case PlayFabErrorCode.ConnectionError:
                output = "Connection error";
                outputcode = 2;
                break;
            case PlayFabErrorCode.EmailAddressNotAvailable:
                output = "Email address already in use";
                outputcode = 1006;
                break;
            case PlayFabErrorCode.InvalidEmailAddress:
                output = "Invalid email address";
                outputcode = 1005;
                break;
            case PlayFabErrorCode.InvalidEmailOrPassword:
                output = "Invalid email or password";
                outputcode = 1142;
                break;
            case PlayFabErrorCode.InvalidPassword:
                output = "Invalid password";
                outputcode = 1008;
                break;
            case PlayFabErrorCode.InvalidParams:
                output = "Invalid email or password";
                outputcode = 1000;
                break;
            case PlayFabErrorCode.InvalidUsernameOrPassword:
                output = "Invalid username or password";
                outputcode = 1003;
                break;
            case PlayFabErrorCode.JsonParseError:
                output = "JSON parse error";
                outputcode = 3;
                break;
            case PlayFabErrorCode.NotAuthenticated:
                output = "Please login first!";
                outputcode = 1074;
                break;
            case PlayFabErrorCode.NotAuthorized:
                output = "Incorrect credentials";
                outputcode = 1089;
                break;
            case PlayFabErrorCode.SessionLogNotFound:
                output = "You need to login";
                outputcode = 1244;
                break;
            case PlayFabErrorCode.ServiceUnavailable:
                output = "No internet connection";
                outputcode = 1123;
                break;
            case PlayFabErrorCode.SmtpServerLimitExceeded:
                output = "SMPT Server Limit Exceeded";
                outputcode = 1312;
                break;
            case PlayFabErrorCode.Unknown:
                output = "Unknown error";
                outputcode = 1;
                break;
            case PlayFabErrorCode.UnknownError:
                output = "Unknown error occured";
                outputcode = 1039;
                break;
            case PlayFabErrorCode.UserisNotValid:
                output = "User is not valid";
                outputcode = 1030;
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                output = "Username not available";
                outputcode = 1009;
                break;
            case PlayFabErrorCode.InvalidTitleId:
                output = "Invalid Title ID";
                outputcode = 1004;
                break;
            default:
                break;
        }
        if (outputcode == 1005 || outputcode == 1142 || outputcode == 1008 || outputcode == 1000 || outputcode == 1003)
        {
            forgetPasswordButton.SetActive(true);
        }
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSaveManager</color> - PlayFab Error Output: " + output);
        Debug.LogError(error.GenerateErrorReport());
#endif
        StartCoroutine(ShowMessage(3, output));
    }

    #endregion



    #region Show Password


    public void ShowUserPassword()
    {
        if (registerPassword.contentType == TMP_InputField.ContentType.Password)
        {
            showPasswordButton.image.sprite = showPasswordSprite[1];
            registerPassword.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            showPasswordButton.image.sprite = showPasswordSprite[0];
            registerPassword.contentType = TMP_InputField.ContentType.Password;
        }
        registerPassword.ForceLabelUpdate();
    }

    #endregion



    IEnumerator ShowMessage(int clearTime, string textMessage)
    {
        messageText.text = textMessage;
        yield return new WaitForSeconds(clearTime);
        messageText.text = "";
    }

    public void BackButton()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            messageText.text = "";
            loginEmail.text = "";
            loginPassword.text = "";
            registerUsername.text = "";
            registerEmail.text = "";
            registerPassword.text = "";
            registerAge.text = "";
            resetEmail.text = "";

            playFabLogin.SetActive(false);
            noNetwork.SetActive(true);
            gameTitle.SetActive(true);
            mainMenuButton.SetActive(true);
            shopButton.SetActive(true);
            collectorsHallButton.SetActive(true);
            playFabManagerButton.SetActive(true);
            forgetPasswordButton.SetActive(false);
        }
        else
        {
            messageText.text = "";
            loginEmail.text = "";
            loginPassword.text = "";
            registerUsername.text = "";
            registerEmail.text = "";
            registerPassword.text = "";
            registerAge.text = "";
            resetEmail.text = "";
            forgetPasswordButton.SetActive(false);
        }
    }
}
