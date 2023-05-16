using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StageObjective1 : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private HealthController healthController;
    [SerializeField] private Canvas canvasSettings;
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private GameObject stageObjectives;
    [SerializeField] private GameObject cameraTimeline;


    void Start()
    {
        StartCoroutine(playVoiceOver());
    }

    IEnumerator playVoiceOver()
    {
        Time.timeScale = 0;
        canvasSettings.sortingOrder = 8;
#if UNITY_EDITOR
        Debug.Log("<color=white>StageObjective1</color> - Game Paused");
#endif
        yield return new WaitForSecondsRealtime(2);
        canvasSettings.sortingOrder = 5;
        loadingUI.SetActive(false);
        stageObjectives.SetActive(true);
        audioManager.PlayAudioObjectiveA();
    }
    public void OnResume()
    {
        SaveManager.GetReplayStage();
        if (SaveManager.replayStage != 1)
            healthController.LoadHealthInfection();
        Time.timeScale = 1;
#if UNITY_EDITOR
        Debug.Log("<color=white>StageObjective1</color> - Game Unpaused");
#endif
        audioManager.StopAudio();
        audioManager.PlayAmbienceC();
        SaveManager.GetStagePreview(1);
        if (SaveManager.replayStage == 1 || SaveManager.stagePreview == 0)
            cameraTimeline.SetActive(true);
        gameObject.SetActive(false);
    }
}
