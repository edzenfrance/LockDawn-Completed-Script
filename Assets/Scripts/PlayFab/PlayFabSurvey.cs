using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabSurvey : MonoBehaviour
{
    public string surveyValueAStr;
    public string surveyValueBStr;
    public int surveyValueAInt;
    public int surveyValueBInt;
    int SGDNumResult;
    string PlayFabIDresult;

    public int otherAccountAdded = 0;
    public int sharedDataGroup = 0;
    public int surveyAdded = 0;
    public int mainAccountAdded = 0;


    #region Add Survey Using Other Credentials (Clean Version)

    public void AddSurveyUsingOtherCredentials()
    {
        string playerUsername = SecurePlayerPrefs.GetString("PlayerUsername", "Username");
        string playerPassword = SecurePlayerPrefs.GetString("PlayerPassword", "Password");
        if (!string.IsNullOrWhiteSpace(playerPassword))
        {
            if (!string.IsNullOrWhiteSpace(playerPassword))
            {
#if UNITY_EDITOR
                Debug.Log("<color=white>PlayFabSurvey</color> - Adding Other Credentials");
#endif
                PlayFabClientAPI.ForgetAllCredentials();
                var request = new LoginWithEmailAddressRequest
                {
                    Email = "mingmingandborange@gmail.com",
                    Password = "mingming"
                };
                PlayFabClientAPI.LoginWithEmailAddress(request, OnAddSurveyUsingOtherCredentials =>
                    {
                        otherAccountAdded = 1;
#if UNITY_EDITOR
                        Debug.Log("<color=white>PlayFabSurvey</color> - Adding Other Credentials Success!");
#endif
                    },
                    OnPlayFabErrorA);
            }
            otherAccountAdded = 2;
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSurvey</color> - Username or password is missing. Please login first and remember the account!");
#endif
        }
        otherAccountAdded = 2;
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSurvey</color> - Username or password is missing. Please login first and remember the account!");
#endif
    }

    public void GetMainCredentialsBack()
    {
        string playerUsername = SecurePlayerPrefs.GetString("PlayerUsername", "Username");
        string playerPassword = SecurePlayerPrefs.GetString("PlayerPassword", "Password");
        if (!string.IsNullOrWhiteSpace(playerUsername))
        {
            if (!string.IsNullOrWhiteSpace(playerPassword))
            {
#if UNITY_EDITOR
                Debug.Log("<color=white>PlayFabSurvey</color> - Adding Main Credentials");
#endif
                PlayFabClientAPI.ForgetAllCredentials();
                var request = new LoginWithEmailAddressRequest
                {
                    Email = playerUsername,
                    Password = playerPassword
                };
                PlayFabClientAPI.LoginWithEmailAddress(request, OnGetMainCredentialsBack =>
                    {
                        mainAccountAdded = 1;
#if UNITY_EDITOR
                        Debug.Log("<color=white>PlayFabSurvey</color> - Adding Main Credentials Success!");
#endif
                    },
                    OnPlayFabErrorD);
            }
        }
    }

    // Need to add user to members to be able to update this shit
    public void SaveSurvey(string num, string value, string keyword)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSurvey</color> - Processing Survey: " + num + " " + value + " " + keyword);
#endif
        string SGDData = "Survey " + num + " " + keyword;
        var request = new UpdateSharedGroupDataRequest
        {
            SharedGroupId = "Surveys",
            Data = new Dictionary<string, string>
            {
                {SGDData, value}
            },
            Permission = UserDataPermission.Public
        };
        PlayFabClientAPI.UpdateSharedGroupData(request, OnUpdateGroupData =>
            {
                surveyAdded = 1;
#if UNITY_EDITOR
                Debug.Log("<color=white>PlayFabSurvey</color> - Survey Data Successfully Send - Data: " + SGDData + " Value: " + value);
#endif
            },
            OnPlayFabErrorC);
    }

    public void ResetYieldValue()
    {
        otherAccountAdded = 0;
        sharedDataGroup = 0;
        surveyAdded = 0;
        mainAccountAdded = 0;
    }

#endregion



