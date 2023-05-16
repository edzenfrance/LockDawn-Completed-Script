using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AchievementController : MonoBehaviour
{
    [SerializeField] private Sprite goldMedal;
    [SerializeField] private Image[] medalHolder;
    [SerializeField] private Image[] background;
    [SerializeField] private TextMeshProUGUI[] achTitle;
    [SerializeField] private TextMeshProUGUI[] achInfo;

    void OnEnable()
    {
        SaveManager.GetAchievement();
        SaveManager.GetCompleteStage();
        if (SaveManager.achievementA == 2) ChangeMedal(0);
        if (SaveManager.achievementB == 2 && SaveManager.stageACompleted == 1) ChangeMedal(1);
        if (SaveManager.achievementC == 2) ChangeMedal(2);
        if (SaveManager.achievementD == 2) ChangeMedal(3);
        if (SaveManager.achievementE == 2) ChangeMedal(4);
        if (SaveManager.achievementF == 2 && SaveManager.stageACompleted == 1 &&
            SaveManager.stageBCompleted == 1 && SaveManager.stageCCompleted == 1 &&
            SaveManager.stageDCompleted == 1 && SaveManager.stageECompleted == 1) ChangeMedal(5);
        if (SaveManager.achievementG == 2) ChangeMedal(6);
    }

    void ChangeMedal(int num)
    {
        background[num].color = new Color32(255, 255, 225, 255);
        medalHolder[num].color = new Color32(113, 69, 20, 255);
        achTitle[num].color = new Color32(113, 69, 20, 255);
        achInfo[num].color = new Color32(113, 69, 20, 255);
        //medalHolder[num].sprite = goldMedal;
        //medalHolder[num].color = new Color32(255, 255, 255, 255);
        // achTitle[num].color = new Color32(251, 208, 162, 255);
        // achInfo[num].color = new Color32(251, 208, 162, 255);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
