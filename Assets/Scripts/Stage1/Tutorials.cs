using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    [SerializeField] private GameObject touchZoneLook;
    [SerializeField] private GameObject touchZoneMove;
    [SerializeField] private GameObject tutorials;

    [SerializeField] private GameObject nextTutorialButton;
    [SerializeField] private GameObject skipTutorialButton;
    [SerializeField] private GameObject finishTutorialButton;

    [SerializeField] private GameObject[] backgroundText;
    [SerializeField] private GameObject[] arrowImage;
    [SerializeField] private GameObject[] tutorialText;

    int countTutorial = 1;

    void OnEnable()
    {
        touchZoneLook.SetActive(false);
        touchZoneMove.SetActive(false);
    }

    public void SkipTutorial()
    {
        tutorials.SetActive(false);
        touchZoneLook.SetActive(true);
        touchZoneMove.SetActive(true);
    }

    public void NextTutorial()
    {
        if (countTutorial == 9)
        {
            backgroundText[countTutorial].SetActive(true);
            arrowImage[countTutorial].SetActive(true);
            tutorialText[countTutorial].SetActive(true);
            finishTutorialButton.SetActive(true);
            nextTutorialButton.SetActive(false);
            skipTutorialButton.SetActive(false);
            return;
        }
        backgroundText[countTutorial].SetActive(true);
        arrowImage[countTutorial].SetActive(true);
        tutorialText[countTutorial].SetActive(true);
        countTutorial++;
    }

    public void FinishTutorial()
    {
        Time.timeScale = 1;
        tutorials.SetActive(false);
        touchZoneLook.SetActive(true);
        touchZoneMove.SetActive(true);
    }
}


