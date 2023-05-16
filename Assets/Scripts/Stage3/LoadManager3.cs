﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using Cinemachine;
using TMPro;
using FIMSpace.FOptimizing;


public class LoadManager3 : MonoBehaviour
{
    [SerializeField] private UIVirtualTouchZone UIVirtualTouchZoneLook;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject exitPoint;
    [SerializeField] private GameObject framerateCounter;
    [SerializeField] private GameObject tutorials;
    [SerializeField] private TextMeshProUGUI life;

    [Header("Immunity")]
    [SerializeField] private GameObject immunityFill;
    [SerializeField] private Slider immunityBar;
    [SerializeField] private TextMeshProUGUI immunityText;

    [Header("Stage Timeline")]
    [SerializeField] private GameObject cameraTimeline;
    [SerializeField] private GameObject stageEnvironment;
    [SerializeField] private PlayableDirector cameraTimelineDirector;

    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private GameObject[] NPCDifficulty;
    [SerializeField] private GameObject[] stageItems;
    [SerializeField] private Toggle[] stageToggle;
    [SerializeField] private List<GameObject> objects;


    void Awake()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>LoadManager3</color> - Awake. Getting all needed in SaveManager");
#endif
        // Character
        SaveManager.GetCurrentCharacter();
        SaveManager.GetCurrentStage();
        SaveManager.GetContinueGame();
        SaveManager.GetReplayStage();

        GameObject prefab = characterPrefabs[SaveManager.currentCharacter];

