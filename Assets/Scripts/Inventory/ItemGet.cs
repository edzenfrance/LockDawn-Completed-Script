using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemGet : MonoBehaviour
{
    [SerializeField] private Toggle[] toggleObjectives;
    [SerializeField] private TextMeshProUGUI grabItem;
    [SerializeField] private TextMeshProUGUI taskKeyText;
    [SerializeField] private GameObject exitPoint;
    [SerializeField] private GameObject mainEffect;
    [SerializeField] private GameObject syrupEffect;
    [SerializeField] private string objectName;
    [SerializeField] private GameObject faceMaskObject;
    [SerializeField] private GameObject faceShieldObject;

    [Header("Scripts")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private NoteController noteController;
    [SerializeField] private RiddleManager riddleManager;
    [SerializeField] private HealthController healthController;
    [SerializeField] private ImmunityController immunityController;
    [SerializeField] private Inventory inventory;
    [SerializeField] private CharacterObjectController charObjController;

    string infoMain;


    public void GetItem()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>ItemGet</color> - Object Name: " + objectName);
#endif
        if (objectName == "S1 Key A") SaveKey("S1 Key A", TextManager.S1_DoorKey_A_Add);
        if (objectName == "S1 Key B") SaveKey("S1 Key B", TextManager.S1_DoorKey_B_Add);
        if (objectName == "S1 Key C") SaveKey("S1 Key C", TextManager.S1_DoorKey_C_Add);
        if (objectName == "S1 Key D") SaveKey("S1 Key D", TextManager.S1_DoorKey_D_Add);
        if (objectName == "S1 Key E") SaveKey("S1 Key E", TextManager.S1_DoorKey_E_Add);
        if (objectName == "S1 Key F") SaveKey("S1 Key F", TextManager.S1_DoorKey_F_Add);

        if (objectName == "S2 Key A") SaveKey("S2 Key A", TextManager.S2_DoorKey_A_Add);
        if (objectName == "S2 Key B") SaveKey("S2 Key B", TextManager.S2_DoorKey_B_Add);
        if (objectName == "S2 Key C") SaveKey("S2 Key C", TextManager.S2_DoorKey_C_Add);
        if (objectName == "S2 Key D") SaveKey("S2 Key D", TextManager.S2_DoorKey_D_Add);
        if (objectName == "S2 Key E") SaveKey("S2 Key E", TextManager.S2_DoorKey_E_Add);
        if (objectName == "S2 Key F") SaveKey("S2 Key F", TextManager.S2_DoorKey_F_Add);

        if (objectName == "S5 Key A") SaveKey("S5 Key A", TextManager.S5_DoorKey_A_Add);
        if (objectName == "S5 Key B") SaveKey("S5 Key B", TextManager.S5_DoorKey_B_Add);
        if (objectName == "S5 Key C") SaveKey("S5 Key C", TextManager.S5_DoorKey_C_Add);
        if (objectName == "S5 Key D") SaveKey("S5 Key D", TextManager.S5_DoorKey_D_Add);
        if (objectName == "S5 Key E") SaveKey("S5 Key E", TextManager.S5_DoorKey_E_Add);
        if (objectName == "S5 Key F") SaveKey("S5 Key F", TextManager.S5_DoorKey_F_Add);

        if (objectName == "S1 Alcohol") ObtainMainItem(1, 5, TextManager.gotAlcohol);
        if (objectName == "S2 Vitamin") ObtainMainItem(2, 15, TextManager.gotVitamin);
        if (objectName == "S3 Face Mask") ObtainMainItem(3, 30, TextManager.gotFaceMask);
        if (objectName == "S4 Face Shield") ObtainMainItem(4, 50, TextManager.gotFaceShield);
        if (objectName == "S5 Vaccine") ObtainMainItem(5, 100, TextManager.gotVaccine);

        if (objectName.Contains("Riddle"))
        {
            toggleObjectives[2].isOn = true;
            riddleManager.ProcessRiddle(objectName);
            audioManager.PlayAudioPickUpPaper();
        }

        if (objectName.Contains("Special Syrup"))
        {
            ObtainSyrup();
        }

        if (objectName.Contains("Coin"))
        {
            noteController.ShowNote(TextManager.coinAdded, 1.5f);
            SaveManager.SetCoin();
            audioManager.PlayAudioPickUpCoin();
        }

        inventory.ReloadInventory();
        GameObject detectedObject = GameObject.Find("Item/" + objectName);
        detectedObject.SetActive(false);
        gameObject.SetActive(false);
#if UNITY_EDITOR
        Debug.Log("<color=white>ItemGet</color> - Added to inventory: " + objectName);
#endif
    }

    public void ItemInfo(string itemNote, string objName)
    {
        objectName = objName;
        grabItem.text = itemNote;
#if UNITY_EDITOR
        Debug.Log("<color=white>ItemGet</color> - Detected Item: " + objectName);
#endif
    }

    void SaveKey(string keyName, string keyNote)
    {
        if (SaveManager.replayStage == 1)
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>ItemGet</color> - <b>Replay</b> Key Name: " + keyName);
#endif
            SaveManager.SetReplayKeyName(keyName, 1);
            SaveManager.SetReplayKeyCount();
            taskKeyText.text = "Keys (" + SaveManager.replayKeyCount + " of 6)";
            noteController.ShowNote(keyNote + "</color> " + TextManager.addedToInventory, 3.0f);
            audioManager.PlayAudioPickUpKey();
            SaveManager.GetReplayKeyCount();
 #if UNITY_EDITOR
            Debug.Log("<color=white>ItemGet</color> - <b>Replay</b> Key Count: " + SaveManager.replayKeyCount);
 #endif
            if (SaveManager.replayKeyCount == 6)
                toggleObjectives[3].isOn = true;
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>ItemGet</color> - Key Name: " + keyName);
#endif
            SaveManager.SetKeyName(keyName, 1);
            SaveManager.SetKeyCount();
            taskKeyText.text = "Keys (" + SaveManager.keyCount + " of 6)";
            noteController.ShowNote(keyNote + "</color> " + TextManager.addedToInventory, 3.0f);
            audioManager.PlayAudioPickUpKey();
            SaveManager.GetKeyCount();
#if UNITY_EDITOR
            Debug.Log("<color=white>ItemGet</color> - Key Count: " + SaveManager.keyCount);
#endif
            if (SaveManager.keyCount == 6)
                toggleObjectives[3].isOn = true;
        }

    }

    void ObtainMainItem(int stageNum, int immunity, string info)
    {
        if (SaveManager.replayStage == 1)
        {
            infoMain = info;
            SaveManager.SetReplayMainItem(stageNum);
            SaveManager.SetReplayCurrrentImmunity(immunity);
            toggleObjectives[0].isOn = true;
            immunityController.SetImmunityReplay();
            healthController.GetCurrentImmunityReplay();
        }
        else
        {
            infoMain = info;
            SaveManager.SetMainItem(stageNum);
            SaveManager.SetCurrrentImmunity(immunity);
            immunityController.SetImmunity();
            healthController.GetCurrentImmunity();

        }
        toggleObjectives[0].isOn = true;
        audioManager.PlayAudioPickUpItem();
        exitPoint.SetActive(true);
        mainEffect.SetActive(true);
        if (stageNum == 3) charObjController.EnableFaceMask();
        if (stageNum == 4) charObjController.EnableFaceShield();
    }

    void ObtainSyrup()
    {
        if (SaveManager.replayStage == 1)
        {
            SaveManager.SetReplaySpecialSyrup(objectName, 1);
            audioManager.PlayAudioPickUpBottle();
            toggleObjectives[1].isOn = true;
        }
        else
        {
            SaveManager.SetSpecialSyrup(objectName, 1);
            audioManager.PlayAudioPickUpBottle();
            toggleObjectives[1].isOn = true;
            SaveManager.GetShowSyrupEffect();
            if (SaveManager.showSyrupEffect == 0)
            {
                audioManager.PlayAudioVoiceOverF();
                syrupEffect.SetActive(true);
                SaveManager.SetShowSyrupEffect(1);

            }
        }
    }

    public void ShowNoteAfteMrMainEffects()
    {
        noteController.ShowNote(infoMain, 300.0f);
    }
}
