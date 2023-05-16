using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class StageSelectionController : MonoBehaviour
{
    [SerializeField] private Image[] stageImage;
    [SerializeField] private GameObject[] lockIcon;
    [SerializeField] private Button[] stageNumButton;
    [SerializeField] private TextMeshProUGUI[] stageNumText;

    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private TextMeshProUGUI loadingUIText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressText;


    void OnEnable()
    {
        SaveManager.GetCompleteStage();
        SaveManager.DeleteReplayStage();

        if (SaveManager.stageACompleted == 1)
            StageImageEnable(0);
        else
            StageImageDisable(0);

        if (SaveManager.stageBCompleted == 1)
            StageImageEnable(1);
        else
            StageImageDisable(1);

        if (SaveManager.stageCCompleted == 1)
            StageImageEnable(2);
        else
            StageImageDisable(2);

        if (SaveManager.stageDCompleted == 1)
            StageImageEnable(3);
        else
            StageImageDisable(3);

        if (SaveManager.stageECompleted == 1)
            StageImageEnable(4);
        else
            StageImageDisable(4);
    }

    void StageImageEnable(int num)
    {
        lockIcon[num].SetActive(false);
        stageImage[num].color = new Color32(255, 255, 255, 255);
        stageNumButton[num].interactable = true;
        stageNumText[num].color = new Color32(255, 255, 255, 255);
    }
    void StageImageDisable(int num)
    {
        lockIcon[num].SetActive(true);
        stageImage[num].color = new Color32(34, 34, 34, 255);
        stageNumButton[num].interactable = false;
        stageNumText[num].color = new Color32(200, 200, 200, 128);
    }

    public void SelectStageOne()
    {
        SaveManager.SetReplayStage();
        loadingUI.SetActive(true);
        StartCoroutine(LoadAsynchronously("Stage1"));
    }

    public void SelectStageTwo()
    {
        SaveManager.SetReplayStage();
        loadingUI.SetActive(true);
        StartCoroutine(LoadAsynchronously("Stage2"));
    }

    public void SelectStageThree()
    {
        SaveManager.SetReplayStage();
        loadingUI.SetActive(true);
        StartCoroutine(LoadAsynchronously("Stage3"));
    }

    public void SelectStageFour()
    {
        SaveManager.SetReplayStage();
        loadingUI.SetActive(true);
        StartCoroutine(LoadAsynchronously("Stage4"));
    }

    public void SelectStageFive()
    {
        SaveManager.SetReplayStage();
        loadingUI.SetActive(true);
        StartCoroutine(LoadAsynchronously("Stage5"));
    }

    public void CloseStageSelection()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadAsynchronously(string scenename)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
