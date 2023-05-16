using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class HealthController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject character;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform spawnPoint;

    [Header("Health")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private float currentHP = 100f;
    [SerializeField] private TextMeshProUGUI healthCountText;
    [SerializeField] private GameObject healthBarFill;

    [Header("Button")]
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject mapButton;

    [Header("Object")]
    [SerializeField] private GameObject infectedNote;
    [SerializeField] private GameObject stageNumber;
    [SerializeField] private GameObject stageTask;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private GameObject replayExitUI;

    [Header("Script")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Inventory inventory;
    [SerializeField] private NoteController noteController;

    [Header("Character Control")]
    [SerializeField] private GameObject touchZoneVirtualMove;
    [SerializeField] private GameObject touchZoneCanvas;
    [SerializeField] private GameObject playerFollowCamera;

    [Header("NPC")]
    [Range(1, 3)]
    [SerializeField] private float damageEverySecond = 3f;
    [SerializeField] private GameObject bloodSmear;

    [Header("Quarantine")]
    [SerializeField] private GameObject lifeObject;
    [SerializeField] private TextMeshProUGUI lifeText;

    [Header("Animation and Prefab")]
    [SerializeField] private RuntimeAnimatorController[] animatorControllers;

    public int useSyrup = 0;
    public float characterHP;
    public bool isAlive = true;
    public bool isInfected = false;
    float currImmunity;
    bool achievementA = true;
    bool stopInfection = false;


    void Awake()
    {
        healthBar.value = currentHP;
        characterHP = currentHP;
    }

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        animator = character.GetComponent<Animator>();
        SaveManager.GetCurrentStageScene();
        SaveManager.GetMainItem();
        GetCurrentImmunity();
    }

    public void ChangeHealthPoint(float dmgAmount, int dmgNpc)
    {
        if (isAlive)
        {
            float immunityReduceDmg = (currImmunity / 100f) * dmgAmount;
            float damageAmount = dmgAmount - immunityReduceDmg;
            // Debug.Log("NPC Damage: " + dmgAmount + "  Reduce Damage Immunity: " + immunityReduceDmg + " = Calculated Damage: " + damageAmount);
            currentHP -= damageAmount;
            characterHP = currentHP;
            if (currentHP < 1)
            {
                currentHP = 0;
            }
            healthCountText.text = currentHP.ToString("f0");
            healthBar.value = currentHP;
#if UNITY_EDITOR
            Debug.Log("<color=white>HealthController</color> - Current HP: <color=red>" + currentHP + "</color>  Damage: <color=red>" + dmgAmount + "</color>  <color=green>[Npc]</color>");
#endif
            if (currentHP < 1)
            {
                StartCoroutine(CharacterDied());
            }
            if (dmgNpc == 1)  // Added because of Traps in Stage 2
            {
                audioManager.PlayAudioZombieAttack();
                if (!isInfected)
                {
                    if (currImmunity < 100)
                        StartCoroutine(CharacterInfected());
                }
            }
            if (achievementA)
            {
                if (currentHP < 100)
                {
                    SaveManager.SetAchievement(6, 0);
                    if (SaveManager.currentStage == 1)
                    {
                        SaveManager.SetAchievement(2, 0);
                    }
                    achievementA = false;
                }
            }
        }
    }

    IEnumerator CharacterInfected()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>HealthController</color> - <color=red>Player is now infected</color>");
#endif
        isInfected = true;
        audioManager.PlayAudioHeartBeat();
        infectedNote.SetActive(true);
        bloodSmear.SetActive(true);
        SaveManager.GetCurrentImmunity();
        float immunityNum = (float)SaveManager.currentImmunity;
        float damagePerSecond = damageEverySecond - ((immunityNum / 100f) * 3f);
        while (true)
        {
            if (currentHP < 1)
            {
                if (isAlive)
                {
                    StartCoroutine(CharacterDied());
                    yield break;
                }
                else
                    yield break;
            }
            if (stopInfection)
            {
                stopInfection = false;
                yield break;
            }
            if (currentHP > 0)
            {
                currentHP -= damagePerSecond;
                characterHP = currentHP;
                if (currentHP < 1)
                {
                    if (isAlive)
                    {
                        currentHP = 0;
                        StartCoroutine(CharacterDied());
                        yield break;
                    }
                }
                healthCountText.text = currentHP.ToString("f0");
                healthBar.value = currentHP;
#if UNITY_EDITOR
                Debug.Log("<color=white>HealthController</color> - Current HP: <color=red>" + currentHP + "</color>  Damage: <color=red>" + damagePerSecond + "</color>  <color=green>[Infection]</color>");
#endif
                yield return new WaitForSeconds(damageEverySecond);
            }

        }
    }

    public void GetCurrentImmunity()
    {
        SaveManager.GetCurrentImmunity();
        currImmunity = SaveManager.currentImmunity;
    }

    public void GetCurrentImmunityReplay()
    {
        SaveManager.GetReplayCurrentImmunity();
        currImmunity = SaveManager.replayCurrentImmunity;
    }

    IEnumerator CharacterDied()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>HealthController</color> - Character Died");