#region Add Member to Survey (Buggy Code)

    // Logout the user first
    // Login the main Member credentials
    // Add the user to Member of Group Shared Data
    // Logout the main Member credentials
    // Add the survey

    public void AddMemberToSurveyInfo()
    {
        Debug.Log("<color=white>PlayFabSurvey</color> - Getting Players PlayFabID");
        var request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccountInfoSuccess, OnPlayFabError);
    }

    private void OnGetAccountInfoSuccess(GetAccountInfoResult resultData)
    {
        Debug.Log("<color=white>PlayFabSurvey</color> - Getting Players PlayFabID: " + resultData.AccountInfo.PlayFabId);
        PlayFabIDresult = resultData.AccountInfo.PlayFabId;
        AddMemberToSurvey();
    }

    void AddMemberToSurvey()
    {
        // Debug.Log("<color=white>PlayFabSurvey</color> - Logout Credentials");
        PlayFabClientAPI.ForgetAllCredentials();
        Debug.Log("<color=white>PlayFabSurvey</color> - Adding Main Credentials");
        var request = new LoginWithEmailAddressRequest
        {
            Email = "mingmingandborange@gmail.com",
            Password = "mingming"
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginResult, OnPlayFabError);
    }

    void OnLoginResult(LoginResult result)
    {
        Debug.Log("<color=white>PlayFabSurvey</color> - Adding Players to Survey");
        List<string> PFIDresult = new List<string>()
        {
            PlayFabIDresult,
        };
        var request = new AddSharedGroupMembersRequest
        {
            SharedGroupId = "Surveys",
            PlayFabIds = PFIDresult,
        };
        PlayFabClientAPI.AddSharedGroupMembers(request, OnAddSharedGroupMembers, OnPlayFabError);
    }

    void OnAddSharedGroupMembers(AddSharedGroupMembersResult result)
    {
        Debug.Log("<color=white>PlayFabSurvey</color> - Adding Players to Surveys Success!");
        // Debug.Log("<color=white>PlayFabSurvey</color> - Logout Main Credentials");
        PlayFabClientAPI.ForgetAllCredentials();

        string playerUsername = SecurePlayerPrefs.GetString("PlayerUsername", "Username");
        string playerPassword = SecurePlayerPrefs.GetString("PlayerPassword", "Password");
        var request = new LoginWithEmailAddressRequest
        {
            Email = playerUsername,
            Password = playerPassword
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginResultB, OnPlayFabError);
    }

    void OnLoginResultB(LoginResult result)
    {
        Debug.Log("<color=white>PlayFabSurvey</color> - Logging In Done!");
    }


    // Need to add uuser to members to be able to update this shit
    public void SaveSurveyTest(string num, string value, string keyword)
    {
        Debug.Log("<color=white>PlayFabSurvey</color> - Processing Survey: " + num + " " + value + " " + keyword);
        string SGDData = "Survey " + num + " " + keyword;
        var request = new UpdateSharedGroupDataRequest
        {
            SharedGroupId = "Surveys",
            Data = new Dictionary<string, string>
            {
                {SGDData, value}
            },
            Permission = UserDataPermission.Public
        };
        PlayFabClientAPI.UpdateSharedGroupData(request, OnUpdateGroupData =>
        {
            surveyAdded = 1;
            Debug.Log("<color=white>PlayFabSurvey</color> - Survey Data Successfully Send - Data: " + SGDData + " Value: " + value);
        }, OnPlayFabError);
    }

    // Need to add uuser to members to be able to update this shit
    public void SaveSurveyY(Dictionary<string, string> data)
    {
        var request = new UpdateSharedGroupDataRequest
        {
            SharedGroupId = "Surveys",
            Data = data,
            Permission = UserDataPermission.Public
        };
        PlayFabClientAPI.UpdateSharedGroupData(request, OnUpdateGroupData, OnPlayFabError);
    }

    void OnUpdateGroupData(UpdateSharedGroupDataResult result)
    {
        Debug.Log("Success");
    }

#endregion



#region Get Shared Group Data

    public void GetSharedGroupDataSurvey(string ID, List<string> keys, int SGDNR)
    {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSurvey</color> - Getting Shared Group Data");
#endif
        SGDNumResult = SGDNR;
        var request = new GetSharedGroupDataRequest
        {
            SharedGroupId = ID,
            GetMembers = true,
            Keys = keys,
        };
        PlayFabClientAPI.GetSharedGroupData(request, GetSharedGroupDataResultSurvey, OnPlayFabErrorB);
    }

    void GetSharedGroupDataResultSurvey(GetSharedGroupDataResult resultData)
    {
        surveyValueAStr = resultData.Data["Survey " + SGDNumResult + " Success"].Value;
        surveyValueBStr = resultData.Data["Survey " + SGDNumResult + " Failed"].Value;

        if (int.TryParse(surveyValueAStr, out surveyValueAInt))
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSurvey</color> - Survey " + SGDNumResult + " - Success: " + surveyValueAInt);
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSurvey</color> - Not a valid int");
#endif
        }

        if (int.TryParse(surveyValueBStr, out surveyValueBInt))
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSurvey</color> - Survey " + SGDNumResult + " - Failed: " + surveyValueBInt);
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSurvey</color> - Not a valid int");
#endif
        }

        sharedDataGroup = 1;
    }

#endregion



#region PlayFabErrors

    private void OnPlayFabErrorA(PlayFabError obj)
    {
        otherAccountAdded = 2;
        OnPlayFabError(obj);
    }

    private void OnPlayFabErrorB(PlayFabError obj)
    {
        sharedDataGroup = 2;
        OnPlayFabError(obj);
    }

    private void OnPlayFabErrorC(PlayFabError obj)
    {
#if UNITY_EDITOR
                Debug.Log("<color=white>PlayFabSurvey</color> - Survey Data Failed To Send!");
#endif
        surveyAdded = 2;
        OnPlayFabError(obj);
    }

    private void OnPlayFabErrorD(PlayFabError obj)
    {
        mainAccountAdded = 2;
        OnPlayFabError(obj);
    }

    private void OnPlayFabError(PlayFabError error)
    {
        otherAccountAdded = 2;
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSurvey</color> - PlayFabError: " + error.Error);
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
        if (outputcode == 0)
        {
            // For supressing warning in unity only, might use this later;
        }
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSurvey</color> - PlayFabError Output: " + output + " Code: " + outputcode);
#endif
    }

    #endregion
}

