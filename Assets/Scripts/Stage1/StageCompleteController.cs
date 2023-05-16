using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class StageCompleteController : MonoBehaviour
{
    [SerializeField] private StageTimer stageTimer;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AchievementStageController achievementStageController;


    void OnEnable()
    {
        stageTimer.OnFinishTimer();
        audioManager.PlayAmbienceF();
        Time.timeScale = 0;
        StartCoroutine(MoveToNextStage());
    }

    IEnumerator MoveToNextStage()
    {
        SaveManager.GetCurrentStageScene();
        if (SaveManager.currentStage == 1)
        {
            achievementStageController.GetAchievementA();
            yield return new WaitForSecondsRealtime(3f);
            achievementStageController.GetAchievementB();
            yield return new WaitForSecondsRealtime(3f);
        }
        if (SaveManager.currentStage == 5)
        {
            // GAME IS FINISH
            SaveManager.GameIsFinished();
            achievementStageController.GetAchievementC();
            yield return new WaitForSecondsRealtime(3f);
            achievementStageController.GetAchievementD();
            yield return new WaitForSecondsRealtime(3f);
            achievementStageController.GetAchievementE();
            yield return new WaitForSecondsRealtime(3f);
            achievementStageController.GetAchievementF();
            yield return new WaitForSecondsRealtime(3f);
            Time.timeScale = 1;
            
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
        SaveManager.GetAchievementViolator();
        if (SaveManager.playerViolation == 5)
        {
            if (SaveManager.achievementG != 2)
            {
                SaveManager.SetAchievement(7, 2);
                achievementStageController.GetAchievementG();
            }
        }
        SaveManager.GetReplayStage();
        if (SaveManager.replayStage == 1)
        {
            SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
            yield break;
        }
        // ADD SAVE TO PLAYFAB HERE
#if UNITY_EDITOR
        Debug.Log("<color=white>StageCompleteController</color> - Moving to next stage");
#endif
        yield return new WaitForSecondsRealtime(1.0f);
        SaveManager.SetContinueGame(1);
        SaveManager.SetCompleteStage(SaveManager.currentStage);
        SaveManager.ResetKeyStage(SaveManager.currentStage);
        int newStage = SaveManager.currentStage + 1;
        SaveManager.SetCurrentStage(newStage);
        SaveManager.SetNextStage();
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1;
#if UNITY_EDITOR
        Debug.Log("<color=white>StageCompleteController</color> - Loading Next Stage: " + newStage);
#endif
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene("Stage" + newStage, LoadSceneMode.Single);

    }
}
