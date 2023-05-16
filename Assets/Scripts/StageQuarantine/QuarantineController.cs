using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;

public class QuarantineController : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private GameObject[] specialSyrupObj;
    [SerializeField] private VideoClip[] videoClip;

    [SerializeField] private VideoPlayer videoPlayer;

    [Header("Character Object")]
    [SerializeField] private GameObject faceMaskObject;
    [SerializeField] private GameObject faceShieldObject;
    [SerializeField] private GameObject particleStar;

    [Header("Quarantine Object")]
    [SerializeField] private GameObject quarantineTime;
    [SerializeField] private GameObject quarantinePosition;
    [SerializeField] private GameObject quarantineInfo;
    [SerializeField] private GameObject playFollowCamera;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject quizManager;
    //[SerializeField] private GameObject health;

    [Header("Touch Zone")]
    [SerializeField] private GameObject canvasTouchZone;
    [SerializeField] private GameObject canvasTouchZoneLook;
    [SerializeField] private GameObject canvasTouchZoneMoveNew;
    [SerializeField] private GameObject canvasTouchZoneSprint;

    [Header("Watch Advertisement")]
    [SerializeField] private GameObject characterView;
    [SerializeField] private GameObject cameraTimeline;
    [SerializeField] private PlayableDirector cameraTimelineDirector;
    [SerializeField] private GameObject cubeTV;
    [SerializeField] private GameObject remoteButton;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject advertisementText;
    [SerializeField] private bool isWatching = false;
    [SerializeField] private AudioManager audioManager;

    [Header("Message")]
    [SerializeField] private GameObject quaratineTuts;
    [SerializeField] private GameObject playerMessage;
    [SerializeField] private GameObject quarantineStart;
    [SerializeField] private GameObject quarantineFinish;
    [SerializeField] private GameObject okayButton;
    [SerializeField] private TextMeshProUGUI okayButtonText;
    [Range(1, 10)]
    [SerializeField] private int okayButtonCountdown = 10;

    [Header("Countdown")]
    [Range(1.0f, 1800.0f)]
    [SerializeField] private float timeRemainingSeconds;
    [SerializeField] private TextMeshProUGUI quarantineTimeText;
    [SerializeField] private bool timerIsRunning = false;

    int timerSpeed = 1;
    int timerSpeedAds = 4;
    bool isQuarantine = true;
    int currentClip = 0;
    int adsChannel = 0;


    void Awake()
    {
        SaveManager.GetCurrentCharacter();
        GameObject prefab = characterPrefabs[SaveManager.currentCharacter];
        GameObject clone = Instantiate(prefab, quarantinePosition.transform.position, Quaternion.identity);
        characterView = clone;
        okayButtonText.text = "OKAY (" + okayButtonCountdown + ")";
    }

    void Start()
    {
        SaveManager.SetQuarantine(1);
        playerMessage.SetActive(true);
        audioManager.PlayAudioQuarantineVoiceStart();
        quarantineStart.SetActive(true);

        //health.SetActive(false);
        canvasTouchZone.SetActive(false);

        isQuarantine = true;
        okayButton.GetComponent<Button>().interactable = false;
        StartCoroutine(ChangeQuarantineButtonCount());

        // Enable Special Syrup if locked
        SaveManager.GetSpecialSyrup();
        if (SaveManager.syrupA == 2) specialSyrupObj[0].SetActive(true);
        if (SaveManager.syrupB == 2) specialSyrupObj[1].SetActive(true);
        if (SaveManager.syrupC == 2) specialSyrupObj[2].SetActive(true);
        if (SaveManager.syrupD == 2) specialSyrupObj[3].SetActive(true);
        if (SaveManager.syrupE == 2) specialSyrupObj[4].SetActive(true);

        faceMaskObject = GameObject.FindGameObjectWithTag("FaceMask");
        faceShieldObject = GameObject.FindGameObjectWithTag("FaceShield");
        particleStar = GameObject.FindGameObjectWithTag("ParticleStar");
        if (faceMaskObject != null) faceMaskObject.SetActive(false);
        if (faceShieldObject != null) faceShieldObject.SetActive(false);
        if (particleStar != null) particleStar.SetActive(false);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemainingSeconds > 0)
            {
                timeRemainingSeconds -= Time.deltaTime * timerSpeed;
                DisplayTime(timeRemainingSeconds);
            }
            else
            {
                timeRemainingSeconds = 0;
                timerIsRunning = false;
                QuarantineFinish();
            }
        }
    }

    public void CloseQuarantineMessage()
    {
        if (isQuarantine)
        {
            SaveManager.GetQuarantineTutorial();
            if (SaveManager.quarantineShowTutorial == 0)
            {
                quaratineTuts.SetActive(true);
                SaveManager.SetQuarantineTutorial();
            }
            SaveManager.GetQuarantineTime();
            if (SaveManager.quarantineTime > 0)
            {
                timeRemainingSeconds = SaveManager.quarantineTime;
            }
            playerMessage.SetActive(false);
            quarantineStart.SetActive(false);
            okayButton.SetActive(false);
            settingsButton.SetActive(true);
            playFollowCamera.SetActive(true);
            remoteButton.SetActive(true);
            canvasTouchZone.SetActive(true);
            canvasTouchZoneLook.SetActive(true);
            canvasTouchZoneSprint.SetActive(false);
            canvasTouchZoneMoveNew.SetActive(true);
            timerIsRunning = true;
            audioManager.StopAudio();
        }
        else
        {
            SaveManager.SetCurrentLife(3);
            SaveManager.GetCurrentStage();
            if (SaveManager.currentStage == 1) SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
            if (SaveManager.currentStage == 2) SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
            if (SaveManager.currentStage == 3) SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
            if (SaveManager.currentStage == 4) SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
            if (SaveManager.currentStage == 5) SceneManager.LoadScene("Stage5", LoadSceneMode.Single);
            //health.SetActive(true);
            okayButton.SetActive(false);
            StartCoroutine(WaitCamera());
        }
    }

    public void WatchAds()
    {
        if (!isWatching)
        {
            remoteButton.SetActive(false);
            cameraTimeline.SetActive(true);
            cameraTimelineDirector.stopped += OnPlayableDirectorStopped;
        }
        else
        {
            characterView.SetActive(true);
            cameraTimeline.SetActive(false);
            remoteButton.SetActive(true);
            quarantineTime.SetActive(true);
            quarantineInfo.SetActive(true);
            previousButton.SetActive(false);
            nextButton.SetActive(false);
            advertisementText.SetActive(false);
            cubeTV.SetActive(false);
            canvasTouchZone.SetActive(true);
            isWatching = false;
            timerSpeed = 1;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (seconds == 30)
        {
            SaveManager.SetQuarantineTime(timeToDisplay);
        }
        quarantineTimeText.text = "Time Remaning: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (cameraTimelineDirector == aDirector)
        {
            isWatching = true;
            quarantineTime.SetActive(false);
            quarantineInfo.SetActive(false);
            videoPlayer.clip = videoClip[0];
            previousButton.SetActive(true);
            nextButton.SetActive(true);
            advertisementText.SetActive(true);
            remoteButton.SetActive(true);
            canvasTouchZone.SetActive(false);
            videoPlayer.clip = videoClip[adsChannel];
            cubeTV.SetActive(true);
            characterView.SetActive(false);
            timerSpeed = timerSpeedAds;
            // Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
        }
    }

    void QuarantineFinish()
    {
        quizManager.SetActive(true);
    }

    public void QuarantineExit()
    {
        audioManager.PlayAudioQuarantineVoiceFinish();
        SaveManager.SetQuarantine(0);
        SaveManager.SetQuarantineExit();
        SaveManager.DeleteQuarantineTime();
        previousButton.SetActive(false);
        nextButton.SetActive(false);
        advertisementText.SetActive(false);
        playerMessage.SetActive(true);
        quarantineFinish.SetActive(true);
        okayButton.SetActive(true);
        remoteButton.SetActive(false);
        cubeTV.SetActive(false);
        isQuarantine = false;
    }

    public void QuizFailed()
    {
        timerIsRunning = true;
        timeRemainingSeconds = 300;
    }

    IEnumerator ChangeQuarantineButtonCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            okayButtonCountdown--;
            okayButtonText.text = "OKAY (" + okayButtonCountdown + ")";
            if (okayButtonCountdown == 0)
            {
                okayButtonText.text = "OKAY";
                okayButton.GetComponent<Button>().interactable = true;
                yield break;
            }
        }
    }

    IEnumerator WaitCamera()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        canvasTouchZone.SetActive(true);
        canvasTouchZoneMoveNew.SetActive(true);
        canvasTouchZoneSprint.SetActive(true);
    }

    public void NextAds()
    {
        currentClip = (currentClip + 1) % videoClip.Length;
        adsChannel = currentClip;
        videoPlayer.clip = videoClip[currentClip];
    }

    public void PreviousAds()
    {
        currentClip--;
        if (currentClip < 0)
            currentClip += videoClip.Length;
        adsChannel = currentClip;
        videoPlayer.clip = videoClip[currentClip];
    }
}
