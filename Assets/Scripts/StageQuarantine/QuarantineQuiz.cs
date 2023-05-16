using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuarantineQuiz : MonoBehaviour
{
    public AudioManager audioManager;
    public QuarantineController quarantineController;

    [Header("Riddle")]
    public GameObject showAnswerButton;
    public GameObject answerText;
    public GameObject doneQuizButton;
    public GameObject canvasUserInterface;
    public GameObject quizView;
    public TextMeshProUGUI questionText;
    public int quizCount = 11; // Count thru textManager

    [Header("Toggles")]
    public ToggleGroup toggleGroup;
    public GameObject[] toggleAnswer;

    int num;
    string myAnswer;
    int toggleLimit;
    bool doneAnswer = false;

    void OnEnable()
    {
        quizView.SetActive(true);
        showAnswerButton.SetActive(false);
        quizCount = quizCount - 1;
        num = Random.Range(0, quizCount);
        ChangeQuizText();
    }

    void ChangeQuizText()
    {
        string getToggleLimit = TextManager.quizTexts[num][0];
        if (int.TryParse(getToggleLimit, out toggleLimit))
        {
            toggleAnswer[0].SetActive(false);
            toggleAnswer[1].SetActive(false);
            toggleAnswer[2].SetActive(false);
            toggleAnswer[3].SetActive(false);
            questionText.text = TextManager.quizTexts[num][3];
            int g = 4;
            for (int i = 0; i < toggleLimit; i++)
            {
                toggleAnswer[i].SetActive(true);
                toggleAnswer[i].GetComponent<Toggle>().GetComponentInChildren<Text>().text = TextManager.quizTexts[num][g];
                g += 1;
            }
        }
        else
        {
            Debug.Log("<color=white>SurveyManager</color> - Not a valid int");
            return;
        }
    }

    public void SelectQuizAnswer()
    {
        if (!doneAnswer)
        {
            foreach (Toggle toggle in toggleGroup.ActiveToggles())
            {
                Debug.Log("<color=white>QuarantineQuiz</color> - Select Quiz Answer: " + toggle);
                showAnswerButton.SetActive(true);
                if (toggle.name == "Toggle A") myAnswer = "A";
                if (toggle.name == "Toggle B") myAnswer = "B";
                if (toggle.name == "Toggle C") myAnswer = "C";
                if (toggle.name == "Toggle D") myAnswer = "D";
            }
        }
    }

    public void CompareQuizAnswer()
    {
        doneAnswer = true;
        showAnswerButton.SetActive(false);
        answerText.SetActive(true);
        if (myAnswer == TextManager.quizTexts[num][1])
        {
            // Correct answer
            SaveManager.SetQuiz();
            answerText.GetComponent<TextMeshProUGUI>().text = TextManager.quizCorrect + " " + TextManager.quizTexts[num][2];
            doneQuizButton.SetActive(true);
        }
        else
        {
            answerText.GetComponent<TextMeshProUGUI>().text = TextManager.quizWrong;
            doneQuizButton.SetActive(true);
            quarantineController.QuizFailed();
        }
    }
}
