using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapChanger : MonoBehaviour
{
    [SerializeField] private GameObject minimapObject;

    [Header("Map Sprite")]
    [SerializeField] private Sprite firstFloor;
    [SerializeField] private Sprite secondFloor;

    [Header("Map Setting")]
    [SerializeField] private bool isFirstFloor = false;

    private void Start()
    {
        SaveManager.GetCurrentStageScene();;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isFirstFloor)
            {
#if UNITY_EDITOR
                Debug.Log("<color=white>MinimapChanger</color> - Stage: " + SaveManager.currentStage + " - First Floor");
#endif
                minimapObject.GetComponent<Image>().sprite = firstFloor;
                SaveManager.SetMap(SaveManager.currentStage, 1);
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log("<color=white>MinimapChanger</color> - Stage: " + SaveManager.currentStage + " - Second Floor");
#endif
                minimapObject.GetComponent<Image>().sprite = secondFloor;
                SaveManager.SetMap(SaveManager.currentStage, 2);
            }
        }
    }
}
