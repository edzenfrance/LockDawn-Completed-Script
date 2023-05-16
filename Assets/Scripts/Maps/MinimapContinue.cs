using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapContinue : MonoBehaviour
{
    [SerializeField] private GameObject minimapObject;
    [SerializeField] private Sprite firstFloor;
    [SerializeField] private Sprite secondFloor;

    private void Awake()
    {
        SaveManager.GetCurrentStageScene();
        SaveManager.GetMap(SaveManager.currentStage);
        if (SaveManager.mapFloor == 1) minimapObject.GetComponent<Image>().sprite = firstFloor;
        if (SaveManager.mapFloor == 2) minimapObject.GetComponent<Image>().sprite = secondFloor;
    }
}
