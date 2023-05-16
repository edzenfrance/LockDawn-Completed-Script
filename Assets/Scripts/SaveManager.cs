using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{

    public static int currentCharacter;
    public static int currentLife;
    public static int currentCoin;
    public static float currentImmunity;
    public static int currentStage;
    public static int isQuarantine;
    public static int gameDifficulty;
    public static int keyCount;
    public static int keyName;
    public static int doorAccess;
    public static int framerateOn;
    public static float cameraDistance;
    public static float lookSensitivity;
    public static int continueGame;
    public static float quarantineTime;
    public static int quarantineShowTutorial;
    public static int quarantineExitScene;
    public static int nextStage;
    public static int showSyrupEffect;
    public static int stageTime;
    public static int playerViolation;
    public static int doneNewGamePrefs;
    public static int rememberAccount;
    public static int mapFloor;
    public static float characterHP;
    public static int isCharacterInfected;
    public static int graphicsQuality;
    public static int lightAnimation;

    public static int stagePreview;
    public static int stage1Preview;
    public static int stage2Preview;
    public static int stage3Preview;
    public static int stage4Preview;
    public static int stage5Preview;

    public static int stageACompleted;
    public static int stageBCompleted;
    public static int stageCCompleted;
    public static int stageDCompleted;
    public static int stageECompleted;

    public static float musicVolume;
    public static float soundVolume;
    public static int musicMute;
    public static int soundMute;

    public static int achievementA;
    public static int achievementB;
    public static int achievementC;
    public static int achievementD;
    public static int achievementE;
    public static int achievementF;
    public static int achievementG;

    public static int premiumSkinA;
    public static int premiumSkinB;
    public static int premiumSkinC;
    public static int premiumSkinD;

    public static int s1keyA;
    public static int s1keyB;
    public static int s1keyC;
    public static int s1keyD;
    public static int s1keyE;
    public static int s1keyF;

    public static int s2keyA;
    public static int s2keyB;
    public static int s2keyC;
    public static int s2keyD;
    public static int s2keyE;
    public static int s2keyF;

    public static int s5keyA;
    public static int s5keyB;
    public static int s5keyC;
    public static int s5keyD;
    public static int s5keyE;
    public static int s5keyF;

    public static int mainItemA;
    public static int mainItemB;
    public static int mainItemC;
    public static int mainItemD;
    public static int mainItemE;

    public static int riddleA;
    public static int riddleB;
    public static int riddleC;
    public static int riddleD;
    public static int riddleE;

    public static int syrupA;
    public static int syrupB;
    public static int syrupC;
    public static int syrupD;
    public static int syrupE;


    private void Awake()
    {
        keyCount = PlayerPrefs.GetInt("Key Count");
        currentCoin = PlayerPrefs.GetInt("Coin");
    }

    public static void SetGameDifficulty(int diff)
    {
        PlayerPrefs.SetInt("Game Difficulty", diff);
    }

    public static void GetGameDifficulty()
    {
        gameDifficulty = PlayerPrefs.GetInt("Game Difficulty", 2);
    }

    public static void GetCameraDistance()
    {
        cameraDistance = PlayerPrefs.GetFloat("Camera Distance", 1.75f);
    }

    public static void SetCameraDistance(float camdistance)
    {
        PlayerPrefs.SetFloat("Camera Distance", camdistance);
    }

    public static void GetLookSensitivity()
    {
        lookSensitivity = PlayerPrefs.GetFloat("Look Sensitivity", 60f);
    }

    public static void SetLookSensitivity(float looksense)
    {
        PlayerPrefs.SetFloat("Look Sensitivity", looksense);
    }

    public static void SetSoundMute(int num)
    {
        PlayerPrefs.SetInt("Sound Mute", num);
    }

    public static void SetMusicMute(int num)
    {
        PlayerPrefs.SetInt("Music Mute", num);
    }

    public static void SetSoundVolume(float num)
    {
        PlayerPrefs.SetFloat("Sound Volume", num);
    }

    public static void SetMusicVolume(float num)
    {
        PlayerPrefs.SetFloat("Music Volume", num);
    }

    public static void GetSoundMusicVolume()
    {
        soundVolume = PlayerPrefs.GetFloat("Sound Volume", 1);
        musicVolume = PlayerPrefs.GetFloat("Music Volume", 1);
        soundMute = PlayerPrefs.GetInt("Sound Mute", 0);
        musicMute = PlayerPrefs.GetInt("Music Mute", 0);
    }

    public static void SetAchievement(int count, int num)
    {
        // 0 = Failed  1 = Show it  2 = Show --- EXAMPLE: Achievement 1 = Show Off
        PlayerPrefs.SetInt("Achievement " + count, num);
    }

    public static void GetAchievement()
    {
        // 0 = Failed  1 = Show it  2 = Show
        achievementA = PlayerPrefs.GetInt("Achievement 1", 0);
        achievementB = PlayerPrefs.GetInt("Achievement 2", 0);
        achievementC = PlayerPrefs.GetInt("Achievement 3", 0);
        achievementD = PlayerPrefs.GetInt("Achievement 4", 0);
        achievementE = PlayerPrefs.GetInt("Achievement 5", 0);
        achievementF = PlayerPrefs.GetInt("Achievement 6", 0);
        achievementG = PlayerPrefs.GetInt("Achievement 7", 0);
    }

    public static void SetAchievementViolator(int num)
    {
        PlayerPrefs.SetInt("Protocol Violation", num);
    }

    public static void GetAchievementViolator()
    {
        playerViolation = PlayerPrefs.GetInt("Protocol Violation", 0);
    }

    public static void SaveTimeForAchievements(int timer)
    {
        PlayerPrefs.SetInt("S1 Time", timer);
    }

    public static void GetTimeForAchievements()
    {
        stageTime = PlayerPrefs.GetInt("S1 Time");
    }

    public static void SetCurrentLife(int num)
    {
        PlayerPrefs.SetInt("Life", num);
    }

    public static void GetCurrentLife()
    {
        currentLife = PlayerPrefs.GetInt("Life", 3);
        if (currentLife > 3) currentLife = 3; // Anti-Cheat
    }

    public static void SetMainItem(int num)
    {
        PlayerPrefs.SetInt("S" + num + " Main Item", 1);
    }

    public static void SetMainItemPlayfab(int count, int num)
    {
        PlayerPrefs.SetInt("S" + count + " Main Item", num);
    }

    public static void GetMainItem()
    {
        mainItemA = PlayerPrefs.GetInt("S1 Main Item", 0);
        mainItemB = PlayerPrefs.GetInt("S2 Main Item", 0);
        mainItemC = PlayerPrefs.GetInt("S3 Main Item", 0);
        mainItemD = PlayerPrefs.GetInt("S4 Main Item", 0);
        mainItemE = PlayerPrefs.GetInt("S5 Main Item", 0);
    }

    public static void SetQuiz()
    {
        int quaQuiz = PlayerPrefs.GetInt("Quarantine Quiz", 0);
        quaQuiz = quaQuiz + 1;
        PlayerPrefs.SetInt("Quarantine Quiz", quaQuiz);
    }

    public static void SetRiddle(int count, int num)
    {
        // 1 = Wrong - 2 = Correct
        PlayerPrefs.SetInt("S" + count + " Riddle", num);
    }

    public static void GetRiddle()
    {
        riddleA = PlayerPrefs.GetInt("S1 Riddle", 0);
        riddleB = PlayerPrefs.GetInt("S2 Riddle", 0);
        riddleC = PlayerPrefs.GetInt("S3 Riddle", 0);
        riddleD = PlayerPrefs.GetInt("S4 Riddle", 0);
        riddleE = PlayerPrefs.GetInt("S5 Riddle", 0);
    }

    public static void SetCurrentStage(int num)
    {
        PlayerPrefs.SetInt("Current Stage", num);
    }
    public static void GetCurrentStage()
    {
        currentStage = PlayerPrefs.GetInt("Current Stage", 1);
    }

    public static void GetCurrentStageScene()
    {
        Scene m_Scene;
        string sceneName;
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if (sceneName == "Stage1") currentStage = 1;
        if (sceneName == "Stage2") currentStage = 2;
        if (sceneName == "Stage3") currentStage = 3;
        if (sceneName == "Stage4") currentStage = 4;
        if (sceneName == "Stage5") currentStage = 5;
    }

    public static void SetCurrentCharacter(int num)
    {
        PlayerPrefs.SetInt("Current Character", num);
    }

    public static void GetCurrentCharacter()
    {
        currentCharacter = PlayerPrefs.GetInt("Current Character", 0);
    }

    public static void SetSpecialSyrup(string syrupName, int syrupCount)
    {
        PlayerPrefs.SetInt(syrupName, syrupCount);
    }

    public static void SetSpecialSyrupPlayFab(int stageNum, int syrupCount)
    {
        PlayerPrefs.SetInt("S" + stageNum + " Special Syrup", syrupCount);
    }

    public static void GetSpecialSyrup()
    {
        // 1 = Unused, 2 = Used, 3 = Lock In Quarantine Area
        syrupA = PlayerPrefs.GetInt("S1 Special Syrup", 0);
        syrupB = PlayerPrefs.GetInt("S2 Special Syrup", 0);
        syrupC = PlayerPrefs.GetInt("S3 Special Syrup", 0);
        syrupD = PlayerPrefs.GetInt("S4 Special Syrup", 0);
        syrupE = PlayerPrefs.GetInt("S5 Special Syrup", 0);
    }

    public static void SetShowSyrupEffect(int num)
    {
        PlayerPrefs.SetInt("Special Syrup Effect", num);
    }

    public static void GetShowSyrupEffect()
    {
        showSyrupEffect = PlayerPrefs.GetInt("Special Syrup Effect", 0);
    }

    public static void SetCoin()
    {
        currentCoin = PlayerPrefs.GetInt("Coin") + 10;
        PlayerPrefs.SetInt("Coin", currentCoin);
    }

    public static void SetCoinPlayfab(int coincount)
    {
        PlayerPrefs.SetInt("Coin", coincount);
    }

    public static void GetCoin()
    {
        currentCoin = PlayerPrefs.GetInt("Coin", 0);
    }

    public static void SetCoinFromShop(int num)
    {
        PlayerPrefs.SetInt("Coin", num);
    }

    public static void SetKeyCount()
    {
        keyCount = PlayerPrefs.GetInt("Key Count") + 1;
        PlayerPrefs.SetInt("Key Count", keyCount);
    }

    public static void SetKeyCountPlayfab(int num)
    {
        PlayerPrefs.SetInt("Key Count", num);
    }

    public static void GetKeyCount()
    {
        keyCount = PlayerPrefs.GetInt("Key Count", 0);
    }

    public static void ResetKeyCount()
    {
        PlayerPrefs.SetInt("Key Count", 0);
    }

    public static void SetKeyName(string prefsName, int num)
    {
        PlayerPrefs.SetInt(prefsName, num);
    }

    public static void SetKeyNamePlayfab(int stageNum, string keyLetter, int num)
    {
        PlayerPrefs.SetInt("S" + stageNum + " Key " + keyLetter, num);
    }

    public static void GetKeyName(string prefName)
    {
        keyName = PlayerPrefs.GetInt(prefName, 0);
    }

    public static void GetS1Keys()
    {
        s1keyA = PlayerPrefs.GetInt("S1 Key A", 0);
        s1keyB = PlayerPrefs.GetInt("S1 Key B", 0);
        s1keyC = PlayerPrefs.GetInt("S1 Key C", 0);
        s1keyD = PlayerPrefs.GetInt("S1 Key D", 0);
        s1keyE = PlayerPrefs.GetInt("S1 Key E", 0);
        s1keyF = PlayerPrefs.GetInt("S1 Key F", 0);
    }
    public static void GetS2Keys()
    {
        s2keyA = PlayerPrefs.GetInt("S2 Key A", 0);
        s2keyB = PlayerPrefs.GetInt("S2 Key B", 0);
        s2keyC = PlayerPrefs.GetInt("S2 Key C", 0);
        s2keyD = PlayerPrefs.GetInt("S2 Key D", 0);
        s2keyE = PlayerPrefs.GetInt("S2 Key E", 0);
        s2keyF = PlayerPrefs.GetInt("S2 Key F", 0);
    }

    public static void GetS5Keys()
    {
        s5keyA = PlayerPrefs.GetInt("S5 Key A", 0);
        s5keyB = PlayerPrefs.GetInt("S5 Key B", 0);
        s5keyC = PlayerPrefs.GetInt("S5 Key C", 0);
        s5keyD = PlayerPrefs.GetInt("S5 Key D", 0);
        s5keyE = PlayerPrefs.GetInt("S5 Key E", 0);
        s5keyF = PlayerPrefs.GetInt("S5 Key F", 0);
    }

    public static void SetQuarantine(int num)
    {
        PlayerPrefs.SetInt("Quarantine", num);
    }

    public static void GetQuarantine()
    {
        isQuarantine = PlayerPrefs.GetInt("Quarantine", 0);
    }

    public static void SetQuarantineTime(float time)
    {
        PlayerPrefs.SetFloat("Quarantine Time", time);
    }

    public static void GetQuarantineTime()
    {
        quarantineTime = PlayerPrefs.GetFloat("Quarantine Time");
    }

    public static void DeleteQuarantineTime()
    {
        PlayerPrefs.DeleteKey("Quarantine Time");
    }

    public static void SetQuarantineExit()
    {
        Debug.Log("<color=white>SaveManager</color> - Quarantine Exit: 1");
        quarantineExitScene = 1;
    }

    public static void SetQuarantineExitFinish()
    {
        Debug.Log("<color=white>SaveManager</color> - Quarantine Exit: 0");
        quarantineExitScene = 0;
    }

    public static void SetQuarantineTutorial()
    {
        PlayerPrefs.SetInt("Quarantine Tutorial", 1);
    }

    public static void GetQuarantineTutorial()
    {
        quarantineShowTutorial = PlayerPrefs.GetInt("Quarantine Tutorial", 0);
    }

    public static void SetDoorAccess(int num)
    {
        PlayerPrefs.SetInt("Door Access", num);
    }

    public static void GetDoorAccess()
    {
        doorAccess = PlayerPrefs.GetInt("Door Access", 1);
    }

    public static void SetShowFramerate(int num)
    {
        PlayerPrefs.SetInt("Framerate", num);
    }

    public static void GetShowFramerate()
    {
        framerateOn = PlayerPrefs.GetInt("Framerate", 0);
    }

    public static void SetCurrrentImmunity(int immunity)
    {
        PlayerPrefs.SetInt("Current Immunity", immunity);
    }

    public static void GetCurrentImmunity()
    {
        currentImmunity = PlayerPrefs.GetInt("Current Immunity", 0);
    }

    public static void SetCompleteStage(int stagenumber)
    {
        PlayerPrefs.SetInt("S" + stagenumber + " Completed", 1);
    }

    public static void SetCompleteStagePlayfab(int stagenumber, int num)
    {
        PlayerPrefs.SetInt("S" + stagenumber + " Completed", num);
    }

    public static void GetCompleteStage()
    {
        stageACompleted = PlayerPrefs.GetInt("S1 Completed", 0);
        stageBCompleted = PlayerPrefs.GetInt("S2 Completed", 0);
        stageCCompleted = PlayerPrefs.GetInt("S3 Completed", 0);
        stageDCompleted = PlayerPrefs.GetInt("S4 Completed", 0);
        stageECompleted = PlayerPrefs.GetInt("S5 Completed", 0);
    }

    public static void ResetKeyStage(int num)
    {
        if (num == 1)
        {
            PlayerPrefs.SetInt("S1 Key A", 0);
            PlayerPrefs.SetInt("S1 Key B", 0);
            PlayerPrefs.SetInt("S1 Key C", 0);
            PlayerPrefs.SetInt("S1 Key D", 0);
            PlayerPrefs.SetInt("S1 Key E", 0);
            PlayerPrefs.SetInt("S1 Key F", 0);
            PlayerPrefs.SetInt("Key Count", 0);
        }
        if (num == 2)
        {
            PlayerPrefs.SetInt("S2 Key A", 0);
            PlayerPrefs.SetInt("S2 Key B", 0);
            PlayerPrefs.SetInt("S2 Key C", 0);
            PlayerPrefs.SetInt("S2 Key D", 0);
            PlayerPrefs.SetInt("S2 Key E", 0);
            PlayerPrefs.SetInt("S2 Key F", 0);
            PlayerPrefs.SetInt("Key Count", 0);
        }
        if (num == 5)
        {
            PlayerPrefs.SetInt("S5 Key A", 0);
            PlayerPrefs.SetInt("S5 Key B", 0);
            PlayerPrefs.SetInt("S5 Key C", 0);
            PlayerPrefs.SetInt("S5 Key D", 0);
            PlayerPrefs.SetInt("S5 Key E", 0);
            PlayerPrefs.SetInt("S5 Key F", 0);
            PlayerPrefs.SetInt("Key Count", 0);
        }

        /*
        if (num == 1)
        {
            PlayerPrefs.DeleteKey("S1 Key A");
            PlayerPrefs.DeleteKey("S1 Key B");
            PlayerPrefs.DeleteKey("S1 Key C");
            PlayerPrefs.DeleteKey("S1 Key D");
            PlayerPrefs.DeleteKey("S1 Key E");
            PlayerPrefs.DeleteKey("S1 Key F");
            PlayerPrefs.DeleteKey("Key Count");
        }
        if (num == 2)
        {
            PlayerPrefs.DeleteKey("S2 Key A");
            PlayerPrefs.DeleteKey("S2 Key B");
            PlayerPrefs.DeleteKey("S2 Key C");
            PlayerPrefs.DeleteKey("S2 Key D");
            PlayerPrefs.DeleteKey("S2 Key E");
            PlayerPrefs.DeleteKey("S2 Key F");
            PlayerPrefs.DeleteKey("Key Count");
        }
        if (num == 5)
        {
            PlayerPrefs.DeleteKey("S5 Key A");
            PlayerPrefs.DeleteKey("S5 Key B");
            PlayerPrefs.DeleteKey("S5 Key C");
            PlayerPrefs.DeleteKey("S5 Key D");
            PlayerPrefs.DeleteKey("S5 Key E");
            PlayerPrefs.DeleteKey("S5 Key F");
            PlayerPrefs.DeleteKey("Key Count");
        }
        */

    }

    public static void NewGamePreference()
    {
        Debug.Log("<color=white>SaveManager</color> - New Game Preferences");
		PlayerPrefs.SetInt("S1 Key A", 0);
		PlayerPrefs.SetInt("S1 Key B", 0);
		PlayerPrefs.SetInt("S1 Key C", 0);
		PlayerPrefs.SetInt("S1 Key D", 0);
		PlayerPrefs.SetInt("S1 Key E", 0);
		PlayerPrefs.SetInt("S1 Key F", 0);

        PlayerPrefs.SetInt("S2 Key A", 0);
        PlayerPrefs.SetInt("S2 Key B", 0);
        PlayerPrefs.SetInt("S2 Key C", 0);
        PlayerPrefs.SetInt("S2 Key D", 0);
        PlayerPrefs.SetInt("S2 Key E", 0);
        PlayerPrefs.SetInt("S2 Key F", 0);

        PlayerPrefs.SetInt("S5 Key A", 0);
        PlayerPrefs.SetInt("S5 Key B", 0);
        PlayerPrefs.SetInt("S5 Key C", 0);
        PlayerPrefs.SetInt("S5 Key D", 0);
        PlayerPrefs.SetInt("S5 Key E", 0);
        PlayerPrefs.SetInt("S5 Key F", 0);

        PlayerPrefs.SetInt("S1 Riddle", 0);
        PlayerPrefs.SetInt("S2 Riddle", 0);
        PlayerPrefs.SetInt("S3 Riddle", 0);
        PlayerPrefs.SetInt("S4 Riddle", 0);
        PlayerPrefs.SetInt("S5 Riddle", 0);

        PlayerPrefs.SetInt("S1 Main Item", 0);
        PlayerPrefs.SetInt("S2 Main Item", 0);
        PlayerPrefs.SetInt("S3 Main Item", 0);
        PlayerPrefs.SetInt("S4 Main Item", 0);
        PlayerPrefs.SetInt("S5 Main Item", 0);

        PlayerPrefs.SetInt("S1 Completed", 0);
        PlayerPrefs.SetInt("S2 Completed", 0);
        PlayerPrefs.SetInt("S3 Completed", 0);
        PlayerPrefs.SetInt("S4 Completed", 0);
        PlayerPrefs.SetInt("S5 Completed", 0);

        PlayerPrefs.SetInt("S1 Special Syrup", 0);
        PlayerPrefs.SetInt("S2 Special Syrup", 0);
        PlayerPrefs.SetInt("S3 Special Syrup", 0);
        PlayerPrefs.SetInt("S4 Special Syrup", 0);
        PlayerPrefs.SetInt("S5 Special Syrup", 0);

		PlayerPrefs.SetInt("Achievement 1", 0);
        PlayerPrefs.SetInt("Achievement 2", 0);
        PlayerPrefs.SetInt("Achievement 3", 0);
        PlayerPrefs.SetInt("Achievement 4", 0);
        PlayerPrefs.SetInt("Achievement 5", 0);
        PlayerPrefs.SetInt("Achievement 6", 0);

        PlayerPrefs.SetInt("S1 Map Floor", 0);
        PlayerPrefs.SetInt("S2 Map Floor", 0);
        PlayerPrefs.SetInt("S5 Map Floor", 0);

        PlayerPrefs.SetInt("S1 Preview", 0);
        PlayerPrefs.SetInt("S2 Preview", 0);
        PlayerPrefs.SetInt("S3 Preview", 0);
        PlayerPrefs.SetInt("S4 Preview", 0);
        PlayerPrefs.SetInt("S5 Preview", 0);

        PlayerPrefs.SetInt("Special Syrup Effect", 0);
        PlayerPrefs.SetInt("Key Count", 0);
        PlayerPrefs.SetInt("Character Position", 0);
        PlayerPrefs.SetInt("Next Stage", 0);
        PlayerPrefs.SetInt("Quarantine Time", 0);
        PlayerPrefs.DeleteKey("Door Access");
        PlayerPrefs.DeleteKey("Camera Distance");

        PlayerPrefs.SetInt("Framerate", 0);
        PlayerPrefs.SetInt("Current Stage", 1);
		PlayerPrefs.SetInt("Current Immunity", 0);
        PlayerPrefs.SetInt("Life", 3);
        PlayerPrefs.SetInt("Quarantine", 0);
        PlayerPrefs.SetInt("Continue Game", 0);
        // PlayerPrefs.SetInt("Coin", 0);

        /*
        PlayerPrefs.DeleteKey("S1 Key A");
		PlayerPrefs.DeleteKey("S1 Key B");
		PlayerPrefs.DeleteKey("S1 Key C");
		PlayerPrefs.DeleteKey("S1 Key D");
		PlayerPrefs.DeleteKey("S1 Key E");
		PlayerPrefs.DeleteKey("S1 Key F");

        PlayerPrefs.DeleteKey("S2 Key A");
        PlayerPrefs.DeleteKey("S2 Key B");
        PlayerPrefs.DeleteKey("S2 Key C");
        PlayerPrefs.DeleteKey("S2 Key D");
        PlayerPrefs.DeleteKey("S2 Key E");
        PlayerPrefs.DeleteKey("S2 Key F");

        PlayerPrefs.DeleteKey("S5 Key A");
        PlayerPrefs.DeleteKey("S5 Key B");
        PlayerPrefs.DeleteKey("S5 Key C");
        PlayerPrefs.DeleteKey("S5 Key D");
        PlayerPrefs.DeleteKey("S5 Key E");
        PlayerPrefs.DeleteKey("S5 Key F");

        PlayerPrefs.DeleteKey("S1 Riddle");
        PlayerPrefs.DeleteKey("S2 Riddle");
        PlayerPrefs.DeleteKey("S3 Riddle");
        PlayerPrefs.DeleteKey("S4 Riddle");
        PlayerPrefs.DeleteKey("S5 Riddle");

        PlayerPrefs.DeleteKey("S1 Main Item");
        PlayerPrefs.DeleteKey("S2 Main Item");
        PlayerPrefs.DeleteKey("S3 Main Item");
        PlayerPrefs.DeleteKey("S4 Main Item");
        PlayerPrefs.DeleteKey("S5 Main Item");

        PlayerPrefs.DeleteKey("S1 Completed");
        PlayerPrefs.DeleteKey("S2 Completed");
        PlayerPrefs.DeleteKey("S3 Completed");
        PlayerPrefs.DeleteKey("S4 Completed");
        PlayerPrefs.DeleteKey("S5 Completed");

        PlayerPrefs.DeleteKey("S1 Special Syrup");
        PlayerPrefs.DeleteKey("S2 Special Syrup");
        PlayerPrefs.DeleteKey("S3 Special Syrup");
        PlayerPrefs.DeleteKey("S4 Special Syrup");
        PlayerPrefs.DeleteKey("S5 Special Syrup");

		PlayerPrefs.DeleteKey("Achievement 1");
        PlayerPrefs.DeleteKey("Achievement 2");
        PlayerPrefs.DeleteKey("Achievement 3");
        PlayerPrefs.DeleteKey("Achievement 4");
        PlayerPrefs.DeleteKey("Achievement 5");
        PlayerPrefs.DeleteKey("Achievement 6");

        PlayerPrefs.DeleteKey("S1 Map Floor");
        PlayerPrefs.DeleteKey("S2 Map Floor");
        PlayerPrefs.DeleteKey("S5 Map Floor");

        PlayerPrefs.DeleteKey("S1 Preview");
        PlayerPrefs.DeleteKey("S2 Preview");
        PlayerPrefs.DeleteKey("S3 Preview");
        PlayerPrefs.DeleteKey("S4 Preview");
        PlayerPrefs.DeleteKey("S5 Preview");

        PlayerPrefs.DeleteKey("Special Syrup Effect");
        PlayerPrefs.DeleteKey("Key Count");
        PlayerPrefs.DeleteKey("Character Position");
        PlayerPrefs.DeleteKey("Next Stage");
        PlayerPrefs.DeleteKey("Quarantine Time");
        PlayerPrefs.DeleteKey("Door Access");
        PlayerPrefs.DeleteKey("Camera Distance");

        PlayerPrefs.SetInt("Framerate", 0);
        PlayerPrefs.SetInt("Current Stage", 1);
		PlayerPrefs.SetInt("Current Immunity", 0);
        PlayerPrefs.SetInt("Life", 3);
        PlayerPrefs.SetInt("Quarantine", 0);
        PlayerPrefs.SetInt("Continue Game", 0);
        // PlayerPrefs.SetInt("Coin", 0);
        */

        doneNewGamePrefs = 1;
    }

    public static void GameIsFinished()
    {
        PlayerPrefs.SetInt("Continue Game", 0);
        PlayerPrefs.DeleteKey("Current Stage");
    }

    public static void GetPremiumSkin()
    {
        premiumSkinA = PlayerPrefs.GetInt("Premium Skin 1", 0);
        premiumSkinB = PlayerPrefs.GetInt("Premium Skin 2", 0);
        premiumSkinC = PlayerPrefs.GetInt("Premium Skin 3", 0);
        premiumSkinD = PlayerPrefs.GetInt("Premium Skin 4", 0);
    }

    public static void SetPremiumSkin(int count, int num)
    {
        PlayerPrefs.SetInt("Premium Skin " + count, num);
    }

    public static void SetNextStage()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>SaveManager</color> - Next Stage: 1");
#endif
        nextStage = 1;
    }

    public static void SetNextStageFinish()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>SaveManager</color> - Next Stage: 0");
