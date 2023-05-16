using UnityEngine;

public class DoorTriggerController : MonoBehaviour, IInteractable
{
    // www.youtube.com/watch?v=tJiO4cvsHAo

    [SerializeField] public Animator myDoor = null;

    [Header("Trigger Value")]
    [SerializeField] private bool openOutsideT = false;
    [SerializeField] private bool closeOutsideT = false;
    [SerializeField] private bool openInsideT = false;
    [SerializeField] private bool closeInsideT = false;

    [Header("Door Collider Object")]
    [SerializeField] private GameObject openOutside;
    [SerializeField] private GameObject closeOutside;

    [SerializeField] private GameObject openInside;
    [SerializeField] private GameObject closeInside;

    [Header("Animation Collider")]
    [SerializeField] private GameObject animCollider;
    [SerializeField] private bool animeColliderEnabled = false;

    [Header("Door Button")]
    [SerializeField] private GameObject doorAccessObject;
    public Sprite handImage;
    public Sprite keyImage;

    [Header("Door Audio Clip")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private bool playOpenAudio = false;
    [SerializeField] private bool playCloseAudio = false;

    [Header("Key")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private bool isQuarantined = false;

    [SerializeField] private bool requireKeyA = false;
    [SerializeField] private bool requireKeyB = false;
    [SerializeField] private bool requireKeyC = false;
    [SerializeField] private bool requireKeyD = false;
    [SerializeField] private bool requireKeyE = false;
    [SerializeField] private bool requireKeyF = false;

    [Header("Scripts")]
    [SerializeField] private NoteController noteController;
    [SerializeField] private Inventory inventory;

    int currentStage;
    bool requireKeyFail = false;


    void Awake()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteKey("<color=white>DoorTriggerController</color> - Awake");
#endif
        keyImage = Resources.Load<Sprite>("Art/Icons/KeyTwo");
        handImage = Resources.Load<Sprite>("Art/Icons/hand_icon_white");
    }

    void Start()
    {
        SaveManager.GetReplayStage();
        myDoor = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save Door Name and Object Name
            PlayerPrefs.SetString("Door Name", myDoor.name + "/" + gameObject.name);

            // if door animation finished enable the door button
            SaveManager.GetDoorAccess();
            if (SaveManager.doorAccess == 1)
                doorAccessObject.SetActive(true);
#if UNITY_EDITOR
            Debug.Log("<color=green>DoorTriggerController</color> - <color=white>Door Name:</color> " + gameObject.name + " - <color=white>EnableDoorButton:</color> " + SaveManager.doorAccess + " Door Name: " + myDoor.name);
#endif
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveManager.GetDoorAccess();
            if (SaveManager.doorAccess == 1)
                doorAccessObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.DeleteKey("Door Name");
            doorAccessObject.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        // Bug note: If door doesnt animate or only play sounds or other bug try to renamed the door to a unique name
        // It must be a bug in checking door using playerprefs
        if (isQuarantined)
        {
            noteController.ShowNote(TextManager.quarantineArea, 5.0f);
            doorAccessObject.SetActive(false);
            audioManager.PlayAudioDoorLockedNoKey();
            return;
        }

        if (isLocked)
        {
            noteController.ShowNote(TextManager.doorIsLocked, 1.2f);
            doorAccessObject.SetActive(false);
            audioManager.PlayAudioDoorLockedNoKey();
            return;
        }

        SaveManager.GetCurrentStageScene();
        currentStage = SaveManager.currentStage;
#if UNITY_EDITOR
        Debug.Log("<color=white>DoorTriggerController</color> - OpenDoor() Current Stage: " + currentStage);
#endif

        if (currentStage == 1)
        {
            if (requireKeyA) RequiresKey(TextManager.S1_KeyWarn_A, "S1 Key A", TextManager.S1_DoorKey_A);
            if (requireKeyB) RequiresKey(TextManager.S1_KeyWarn_B, "S1 Key B", TextManager.S1_DoorKey_B);
            if (requireKeyC) RequiresKey(TextManager.S1_KeyWarn_C, "S1 Key C", TextManager.S1_DoorKey_C);
            if (requireKeyD) RequiresKey(TextManager.S1_KeyWarn_D, "S1 Key D", TextManager.S1_DoorKey_D);
            if (requireKeyE) RequiresKey(TextManager.S1_KeyWarn_E, "S1 Key E", TextManager.S1_DoorKey_E);
            if (requireKeyF) RequiresKey(TextManager.S1_KeyWarn_F, "S1 Key F", TextManager.S1_DoorKey_F);
            if (requireKeyFail)
                return;
        }
        if (currentStage == 2)
        {
            if (requireKeyA) RequiresKey(TextManager.S2_KeyWarn_A, "S2 Key A", TextManager.S2_DoorKey_A);
            if (requireKeyB) RequiresKey(TextManager.S2_KeyWarn_B, "S2 Key B", TextManager.S2_DoorKey_B);
            if (requireKeyC) RequiresKey(TextManager.S2_KeyWarn_C, "S2 Key C", TextManager.S2_DoorKey_C);
            if (requireKeyD) RequiresKey(TextManager.S2_KeyWarn_D, "S2 Key D", TextManager.S2_DoorKey_D);
            if (requireKeyE) RequiresKey(TextManager.S2_KeyWarn_E, "S2 Key E", TextManager.S2_DoorKey_E);
            if (requireKeyF) RequiresKey(TextManager.S2_KeyWarn_F, "S2 Key F", TextManager.S2_DoorKey_F);
            if (requireKeyFail)
                return;
        }
        if (currentStage == 5)
        {
            if (requireKeyA) RequiresKey(TextManager.S5_KeyWarn_A, "S5 Key A", TextManager.S5_DoorKey_A);
            if (requireKeyB) RequiresKey(TextManager.S5_KeyWarn_B, "S5 Key B", TextManager.S5_DoorKey_B);
            if (requireKeyC) RequiresKey(TextManager.S5_KeyWarn_C, "S5 Key C", TextManager.S5_DoorKey_C);
            if (requireKeyD) RequiresKey(TextManager.S5_KeyWarn_D, "S5 Key D", TextManager.S5_DoorKey_D);
            if (requireKeyE) RequiresKey(TextManager.S5_KeyWarn_E, "S5 Key E", TextManager.S5_DoorKey_E);
            if (requireKeyF) RequiresKey(TextManager.S5_KeyWarn_F, "S5 Key F", TextManager.S5_DoorKey_F);
            if (requireKeyFail)
                return;
        }

        if (playOpenAudio)
            audioManager.PlayAudioDoorOpen();
        else if (playCloseAudio)
            audioManager.PlayAudioDoorClose();

        if (animeColliderEnabled)
        {
            animCollider.SetActive(true);
            myDoor.enabled = true;
#if UNITY_EDITOR
            Debug.Log("<color=white>DoorTriggerController</color> - Collider Enabled");
#endif
        }
        else
        {
            animCollider.SetActive(false);
            myDoor.enabled = true;
#if UNITY_EDITOR
            Debug.Log("<color=white>DoorTriggerController</color> - Collider Disabled");
#endif
        }

        if (openOutsideT)
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>DoorTriggerController</color> - Open Outside");
#endif
            doorAccessObject.SetActive(false);
            gameObject.SetActive(false);
            closeOutside.SetActive(true);
            closeInside.SetActive(true);
            openInside.SetActive(false);
            myDoor.Play("Door_Open");
        }
        else if (closeOutsideT)
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>DoorTriggerController</color> - Close Outside");
#endif
            doorAccessObject.SetActive(false);
            gameObject.SetActive(false);
            openOutside.SetActive(true);
            openInside.SetActive(true);
            closeInside.SetActive(false);
            myDoor.Play("Door_Close");
        }
        else if (openInsideT)
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>DoorTriggerController</color> - Open Inside");
#endif
            doorAccessObject.SetActive(false);
            gameObject.SetActive(false);
            closeOutside.SetActive(true);
            closeInside.SetActive(true);
            openOutside.SetActive(false);
            myDoor.Play("Door_Open");
        }
        else if (closeInsideT)
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>DoorTriggerController</color> - Close Inside");
#endif
            doorAccessObject.SetActive(false);
            gameObject.SetActive(false);
            openOutside.SetActive(true);
            openInside.SetActive(true);
            closeOutside.SetActive(false);
            myDoor.Play("Door_Close");
        }
    }

    void RequiresKey(string keyWarning, string prefName, string keyName)
    {
        if (SaveManager.replayStage == 1)
        {
            SaveManager.GetReplayKeyName(prefName);
            if (SaveManager.replayKeyName == 0)
            {
                requireKeyFail = true;
                audioManager.PlayAudioDoorLockedKey();
                noteController.ShowNote(keyWarning, 2.3f);
                doorAccessObject.SetActive(false);
#if UNITY_EDITOR
                Debug.Log("<color=white>DoorTriggerController</color> - Key Required");
#endif
            }
            if (SaveManager.replayKeyName == 1)
            {
                requireKeyFail = false;
                noteController.ShowNote(TextManager.unlockingDoor + keyName, 2.0f);
                SaveManager.SetReplayKeyName(prefName, 2);
                inventory.ReloadInventory();
            }
            if (SaveManager.replayKeyName == 2)
            {
                requireKeyFail = false;
                noteController.ShowNote(TextManager.openingDoor + keyName, 2.0f);
            }
        }
        else
        {
            SaveManager.GetKeyName(prefName);
#if UNITY_EDITOR
            Debug.Log("DoorTriggerController</color> - GetKeyName: " + SaveManager.keyName);
#endif
            if (SaveManager.keyName == 0)
            {
                requireKeyFail = true;
                audioManager.PlayAudioDoorLockedKey();
                noteController.ShowNote(keyWarning, 2.3f);
                doorAccessObject.SetActive(false);
#if UNITY_EDITOR
                Debug.Log("<color=white>DoorTriggerController</color> - Key Required");
#endif
            }
            if (SaveManager.keyName == 1)
            {
                requireKeyFail = false;
                noteController.ShowNote(TextManager.unlockingDoor + keyName, 2.0f);
                SaveManager.SetKeyName(prefName, 2);
                inventory.ReloadInventory();
            }
            if (SaveManager.keyName == 2)
            {
                requireKeyFail = false;
                noteController.ShowNote(TextManager.openingDoor + keyName, 2.0f);
            }
        }

    }

    public void OpenableDoor()
    {
        OpenDoor();
    }
}
