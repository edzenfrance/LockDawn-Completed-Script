using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

using System.Collections;
using System.Collections.Generic;

public class CollectorsHallMenu : MonoBehaviour
{
    public GameObject[] collectorsImage;
    public GameObject[] collectorsImageText;
    public GameObject[] collectorsButton;
    public GameObject[] mainEffect;
    public TextMeshProUGUI[] mainItemSurveyText;
    public GameObject exitButton;
    public GameObject backButton;
    public GameObject collectorsTextObj;
    public GameObject imagesObj;
    public TextMeshProUGUI collectorsText;

    int num;
    string getNum;
    string answerText;


    private void Start()
    {
        SaveManager.GetMainItem();
        if (SaveManager.mainItemA == 1) ActiveCollectorsImage(0);
        if (SaveManager.mainItemB == 1) ActiveCollectorsImage(1);
        if (SaveManager.mainItemC == 1) ActiveCollectorsImage(2);
        if (SaveManager.mainItemD == 1) ActiveCollectorsImage(3);
        if (SaveManager.mainItemE == 1) ActiveCollectorsImage(4);

        SaveManager.GetRiddle();
        if (SaveManager.riddleA == 2) ActiveCollectorsImage(5);
        if (SaveManager.riddleB == 2) ActiveCollectorsImage(6);
        if (SaveManager.riddleC == 2) ActiveCollectorsImage(7);
        if (SaveManager.riddleD == 2) ActiveCollectorsImage(8);
        if (SaveManager.riddleE == 2) ActiveCollectorsImage(9);
    }

    void ActiveCollectorsImage(int num)
    {
        collectorsImage[num].SetActive(true);
        collectorsImageText[num].SetActive(true);
        collectorsButton[num].SetActive(true);
    }

    public void ViewCollectorsText()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        getNum = name.Replace("ImageButton", "");
        if (int.TryParse(getNum, out num))
            LoadText();
        else
            Debug.Log("Not a valid int");
    }

    void LoadText()
    {
        imagesObj.SetActive(false);
        exitButton.SetActive(false);
        backButton.SetActive(true);
        if (num < 6)
        {
            if (num == 1)
            {
                mainItemSurveyText[0].text = "Survey Question\n\n" + TextManager.surveyTexts[0][3];
                mainEffect[0].SetActive(true);
            }
            if (num == 2)
            {
                mainItemSurveyText[1].text = "Survey Question\n\n" + TextManager.surveyTexts[1][3];
                mainEffect[1].SetActive(true);
            }
            if (num == 3)
            {
                mainItemSurveyText[2].text = "Survey Question\n\n" + TextManager.surveyTexts[2][3];
                mainEffect[2].SetActive(true);
            }
            if (num == 4)
            {
                mainItemSurveyText[3].text = "Survey Question\n\n" + TextManager.surveyTexts[3][3];
                mainEffect[3].SetActive(true);
            }
            if (num == 5)
            {
                mainItemSurveyText[4].text = "Survey Question\n\n" + TextManager.surveyTexts[4][3];
                mainEffect[4].SetActive(true);
            }
        }
        if (num > 5)
        {
            num = num - 6;
            collectorsTextObj.SetActive(true);
            string answer = TextManager.riddleTexts[num][5];
            if (answer == "A") answerText = TextManager.riddleTexts[num][1].Replace("A. ", "");
            if (answer == "B") answerText = TextManager.riddleTexts[num][2].Replace("B. ", "");
            if (answer == "C") answerText = TextManager.riddleTexts[num][3].Replace("C. ", "");
            if (answer == "D") answerText = TextManager.riddleTexts[num][4].Replace("D. ", "");
            collectorsText.text = "Riddle Question: \n\n" + TextManager.riddleTexts[num][0] + "\n\nYour answer: " + answerText;
        }
    }

    public void BackToCollectorsImage()
    {
        foreach (GameObject mainEff in mainEffect)
        {
            mainEff.SetActive(false);
        }
        imagesObj.SetActive(true);
        collectorsTextObj.SetActive(false);
        exitButton.SetActive(true);
        backButton.SetActive(false);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }


    public void MainItemVitaminURL()
    {
        Application.OpenURL("https://www.ifm.org/news-insights/boosting-immunity-functional-medicine-tips-prevention-immunity-boosting-covid-19-coronavirus-outbreak/");
    }

    public void MainItemSanitizerURL()
    {
        Application.OpenURL("https://www.indushealthplus.com/can-sanitizer-prevent-the-spread-of-coronavirus.html");
    }

    public void MainItemFacemaskURL()
    {
        Application.OpenURL("https://www.hopkinsmedicine.org/health/conditions-and-diseases/coronavirus/coronavirus-face-masks-what-you-need-to-know");
    }

    public void MainItemFaceshieldURL()
    {
        Application.OpenURL("https://doh.gov.ph/press-release/DOH-FACE-SHIELDS-PROVIDE-ADDED-LAYER-OF-PROTECTION-AGAINST-COVID-19");
    }

    public void MainItemVaccineURL()
    {
        Application.OpenURL("https://www.unicef.org/northmacedonia/what-you-need-know-about-covid-19-vaccine");
    }
}
