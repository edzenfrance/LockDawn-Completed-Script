using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseSettings : MonoBehaviour
{
    public HealthController healthController;
    public PlayFabSaveManager playfabSaveManager;
    public GameObject buttonsDialog;
    public GameObject restartDialog;
    public GameObject settingDialog;
    public GameObject stageDialog;
    public GameObject exitDialog;
    public Transform box;
    public CanvasGroup background;

    [Header("Replay Mode")]
    public TextMeshProUGUI exitButtonText;
    public TextMeshProUGUI exitQuestionText;


    bool GamePaused = false;
    Scene m_Scene;
    string sceneName;


    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void OnEnable()
    {
        SaveManager.GetReplayStage();
        if (SaveManager.replayStage == 1)
        {
            exitButtonText.text = "Stage Selection";
            exitQuestionText.text = "Are you sure you want to exit to the Stage Selection?";
        }
        // Test
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().setOnComplete(OnEnableComplete).delay = 0f; //.delay = 0.1f
    }

    void OnEnableComplete()
    {
        GamePaused = true;
    }

    public void OnResume()
    {
        GamePaused = false;
        background.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnResumeComplete);
    }

    void OnResumeComplete()
    {
        gameObject.SetActive(false);
    }

    public void OnStage()
    {
        GamePaused = false;
        background.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnStageComplete);
    }

    void OnStageComplete()
    {
        gameObject.SetActive(false);
        stageDialog.SetActive(true);
    }

    public void OnRestart()
    {
        buttonsDialog.SetActive(false);
        restartDialog.SetActive(true);
    }

    public void OnRestartYes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GamePaused = false;
    }

    public void OnRestartNo()
    {
        buttonsDialog.SetActive(true);
        restartDialog.SetActive(false);
    }

    public void OnSettings()
    {
        GamePaused = false;
        background.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnSettingsComplete);
    }

    void OnSettingsComplete()
    {
        gameObject.SetActive(false);
        settingDialog.SetActive(true);
    }
    public void OnExit()
    {
        int infectedNum = 0;
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        SaveManager.GetReplayStage();
        if (SaveManager.replayStage != 1 || sceneName != "StageQuarantine")
        {
            SaveManager.GetCurrentStageScene();
            if (healthController.isInfected)
                infectedNum = 1;
            else
                infectedNum = 0;
            SaveManager.SaveGame(SaveManager.currentStage, healthController.characterHP, infectedNum);
            try
            {
                playfabSaveManager.SavePlayerPrefs();
            }
            catch (Exception e)
            {
#if UNITY_EDITOR
            Debug.Log("<color=white>PauseSettings</color> - <color=red>Exception: </color>" + e.ToString());
            //Debug.LogException(e, this);
#endif
            }
        }
        buttonsDialog.SetActive(false);
        exitDialog.SetActive(true);
    }

    public void OnExitYes()
    {
        GamePaused = false;
        StartCoroutine(SaveExit());
    }

    IEnumerator SaveExit()
    {
        yield return new WaitForSeconds(1f);
        if (SaveManager.replayStage == 1)
            SceneManager.LoadScene("Stage Select", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OnExitNo()
    {
        buttonsDialog.SetActive(true);
        exitDialog.SetActive(false);
    }
}