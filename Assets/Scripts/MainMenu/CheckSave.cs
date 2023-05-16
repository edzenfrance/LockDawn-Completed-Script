using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckSave : MonoBehaviour
{
    [SerializeField] private GameObject checkSave;
    [SerializeField] private GameObject newGameAsk;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button stageButton;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private TextMeshProUGUI stageText;

    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private TextMeshProUGUI loadingUIText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressText;

    private ColorBlock buttonColor;


    void Awake()
    {
        buttonColor.highlightedColor = new Color32(255, 255, 255, 255);
        buttonColor.normalColor = new Color32(255, 255, 255, 80); // Alpha is 80 for mouse only
        buttonColor.pressedColor = new Color32(221, 5, 5, 60);
        buttonColor.selectedColor = new Color32(221, 5, 5, 60);
        buttonColor.disabledColor = new Color32(200, 200, 200, 0);
        continueButton.colors = buttonColor;
        stageButton.colors = buttonColor;
    }

    void OnEnable()
    {
        SaveManager.GetCurrentStage();
        SaveManager.GetContinueGame();
        SaveManager.GetCompleteStage();
        if (SaveManager.continueGame == 1)
        {
            continueButton.interactable = true;
            continueText.color = new Color32(255, 255, 255, 255);
            continueText.text = "Continue Stage " + SaveManager.currentStage;
        }
        else if (SaveManager.continueGame == 0)
        {
            continueButton.interactable = false;
            continueText.color = new Color32(200, 200, 200, 128);
        }
        if (SaveManager.stageACompleted == 1)
        {
            stageButton.interactable = true;
            stageText.color = new Color32(255, 255, 255, 255);
        }
        else if (SaveManager.stageACompleted == 0)
        {
            stageButton.interactable = false;
            stageText.color = new Color32(200, 200, 200, 128);
        }
    }

    public void NewGameQuestion()
    {
        if (SaveManager.continueGame == 1)
        {
            checkSave.SetActive(false);
            newGameAsk.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("CharacterSelection", LoadSceneMode.Single);
        }
    }

    public void NewGameQuestionExit()
    {
        checkSave.SetActive(true);
        newGameAsk.SetActive(false);
    }

    public void ContinueGame()
    {
        SaveManager.GetCurrentStage();
        SaveManager.GetQuarantine();
        loadingUI.SetActive(true);

        if (SaveManager.isQuarantine == 1)
        {
            StartCoroutine(LoadAsynchronously("StageQuarantine"));
            return;
        }
        if (SaveManager.currentStage == 1) StartCoroutine(LoadAsynchronously("Stage1"));
        if (SaveManager.currentStage == 2) StartCoroutine(LoadAsynchronously("Stage2"));
        if (SaveManager.currentStage == 3) StartCoroutine(LoadAsynchronously("Stage3"));
        if (SaveManager.currentStage == 4) StartCoroutine(LoadAsynchronously("Stage4"));
        if (SaveManager.currentStage == 5) StartCoroutine(LoadAsynchronously("Stage5"));
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
