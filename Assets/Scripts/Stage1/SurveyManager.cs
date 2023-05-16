using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;


public class SurveyManager : MonoBehaviour
{
    public AudioManager audioManager;
    public PlayFabSurvey playfabSurvey;

    [Header("Survey")]
    public GameObject showAnswerButton;
    public GameObject answerText;
    public GameObject doneSurveyButton;
    public GameObject surveyCanvas;
    public TextMeshProUGUI questionText;

    [Header("Toggles")]
    public ToggleGroup toggleGroup;
    public GameObject[] toggleObject;

    int num;
    int surveyNum;
    string myAnswer;
    int toggleLimit;
    int playfabCheck;
    bool doneAnswer = false;


    void OnEnable()
    {
        showAnswerButton.SetActive(false);
    }

    public void ProcessSurvey(string StageSurvey)
    {
        surveyCanvas.SetActive(true);
        audioManager.PlayAudioPickUpPaper();
        if (StageSurvey == "Stage 1 Survey") SetStageNumber(1, 0);
        if (StageSurvey == "Stage 2 Survey") SetStageNumber(2, 1);
        if (StageSurvey == "Stage 3 Survey") SetStageNumber(3, 2);
        if (StageSurvey == "Stage 4 Survey") SetStageNumber(4, 3);
        if (StageSurvey == "Stage 5 Survey 2") SetStageNumber(5, 4);
        if (StageSurvey == "Stage 5 Survey 1") SetStageNumber(5, 5);
    }

    void SetStageNumber(int stagenumber, int arraycount)
    {
        num = arraycount;
        ChangeSurveyText();
    }

    void ChangeSurveyText()
    {
        string getToggleLimit = TextManager.surveyTexts[num][0];
        if (int.TryParse(getToggleLimit, out toggleLimit))
        {
            toggleObject[0].SetActive(false);
            toggleObject[1].SetActive(false);
            toggleObject[2].SetActive(false);
            toggleObject[3].SetActive(false);
            questionText.text = TextManager.surveyTexts[num][3];
            int g = 4;
            for (int i = 0; i < toggleLimit; i++)
            {
                toggleObject[i].SetActive(true);
                toggleObject[i].GetComponent<Toggle>().GetComponentInChildren<Text>().text = TextManager.surveyTexts[num][g];
                g += 1;
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>SurveyManager</color> - Not a valid int");
#endif
            return;
        }
    }

    public void SelectSurveyAnswer()
    {
        if (!doneAnswer)
        {
            foreach (Toggle toggle in toggleGroup.ActiveToggles())
            {
                showAnswerButton.SetActive(true);
                if (toggle.name == "Toggle A") myAnswer = "A";
                if (toggle.name == "Toggle B") myAnswer = "B";
                if (toggle.name == "Toggle C") myAnswer = "C";
                if (toggle.name == "Toggle D") myAnswer = "D";
            }
        }
    }

    public void CompareSurveyAnswer()
    {
        doneAnswer = true;
#if UNITY_EDITOR
        Debug.Log("<color=white>SurveyManager</color> - Comparing survey answer");
#endif
        showAnswerButton.SetActive(false);
        answerText.SetActive(true);
        if (myAnswer == TextManager.surveyTexts[num][1])
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>SurveyManager</color> - Survery answer is correct!");
#endif
            answerText.GetComponent<TextMeshProUGUI>().text = TextManager.surveyCorrect;
            playfabCheck = 1;
            StartCoroutine(GetPlayFabSurvey());
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>SurveyManager</color> - Survery answer is wrong!");
#endif
            answerText.GetComponent<TextMeshProUGUI>().text = TextManager.surveyWrong + TextManager.surveyTexts[num][2];
            playfabCheck = 2;
            StartCoroutine(GetPlayFabSurvey());
            doneSurveyButton.SetActive(true);
        }
    }

    IEnumerator GetPlayFabSurvey()
    {
#if UNITY_EDITOR
            Debug.Log("<color=white>SurveyManager</color> - Adding survey using other credentials");
#endif
        // playfabSurvey.AddMemberToSurveyInfo();
        playfabSurvey.AddSurveyUsingOtherCredentials();
        yield return new WaitUntil(() => playfabSurvey.otherAccountAdded > 0);
        if (playfabSurvey.otherAccountAdded == 2)
        {
            playfabSurvey.ResetYieldValue();
            doneSurveyButton.SetActive(true);
            yield break;
        }
#if UNITY_EDITOR
            Debug.Log("<color=white>SurveyManager</color> - Adding survey using other credentials finished!");
#endif
        if (playfabSurvey.otherAccountAdded == 1)
        {
            surveyNum = num + 1; // Added + 1 because num starts to zero (0)
            string SNSa = "Survey " + surveyNum + " Success";
            string SNSb = "Survey " + surveyNum + " Failed";
            List<string> SGDKeys = new List<string>()
            {
                SNSa,
                SNSb,
            };
            playfabSurvey.GetSharedGroupDataSurvey("Surveys", SGDKeys, surveyNum);
            yield return new WaitUntil(() => playfabSurvey.sharedDataGroup > 0);

            if (playfabSurvey.sharedDataGroup == 1)
            {
                if (playfabCheck == 1)
                {
#if UNITY_EDITOR
                    Debug.Log("<color=white>SurveyManager</color> - Processing Correct Survey");
#endif
                    int result = playfabSurvey.surveyValueAInt += 1;
                    playfabSurvey.SaveSurvey(surveyNum.ToString(), result.ToString(), "Success");
                }
                if (playfabCheck == 2)
                {
#if UNITY_EDITOR
                    Debug.Log("<color=white>SurveyManager</color> - Processing Wrong Survey");
#endif
                    int result = playfabSurvey.surveyValueAInt += 1;
                    playfabSurvey.SaveSurvey(surveyNum.ToString(), result.ToString(), "Failed");
                }
                yield return new WaitUntil(() => playfabSurvey.surveyAdded > 0);
                if (playfabSurvey.surveyAdded == 2)
                {
#if UNITY_EDITOR
                    Debug.Log("<color=white>SurveyManager</color> - Survey failed to add");
#endif
                    playfabSurvey.GetMainCredentialsBack();
                    yield return new WaitUntil(() => playfabSurvey.mainAccountAdded > 0);
                    if (playfabSurvey.mainAccountAdded == 1)
                    {
                        doneSurveyButton.SetActive(true);
                    }
                }
                if (playfabSurvey.surveyAdded == 1)
                {
                    playfabSurvey.GetMainCredentialsBack();
                    yield return new WaitUntil(() => playfabSurvey.mainAccountAdded > 0);
                    if (playfabSurvey.mainAccountAdded == 1)
                    {
                        doneSurveyButton.SetActive(true);
                    }
                }
            }
        }
        playfabSurvey.ResetYieldValue();
        doneSurveyButton.SetActive(true);
    }
}
