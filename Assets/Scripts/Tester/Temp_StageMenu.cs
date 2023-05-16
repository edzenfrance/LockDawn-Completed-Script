using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temp_StageMenu : MonoBehaviour
{
    public void BackToPreviousScene()
    {
        Debug.Log("Stage Selection: Back");
        SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
    }

    public void GotoStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
}