#endif
        nextStage = 0;
    }

    public static void SetStagePreview(int num)
    {
        PlayerPrefs.SetInt("S" + num + " Preview", 1);
    }

    public static void GetStagePreview(int num)
    {
        stagePreview = PlayerPrefs.GetInt("S" + num + " Preview", 0);
    }

    public static void GetStagePreviewPlayfab()
    {
        stage1Preview = PlayerPrefs.GetInt("S1 Preview", 0);
        stage2Preview = PlayerPrefs.GetInt("S2 Preview", 0);
        stage3Preview = PlayerPrefs.GetInt("S3 Preview", 0);
        stage4Preview = PlayerPrefs.GetInt("S4 Preview", 0);
        stage5Preview = PlayerPrefs.GetInt("S5 Preview", 0);
    }

    public static void SetRememberAccount(int num)
    {
        PlayerPrefs.SetInt("Auto Login", num);
    }

    public static void GetRememberAccount()
    {
        rememberAccount = PlayerPrefs.GetInt("Auto Login", 0);
    }

    public static void SetMap(int mapnum, int floor)
    {
        PlayerPrefs.SetInt("S" + mapnum + " Map Floor", floor);
    }

    public static void GetMap(int mapnum)
    {
        mapFloor = PlayerPrefs.GetInt("S" + mapnum + " Map Floor", 0);
    }

    public static void SaveGame(int stageNum, float charHP, int charInf)
    {
        GameObject character = GameObject.FindWithTag("Player");
        PlayerPrefsExtra.SetVector3("S" + stageNum + " Character Position", character.transform.position);
        PlayerPrefs.SetFloat("Character Health", charHP);
        PlayerPrefs.SetInt("Character Infected", charInf);
        PlayerPrefs.SetInt("Continue Game", 1);
    }

    public static void ResetSaveGame(int stagenum)
    {
        PlayerPrefs.DeleteKey("S" + stagenum + " Character Position");
        PlayerPrefs.DeleteKey("Character Health");
        PlayerPrefs.DeleteKey("Character Infected");
    }

    public static void SetCharacterHealth(float healthpoint)
    {
        PlayerPrefs.SetFloat("Character Health", healthpoint);
    }

    public static void GetCharacterHealth()
    {
        characterHP = PlayerPrefs.GetFloat("Character Health", 100);
    }

    public static void SetCharacterInfection(int isInfected)
    {
        PlayerPrefs.SetInt("Character Infected", isInfected);
    }

    public static void GetCharacterInfection()
    {
        isCharacterInfected = PlayerPrefs.GetInt("Character Infected", 0);
    }


    public static void SetContinueGame(int num)
    {
        PlayerPrefs.SetInt("Continue Game", num);
    }

    public static void GetContinueGame()
    {
        continueGame = PlayerPrefs.GetInt("Continue Game", 0);
    }

    public static void SetGraphicsQuality(int num)
    {
        PlayerPrefs.SetInt("Graphics Quality", num);
    }

    public static void GetGraphicsQuality()
    {
        graphicsQuality = PlayerPrefs.GetInt("Graphics Quality", 1);
    }

    public static void SetLightAnimation(int num)
    {
        PlayerPrefs.SetInt("Light Animation", num);
    }

    public static void GetLightAnimation()
    {
        lightAnimation = PlayerPrefs.GetInt("Light Animation", 0);
    }



    #region Replay Stage Save Methods

    public static int replayStage;
    public static int replayKeyCount;
    public static int replayCurrentImmunity;
    public static int replayCurrentLife;
    public static int replayKeyName;

    public static int replayS1keyA;
    public static int replayS1keyB;
    public static int replayS1keyC;
    public static int replayS1keyD;
    public static int replayS1keyE;
    public static int replayS1keyF;

    public static int replayS2keyA;
    public static int replayS2keyB;
    public static int replayS2keyC;
    public static int replayS2keyD;
    public static int replayS2keyE;
    public static int replayS2keyF;

    public static int replayS5keyA;
    public static int replayS5keyB;
    public static int replayS5keyC;
    public static int replayS5keyD;
    public static int replayS5keyE;
    public static int replayS5keyF;

    public static int replayMainItemA;
    public static int replayMainItemB;
    public static int replayMainItemC;
    public static int replayMainItemD;
    public static int replayMainItemE;

    public static int replaySyrupA;
    public static int replaySyrupB;
    public static int replaySyrupC;
    public static int replaySyrupD;
    public static int replaySyrupE;


    public static void SetReplayStage()
    {
        PlayerPrefs.SetInt("Replay Stage", 1);
    }

    public static void GetReplayStage()
    {
        replayStage = PlayerPrefs.GetInt("Replay Stage", 0);
    }

    public static void SetReplayKeyCount()
    {
        replayKeyCount = PlayerPrefs.GetInt("Replay Key Count") + 1;
        PlayerPrefs.SetInt("Replay Key Count", replayKeyCount);
    }

    public static void GetReplayKeyCount()
    {
        replayKeyCount = PlayerPrefs.GetInt("Replay Key Count", 0);
    }

    public static void SetReplayKeyName(string keyName, int num)
    {
        PlayerPrefs.SetInt("Replay " + keyName, num);
    }

    public static void SetReplayMainItem(int stageNum)
    {
        PlayerPrefs.SetInt("Replay S" + stageNum + " Main Item", 1);
    }

    public static void SetReplayCurrrentImmunity(int immunity)
    {
        PlayerPrefs.SetInt("Replay Current Immunity", immunity);
    }

    public static void GetReplayCurrentImmunity()
    {
        replayCurrentImmunity = PlayerPrefs.GetInt("Replay Current Immunity", 0);
    }

    public static void GetReplayKeyName(string prefName)
    {
        replayKeyName = PlayerPrefs.GetInt("Replay " + prefName, 0);
    }

    public static void SetReplaySpecialSyrup(string syrupName, int syrupCount)
    {
        PlayerPrefs.SetInt("Replay " + syrupName, syrupCount);
    }
    public static void SetReplayCurrentLife(int num)
    {
        PlayerPrefs.SetInt("Replay Life", num);
    }

    public static void GetReplayCurrentLife()
    {
        replayCurrentLife = PlayerPrefs.GetInt("Replay Life", 3);
        if (replayCurrentLife > 3) replayCurrentLife = 3; // Anti-Cheat
    }

    public static void GetReplaySpecialSyrup()
    {
        // 1 = Unused, 2 = Used, 3 = Lock In Quarantine Area
        replaySyrupA = PlayerPrefs.GetInt("Replay S1 Special Syrup", 0);
        replaySyrupB = PlayerPrefs.GetInt("Replay S2 Special Syrup", 0);
        replaySyrupC = PlayerPrefs.GetInt("Replay S3 Special Syrup", 0);
        replaySyrupD = PlayerPrefs.GetInt("Replay S4 Special Syrup", 0);
        replaySyrupE = PlayerPrefs.GetInt("Replay S5 Special Syrup", 0);
    }

    public static void GetReplayS1Keys()
    {
        replayS1keyA = PlayerPrefs.GetInt("Replay S1 Key A", 0);
        replayS1keyB = PlayerPrefs.GetInt("Replay S1 Key B", 0);
        replayS1keyC = PlayerPrefs.GetInt("Replay S1 Key C", 0);
        replayS1keyD = PlayerPrefs.GetInt("Replay S1 Key D", 0);
        replayS1keyE = PlayerPrefs.GetInt("Replay S1 Key E", 0);
        replayS1keyF = PlayerPrefs.GetInt("Replay S1 Key F", 0);
    }
    public static void GetReplayS2Keys()
    {
        replayS2keyA = PlayerPrefs.GetInt("Replay S2 Key A", 0);
        replayS2keyB = PlayerPrefs.GetInt("Replay S2 Key B", 0);
        replayS2keyC = PlayerPrefs.GetInt("Replay S2 Key C", 0);
        replayS2keyD = PlayerPrefs.GetInt("Replay S2 Key D", 0);
        replayS2keyE = PlayerPrefs.GetInt("Replay S2 Key E", 0);
        replayS2keyF = PlayerPrefs.GetInt("Replay S2 Key F", 0);
    }

    public static void GetReplayS5Keys()
    {
        replayS5keyA = PlayerPrefs.GetInt("Replay S5 Key A", 0);
        replayS5keyB = PlayerPrefs.GetInt("Replay S5 Key B", 0);
        replayS5keyC = PlayerPrefs.GetInt("Replay S5 Key C", 0);
        replayS5keyD = PlayerPrefs.GetInt("Replay S5 Key D", 0);
        replayS5keyE = PlayerPrefs.GetInt("Replay S5 Key E", 0);
        replayS5keyF = PlayerPrefs.GetInt("Replay S5 Key F", 0);
    }

    public static void GetReplayMainItem()
    {
        replayMainItemA = PlayerPrefs.GetInt("Replay S1 Main Item", 0);
        replayMainItemB = PlayerPrefs.GetInt("Replay S2 Main Item", 0);
        replayMainItemC = PlayerPrefs.GetInt("Replay S3 Main Item", 0);
        replayMainItemD = PlayerPrefs.GetInt("Replay S4 Main Item", 0);
        replayMainItemE = PlayerPrefs.GetInt("Replay S5 Main Item", 0);
    }

    public static void DeleteReplayStage()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>SaveManager</color> - Deleting Replay Stage PlayerPrefs");
