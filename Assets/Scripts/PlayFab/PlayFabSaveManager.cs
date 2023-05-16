using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;


public class PlayFabSaveManager : MonoBehaviour
{
    public PlayFabJsonData playfabJsonData;


    public void SavePlayerPrefs()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSaveManager</color> - Requesting to Update User Data PlayFab with new JSON");
#endif
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"LockDawn Save", JsonConvert.SerializeObject(playfabJsonData.ReturnClass())}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSaveManager</color> - JSON sucessfully updated to PlayFab!");
#endif
    }

    public void LoadPlayerPrefs()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>PlayFabSaveManager</color> - Requesting User Data");
#endif
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("LockDawn Save"))
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>PlayFabSaveManager</color> - User Data Recieved!");
#endif
            LockDawnData lockdawndata = JsonConvert.DeserializeObject<LockDawnData>(result.Data["LockDawn Save"].Value);
            playfabJsonData.LoadDataToPrefs(lockdawndata);
        }
    }

    void OnError(PlayFabError error)
    {
        string output = "";
#pragma warning disable CS0219 // Variable is assigned but its value is never used
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
        Debug.Log("<color=white>PlayFabSaveManager</color> - PlayFab Error Output: " + output);
#endif
    }

}
