using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarantineTutorial : MonoBehaviour
{
    [SerializeField] private GameObject touchZoneLook;
    [SerializeField] private GameObject touchZoneMove;
    [SerializeField] private GameObject tutorials;

    [SerializeField] private GameObject nextTutorialButton;
    [SerializeField] private GameObject finishTutorialButton;

    [SerializeField] private GameObject previousAdsButton;
    [SerializeField] private GameObject nextAdsButton;
    [SerializeField] private GameObject advertisementText;


    [SerializeField] private GameObject[] tutorialList;

    int countTutorial = 1;

    void OnEnable()
    {
        Time.timeScale = 0;
        touchZoneLook.SetActive(false);
        touchZoneMove.SetActive(false);
        previousAdsButton.SetActive(true);
        nextAdsButton.SetActive(true);
        advertisementText.SetActive(true);
    }

    public void NextTutorial()
    {
        if (countTutorial == 3)
        {
            tutorialList[countTutorial].SetActive(true);
            finishTutorialButton.SetActive(true);
            nextTutorialButton.SetActive(false);
            return;
        }
        tutorialList[countTutorial].SetActive(true);
        countTutorial++;
    }

    public void FinishTutorial()
    {
        Time.timeScale = 1;
        tutorials.SetActive(false);
        touchZoneLook.SetActive(true);
        touchZoneMove.SetActive(true);
        previousAdsButton.SetActive(false);
        nextAdsButton.SetActive(false);
        advertisementText.SetActive(false);
    }
}