#endif
        PlayerPrefs.DeleteKey("Replay Stage");
        PlayerPrefs.DeleteKey("Replay Current Immunity");
        PlayerPrefs.DeleteKey("Replay Life");
        PlayerPrefs.DeleteKey("Replay Key Count");
        PlayerPrefs.DeleteKey("Replay S1 Key A");
        PlayerPrefs.DeleteKey("Replay S1 Key B");
        PlayerPrefs.DeleteKey("Replay S1 Key C");
        PlayerPrefs.DeleteKey("Replay S1 Key D");
        PlayerPrefs.DeleteKey("Replay S1 Key E");
        PlayerPrefs.DeleteKey("Replay S1 Key F");
        PlayerPrefs.DeleteKey("Replay S2 Key A");
        PlayerPrefs.DeleteKey("Replay S2 Key B");
        PlayerPrefs.DeleteKey("Replay S2 Key C");
        PlayerPrefs.DeleteKey("Replay S2 Key D");
        PlayerPrefs.DeleteKey("Replay S2 Key E");
        PlayerPrefs.DeleteKey("Replay S2 Key F");
        PlayerPrefs.DeleteKey("Replay S5 Key A");
        PlayerPrefs.DeleteKey("Replay S5 Key B");
        PlayerPrefs.DeleteKey("Replay S5 Key C");
        PlayerPrefs.DeleteKey("Replay S5 Key D");
        PlayerPrefs.DeleteKey("Replay S5 Key E");
        PlayerPrefs.DeleteKey("Replay S5 Key F");
        PlayerPrefs.DeleteKey("Replay S1 Main Item");
        PlayerPrefs.DeleteKey("Replay S2 Main Item");
        PlayerPrefs.DeleteKey("Replay S3 Main Item");
        PlayerPrefs.DeleteKey("Replay S4 Main Item");
        PlayerPrefs.DeleteKey("Replay S5 Main Item");
        PlayerPrefs.DeleteKey("Replay S1 Special Syrup");
        PlayerPrefs.DeleteKey("Replay S2 Special Syrup");
        PlayerPrefs.DeleteKey("Replay S3 Special Syrup");
        PlayerPrefs.DeleteKey("Replay S4 Special Syrup");
        PlayerPrefs.DeleteKey("Replay S5 Special Syrup");
        PlayerPrefs.DeleteKey("Door Access");
        PlayerPrefs.DeleteKey("Door Name");
    }

    #endregion
}
