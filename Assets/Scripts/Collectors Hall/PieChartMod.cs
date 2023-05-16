using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class PieChartMod : MonoBehaviour
{
    public Image imagesPieChart;
    public PlayFabSurvey playfabSurvey;
    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;
    public GameObject correctTextObj;
    public GameObject incorrectTextObj;
    public GameObject refreshButton;

    float values = 0;
    int intCombinedValue = 0;
    int intCorrectValue = 0;
    int surveyNum;


    public void PieChartValues()
    {
        values += 1f;
        if (values <= 250)
        {
            float percentage = (values / 250f) * 100f;
            float percentagefillAmount = (percentage / 1000f) * 10f;
            float percentageWrong = 100f - percentage;

            Debug.Log("Percentage Fill Amount: " + percentagefillAmount);
            Debug.Log("Values: " + values + " Correct Percentage: " + percentage + "% of 250");
            Debug.Log("Values: " + values + " Incorrect Percentage: " + percentageWrong + "% of 250");
            imagesPieChart.fillAmount = percentagefillAmount;
        }
    }

    void SetPieChartValues()
    {
        if (intCorrectValue == 0)
        {
            Debug.Log("Probably not loaded");
            return;
        }

        float percentage = (intCorrectValue / (float)intCombinedValue) * 100f;
        float percentagefillAmount = (percentage / 1000f) * 10f;
        float percentageIncorrect = 100f - percentage;

        Debug.Log("Percentage Fill Amount: " + percentagefillAmount);
        Debug.Log("Values: " + playfabSurvey.surveyValueAInt + " Correct Percentage: " + percentage + "% of " + intCombinedValue);
        Debug.Log("Values: " + playfabSurvey.surveyValueBInt + " Incorrect Percentage: " + percentageIncorrect + "% of " + intCombinedValue);
        imagesPieChart.fillAmount = percentagefillAmount;

        correctText.text = percentage.ToString("F2") + "% of players answered correctly.";
        incorrectText.text = percentageIncorrect.ToString("F2") + "% of players answered wrong.";
    }

    public void GetPlayFabSurveyData()
    {
        intCombinedValue = 0;
        intCorrectValue = 0;
        string name = EventSystem.current.currentSelectedGameObject.name;
        string getNum = name.Replace("RefreshPie", "");
        if (int.TryParse(getNum, out surveyNum))
        {
            StartCoroutine(WaitViewResultButton());
            ProcessPlayFabSurvey();
        }

        else
            Debug.Log("Not a valid int");
    }

    IEnumerator WaitViewResultButton()
    {
        refreshButton.SetActive(false);
        yield return new WaitForSeconds(1);
        refreshButton.SetActive(true);
    }

    void ProcessPlayFabSurvey()
    {
        string SNSa = "Survey " + surveyNum + " Success";
        string SNSb = "Survey " + surveyNum + " Failed";
        List<string> SGDKeys = new List<string>()
        {
            SNSa,
            SNSb,
        };
        playfabSurvey.GetSharedGroupDataSurvey("Surveys", SGDKeys, surveyNum);
        StartCoroutine(WaitPlayFabSurveyResult());
    }

    IEnumerator WaitPlayFabSurveyResult()
    {
        refreshButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        correctTextObj.SetActive(true);
        incorrectTextObj.SetActive(true);
        intCombinedValue = playfabSurvey.surveyValueAInt + playfabSurvey.surveyValueBInt;
        intCorrectValue = playfabSurvey.surveyValueAInt;
        refreshButton.SetActive(true);
        SetPieChartValues();
    }
}
