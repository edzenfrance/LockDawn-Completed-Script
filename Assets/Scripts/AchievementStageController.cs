using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementStageController : MonoBehaviour
{
    public GameObject achievementView;
    public TextMeshProUGUI achievementText;


    public void GetAchievementA()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements A");
#endif
        SaveManager.GetTimeForAchievements();
        if (SaveManager.stageTime < 120)
        {
            SaveManager.SetAchievement(1, 2);
            achievementView.SetActive(true);
            achievementText.text = "<size=90%><b>Basic</b></size><size=70%>\nGet the main item on stage 1 as quickly as possible";
        }
    }

    public void GetAchievementB()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements B");
#endif
        SaveManager.GetAchievement();
        if (SaveManager.achievementB == 2)
        {
            achievementView.SetActive(true);
            achievementText.text = "<size=40%><b>Show Off</b></size><size=30%>\nDon't get infected in stage 1</size>";
        }
    }

    public void GetAchievementC()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements C");
#endif
        int countriddle = 0;
        SaveManager.GetRiddle();
        if (SaveManager.riddleA == 2) countriddle += 1;
        if (SaveManager.riddleB == 2) countriddle += 1;
        if (SaveManager.riddleC == 2) countriddle += 1;
        if (SaveManager.riddleD == 2) countriddle += 1;
        if (SaveManager.riddleE == 2) countriddle += 1;
        if (countriddle == 5)
        {
            SaveManager.SetAchievement(3, 2);
            achievementView.SetActive(true);
            achievementText.text = "<size=40%><b>Show Off</b></size><size=30%>\nSolve all riddles in every stage</size>";
        }
    }

    public void GetAchievementD()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements D");
#endif
        SaveManager.SetAchievement(4, 2);
        achievementView.SetActive(true);
        achievementText.text = "<size=40%><b>Survivor</b></size><size=30%>\nFinish the game without getting infected.</size>";
    }

    public void GetAchievementE()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements E");
#endif
        int countsyrup = 0;
        SaveManager.GetSpecialSyrup();
        if (SaveManager.syrupA == 1 || SaveManager.syrupA == 2) countsyrup += 1;
        if (SaveManager.syrupB == 1 || SaveManager.syrupB == 2) countsyrup += 1;
        if (SaveManager.syrupC == 1 || SaveManager.syrupC == 2) countsyrup += 1;
        if (SaveManager.syrupD == 1 || SaveManager.syrupD == 2) countsyrup += 1;
        if (SaveManager.syrupE == 1 || SaveManager.syrupE == 2) countsyrup += 1;
        if (countsyrup == 5)
        {
            SaveManager.SetAchievement(5, 2);
            achievementView.SetActive(true);
            achievementText.text = "<size=40%><b>Show Off</b></size><size=30%>\nCollect all special syrup in every stage.</size>";
        }
    }

    public void GetAchievementF()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements F");
#endif
        SaveManager.GetAchievement();
        if (SaveManager.achievementE == 2)
        {
            achievementView.SetActive(true);
            achievementText.text = "<size=40%><b>Survivor</b></size><size=30%>\nFinish the game without getting infected.</size>";
        }
    }

    public void GetAchievementG()
    {
#if UNTIY_EDITOR
        Debug.Log("<color=AchievementStageController</color> - Getting Achievements G");
#endif
        SaveManager.GetAchievementViolator();
        if (SaveManager.playerViolation == 5)
        {
            achievementView.SetActive(true);
            achievementText.text = "<size=40%><b>Violator</b></size><size=30%>\nDon’t be a bad one!</size>";
        }
    }
}