#endif
        isAlive = false;
        isInfected = false;
        healthCountText.text = "0";
        yield return new WaitForSeconds(0.1f);
        infectedNote.SetActive(false);
        ObjectSetActive(false);
        SaveManager.GetReplayStage();
        if (SaveManager.replayStage == 1)
        {
            SaveManager.GetReplayCurrentLife();
            int replayCurrentLife = SaveManager.replayCurrentLife;
            if (replayCurrentLife > 0)
            {
                replayCurrentLife -= 1;
            }
            SaveManager.SetReplayCurrentLife(replayCurrentLife);
            lifeText.text = "Life: " + replayCurrentLife;
#if UNITY_EDITOR
        Debug.Log("<color=white>HealthController</color> - <b>Replay</b> Current Life: " + replayCurrentLife);
#endif
            if (replayCurrentLife <= 0)
            {
                replayExitUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            SaveManager.GetCurrentLife();
            int currentLife = SaveManager.currentLife;
            if (currentLife > 0)
            {
                currentLife -= 1;
            }
            SaveManager.SetCurrentLife(currentLife);
            lifeText.text = "Life: " + currentLife;
#if UNITY_EDITOR
        Debug.Log("<color=white>HealthController</color> - Life: " + currentLife);
#endif
            if (currentLife <= 0)
            {
                ToQuarantineArea();
            }
        }
        animator.runtimeAnimatorController = animatorControllers[0];
        StartCoroutine(CharacterDeath());
    }

    public void ReplayStageExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
    }

    IEnumerator CharacterDeath()
    {
        yield return new WaitForSeconds(1.5f);
        deathUI.SetActive(true);
        audioManager.StopAudioLoop();
        audioManager.PlayAudioDeadCharacter();
        touchZoneVirtualMove.SetActive(true);
        character.SetActive(false);
        animator.runtimeAnimatorController = animatorControllers[1];
    }

    public void ToQuarantineArea()
    {
        SaveManager.GetCurrentStageScene();
        SaveManager.ResetSaveGame(SaveManager.currentStage);
        audioManager.StopAudioLoop();
        audioManager.StopAmbience();
        audioManager.StopAudio();
        loadingUI.SetActive(true);
        SaveManager.GetAchievementViolator();
        int pVl = SaveManager.playerViolation + 1;
        SaveManager.SetAchievementViolator(pVl);
        SaveManager.DeleteQuarantineTime();
        SceneManager.LoadScene("StageQuarantine", LoadSceneMode.Single);
    }

    public void RespawnCharacter()
    {
        character.transform.position = spawnPoint.transform.position;
        isAlive = true;
        isInfected = false;
        audioManager.StopAudioLoop();
        infectedNote.SetActive(false);
        ObjectSetActive(true);
        deathUI.SetActive(false);
        bloodSmear.SetActive(false);
        character.SetActive(true);
        animator.runtimeAnimatorController = animatorControllers[1];
        currentHP = 100f;
        healthBar.value = currentHP;
        healthCountText.text = currentHP.ToString();
    }

    public void LoadHealthInfection()
    {
        SaveManager.GetCharacterHealth();
        SaveManager.GetCharacterInfection();
        currentHP = SaveManager.characterHP;
        healthBar.value = SaveManager.characterHP;
        healthCountText.text = SaveManager.characterHP.ToString();
        SaveManager.GetCharacterInfection();
        if (SaveManager.isCharacterInfected == 1)
            StartCoroutine(CharacterInfected());
    }

    public void StopInfection()
    {
        if (isInfected)
        {
            stopInfection = true;
            isInfected = false;
            bloodSmear.SetActive(false);
            infectedNote.SetActive(false);
            inventory.ReloadInventory();
            audioManager.StopAudioLoop();
            noteController.ShowNote(TextManager.stopInfection, 2);
            useSyrup = 1;
        }
        else
        {
            noteController.ShowNote(TextManager.notInfected, 2);
            useSyrup = 0;
        }
    }

    void ObjectSetActive(bool setBool)
    {
        touchZoneVirtualMove.SetActive(setBool);
        settingsButton.SetActive(setBool);
        inventoryButton.SetActive(setBool);
        mapButton.SetActive(setBool);
        healthBarFill.SetActive(setBool);
        stageNumber.SetActive(setBool);
        stageTask.SetActive(setBool);
        lifeObject.SetActive(setBool);
        playerFollowCamera.SetActive(setBool);
        touchZoneCanvas.SetActive(setBool);
    }
}