        if (SaveManager.replayStage == 1 || SaveManager.nextStage == 1 || SaveManager.quarantineExitScene == 1)
        {
            SaveManager.SetQuarantineExitFinish();
            SaveManager.SetNextStageFinish();
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
        else if (SaveManager.continueGame == 1)
        {
            Vector3 characterPosition = PlayerPrefsExtra.GetVector3("S3 Character Position", spawnPoint.position);
            GameObject clone = Instantiate(prefab, characterPosition, Quaternion.identity);
        }
        else
        {
            GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }

        // Camera Timeline
        SaveManager.GetStagePreview(3);
        if (SaveManager.replayStage == 3 || SaveManager.stagePreview == 0)
        {
            // Disable all essential optimizer in stage environment objects before running the camera timeline
            foreach (var child in stageEnvironment.GetComponentsInChildren<Transform>())
            {
                if (child.GetComponent<EssentialOptimizer>() != null)
                    child.GetComponent<EssentialOptimizer>().enabled = false;
            }
            cameraTimelineDirector.stopped += OnPlayableDirectorStopped;
        }

        if (SaveManager.replayStage == 1)
        {
            int currImmunity = 15;
            // Setting immunity to true because stage 2 already have 5 immunity
            immunityFill.SetActive(true);
            immunityBar.value = (float)currImmunity;
            immunityText.text = currImmunity.ToString();
            SaveManager.SetReplayMainItem(1);
            SaveManager.SetReplayMainItem(2);
        }
        else
        {
            // Stage Objects
            SaveManager.GetMainItem();
            SaveManager.GetRiddle();
            SaveManager.GetSpecialSyrup();
            SaveManager.ResetKeyCount(); // Reset Key Count on continue or not because we dont need keys here in stage 3

            if (SaveManager.mainItemC == 1)
            {
                exitPoint.SetActive(true);
                DisableItems("item", 0);
            }
            if (SaveManager.syrupC == 1 || SaveManager.syrupC == 2) DisableItems("item", 1);
            if (SaveManager.riddleC == 1 || SaveManager.riddleC == 2) DisableItems("item", 2);

            // Immunity
            int currImmunity = 0;
            if (SaveManager.mainItemA == 1) currImmunity += 5;
            if (SaveManager.mainItemB == 1) currImmunity += 10;
            if (SaveManager.mainItemC == 1) currImmunity += 15;
            if (SaveManager.mainItemD == 1) currImmunity += 20;
            if (SaveManager.mainItemE == 1) currImmunity += 50;
            SaveManager.SetCurrrentImmunity(currImmunity);
            SaveManager.GetCurrentImmunity();
            if (SaveManager.currentImmunity > 0)
                immunityFill.SetActive(true);
            else
                immunityFill.SetActive(false);
            immunityBar.value = (float)currImmunity;
            immunityText.text = currImmunity.ToString();

            // Life
            SaveManager.GetCurrentLife();
            life.text = "Life: " + SaveManager.currentLife;
        }

        // Enable Tutorials
        // tutorials.SetActive(true);

        // NPC
        SaveManager.GetGameDifficulty();
        NPCDifficulty[0].SetActive(false);
        NPCDifficulty[1].SetActive(false);
        NPCDifficulty[2].SetActive(false);
        if (SaveManager.gameDifficulty == 0) NPCDifficulty[1].SetActive(true); // Anti Cheat
        if (SaveManager.gameDifficulty == 1) NPCDifficulty[0].SetActive(true);
        if (SaveManager.gameDifficulty == 2) NPCDifficulty[1].SetActive(true);
        if (SaveManager.gameDifficulty == 3) NPCDifficulty[2].SetActive(true);

        // Look Sensitivity
        SaveManager.GetLookSensitivity();
        UIVirtualTouchZoneLook.magnitudeMultiplier = SaveManager.lookSensitivity;

        // Framerate Counter
        SaveManager.GetShowFramerate();
        if (SaveManager.framerateOn == 1)
            framerateCounter.SetActive(true);
        else
            framerateCounter.SetActive(false);

        // Camera
        SaveManager.GetCameraDistance();
        virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = SaveManager.cameraDistance; ;

#if UNITY_EDITOR
        Debug.Log("<color=white>LoadManager3</color> - Destroying unnecessary game object");
#endif
        // Destroy Object From Main Menu
        GameObject objMusic = GameObject.FindGameObjectWithTag("MainMenuBGM");
        GameObject objSound = GameObject.FindGameObjectWithTag("SFXManager");
        Destroy(objMusic);
        Destroy(objSound);

#if UNITY_EDITOR
        Debug.Log("<color=white>LoadManager3</color> - Prefab: " + prefab.name + " - SpawnPoint: " + SaveManager.currentStage);
        Debug.Log("<color=white>LoadManager3</color> - Game Difficulty: " + SaveManager.gameDifficulty);
        Debug.Log("<color=white>LoadManager3</color> - Framerate: " + SaveManager.framerateOn);
        Debug.Log("<color=white>LoadManager3</color> - Camera Distance: " + SaveManager.cameraDistance);
        Debug.Log("<color=white>LoadManager3</color> - Current Immunity: " + SaveManager.currentImmunity);
        Debug.Log("<color=white>LoadManager3</color> - Look Sensitivity: " + SaveManager.lookSensitivity);
#endif
    }

    private void Start()
    {
        if (SaveManager.replayStage == 1 || SaveManager.stagePreview == 0)
            StartCoroutine(SetObjects(false, 0f));
    }

    public void DisableItems(string proc, int num)
    {
        if (proc == "item")
        {
            stageToggle[num].isOn = true;
            stageItems[num].SetActive(false);
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (cameraTimelineDirector == aDirector)
        {
            cameraTimeline.SetActive(false);
            StartCoroutine(SetObjects(true, 1.5f));
            foreach (var child in stageEnvironment.GetComponentsInChildren<Transform>())
            {
                if (child.GetComponent<EssentialOptimizer>() != null)
                    child.GetComponent<EssentialOptimizer>().enabled = true;
            }
            if (SaveManager.replayStage != 1)
            {
                SaveManager.SetStagePreview(3);
            }
        }
    }

    IEnumerator SetObjects(bool setbool, float setwait)
    {
        yield return new WaitForSeconds(setwait);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(setbool);
        }
    }
}
