using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LockDawnData
{
    public string continueGame;
    public string gameDifficulty;
    public string graphicsQuality;
    public string lightAnimation;
    public string frameRate;
    public string musicVolume;
    public string soundVolume;
    public string soundMute;
    public string musicMute;
    public string cameraDistance;
    public string lookSensitivity;
    public string isQuarantine;
    public string quarantineTime;
    public string premiumSkin1;
    public string premiumSkin2;
    public string premiumSkin3;
    public string premiumSkin4;
    public string specialSyrup1;
    public string specialSyrup2;
    public string specialSyrup3;
    public string specialSyrup4;
    public string specialSyrup5;
    public string showSpecialSyrupEffect;
    public string mainItem1;
    public string mainItem2;
    public string mainItem3;
    public string mainItem4;
    public string mainItem5;
    public string stage1KeyA;
    public string stage1KeyB;
    public string stage1KeyC;
    public string stage1KeyD;
    public string stage1KeyE;
    public string stage1KeyF;
    public string stage2KeyA;
    public string stage2KeyB;
    public string stage2KeyC;
    public string stage2KeyD;
    public string stage2KeyE;
    public string stage2KeyF;
    public string stage5KeyA;
    public string stage5KeyB;
    public string stage5KeyC;
    public string stage5KeyD;
    public string stage5KeyE;
    public string stage5KeyF;
    public string keyCount;
    public string achievement1;
    public string achievement2;
    public string achievement3;
    public string achievement4;
    public string achievement5;
    public string achievement6;
    public string achievement7;
    public string playerViolation;
    public string riddle1;
    public string riddle2;
    public string riddle3;
    public string riddle4;
    public string riddle5;
    public string stage1Preview;
    public string stage2Preview;
    public string stage3Preview;
    public string stage4Preview;
    public string stage5Preview;
    public string stage1Completed;
    public string stage2Completed;
    public string stage3Completed;
    public string stage4Completed;
    public string stage5Completed;
    public string isInfected;
    public string currentHealthPoint;
    public string currentStage;
    public string currentCharacter;
    public string currentImmunity;
    public string currentLife;
    public string coin;


    public LockDawnData(
        string continuegame,
        string gamedifficulty,
        string graphicsquality,
        string lightanimation,
        string framerate,
        string musicvolume,
        string soundvolume,
        string soundmute,
        string musicmute,
        string cameradistance,
        string looksensitivity,
        string isquarantine,
        string quarantinetime,
        string premiumskin1,
        string premiumskin2,
        string premiumskin3,
        string premiumskin4,
        string syrup1,
        string syrup2,
        string syrup3,
        string syrup4,
        string syrup5,
        string showsyrupeffect,
        string mainitem1,
        string mainitem2,
        string mainitem3,
        string mainitem4,
        string mainitem5,
        string s1keya,
        string s1keyb,
        string s1keyc,
        string s1keyd,
        string s1keye,
        string s1keyf,
        string s2keya,
        string s2keyb,
        string s2keyc,
        string s2keyd,
        string s2keye,
        string s2keyf,
        string s5keya,
        string s5keyb,
        string s5keyc,
        string s5keyd,
        string s5keye,
        string s5keyf,
        string keycount,
        string achievement1,
        string achievement2,
        string achievement3,
        string achievement4,
        string achievement5,
        string achievement6,
        string achievement7,
        string playerviolation,
        string riddle1,
        string riddle2,
        string riddle3,
        string riddle4,
        string riddle5,
        string stage1preview,
        string stage2preview,
        string stage3preview,
        string stage4preview,
        string stage5preview,
        string stage1completed,
        string stage2completed,
        string stage3completed,
        string stage4completed,
        string stage5completed,
        string isinfected,
        string currenthp,
        string currentstage,
        string currentcharacter,
        string currentimmunity,
        string currentlife,
        string coin)
    {
        this.continueGame = continuegame;
        this.gameDifficulty = gamedifficulty;
        this.graphicsQuality = graphicsquality;
        this.lightAnimation = lightanimation;
        this.frameRate = framerate;
        this.musicVolume = musicvolume;
        this.soundVolume = soundvolume;
        this.soundMute = soundmute;
        this.musicMute = musicmute;
        this.cameraDistance = cameradistance;
        this.lookSensitivity = looksensitivity;
        this.isQuarantine = isquarantine;
        this.quarantineTime = quarantinetime;
        this.premiumSkin1 = premiumskin1;
        this.premiumSkin2 = premiumskin2;
        this.premiumSkin3 = premiumskin3;
        this.premiumSkin4 = premiumskin4;
        this.specialSyrup1 = syrup1;
        this.specialSyrup2 = syrup2;
        this.specialSyrup3 = syrup3;
        this.specialSyrup4 = syrup4;
        this.specialSyrup5 = syrup5;
        this.showSpecialSyrupEffect = showsyrupeffect;
        this.mainItem1 = mainitem1;
        this.mainItem2 = mainitem2;
        this.mainItem3 = mainitem3;
        this.mainItem4 = mainitem4;
        this.mainItem5 = mainitem5;
        this.stage1KeyA = s1keya;
        this.stage1KeyB = s1keyb;
        this.stage1KeyC = s1keyc;
        this.stage1KeyD = s1keyd;
        this.stage1KeyE = s1keye;
        this.stage1KeyF = s1keyf;
        this.stage2KeyA = s2keya;
        this.stage2KeyB = s2keyb;
        this.stage2KeyC = s2keyc;
        this.stage2KeyD = s2keyd;
        this.stage2KeyE = s2keye;
        this.stage2KeyF = s2keyf;
        this.stage5KeyA = s5keya;
        this.stage5KeyB = s5keyb;
        this.stage5KeyC = s5keyc;
        this.stage5KeyD = s5keyd;
        this.stage5KeyE = s5keye;
        this.stage5KeyF = s5keyf;
        this.keyCount = keycount;
        this.achievement1 = achievement1;
        this.achievement2 = achievement2;
        this.achievement3 = achievement3;
        this.achievement4 = achievement4;
        this.achievement5 = achievement5;
        this.achievement6 = achievement6;
        this.achievement7 = achievement7;
        this.playerViolation = playerviolation;
        this.riddle1 = riddle1;
        this.riddle2 = riddle2;
        this.riddle3 = riddle3;
        this.riddle4 = riddle4;
        this.riddle5 = riddle5;
        this.stage1Preview = stage1preview;
        this.stage2Preview = stage2preview;
        this.stage3Preview = stage3preview;
        this.stage4Preview = stage4preview;
        this.stage5Preview = stage5preview;
        this.stage1Completed = stage1completed;
        this.stage2Completed = stage2completed;
        this.stage3Completed = stage3completed;
        this.stage4Completed = stage4completed;
        this.stage5Completed = stage5completed;
        this.isInfected = isinfected;
        this.currentHealthPoint = currenthp;
        this.currentStage = currentstage;
        this.currentCharacter = currentcharacter;
        this.currentImmunity = currentimmunity;
        this.currentLife = currentlife;
        this.coin = coin;
    }
}

public class PlayFabJsonData : MonoBehaviour
{
    public LockDawnData ReturnClass()
    {
        SaveManager.GetContinueGame();
        SaveManager.GetGameDifficulty();
        SaveManager.GetGraphicsQuality();
        SaveManager.GetLightAnimation();
        SaveManager.GetShowFramerate();
        SaveManager.GetSoundMusicVolume();
        SaveManager.GetCameraDistance();
        SaveManager.GetLookSensitivity();
        SaveManager.GetQuarantine();
        SaveManager.GetQuarantineTime();
        SaveManager.GetPremiumSkin();
        SaveManager.GetSpecialSyrup();
        SaveManager.GetShowSyrupEffect();
        SaveManager.GetMainItem();
        SaveManager.GetS1Keys();
        SaveManager.GetS2Keys();
        SaveManager.GetS5Keys();
        SaveManager.GetKeyCount();
        SaveManager.GetAchievement();
        SaveManager.GetAchievementViolator();
        SaveManager.GetRiddle();
        SaveManager.GetStagePreviewPlayfab();
        SaveManager.GetCompleteStage();
        SaveManager.GetCharacterHealth();
        SaveManager.GetCharacterInfection();
        SaveManager.GetCurrentStage();
        SaveManager.GetCurrentCharacter();
        SaveManager.GetCurrentImmunity();
        SaveManager.GetCurrentLife();
        SaveManager.GetCoin();

        return new LockDawnData(
            SaveManager.continueGame.ToString(),
            SaveManager.gameDifficulty.ToString(),
            SaveManager.graphicsQuality.ToString(),
            SaveManager.lightAnimation.ToString(),
            SaveManager.framerateOn.ToString(),
            SaveManager.soundVolume.ToString(),
            SaveManager.musicVolume.ToString(),
            SaveManager.soundMute.ToString(),
            SaveManager.musicMute.ToString(),
            SaveManager.cameraDistance.ToString(),
            SaveManager.lookSensitivity.ToString(),
            SaveManager.isQuarantine.ToString(),
            SaveManager.quarantineTime.ToString(),
            SaveManager.premiumSkinA.ToString(),
            SaveManager.premiumSkinB.ToString(),
            SaveManager.premiumSkinC.ToString(),
            SaveManager.premiumSkinD.ToString(),
            SaveManager.syrupA.ToString(),
            SaveManager.syrupB.ToString(),
            SaveManager.syrupC.ToString(),
            SaveManager.syrupD.ToString(),
            SaveManager.syrupE.ToString(),
            SaveManager.showSyrupEffect.ToString(),
            SaveManager.mainItemA.ToString(),
            SaveManager.mainItemB.ToString(),
            SaveManager.mainItemC.ToString(),
            SaveManager.mainItemD.ToString(),
            SaveManager.mainItemE.ToString(),
            SaveManager.s1keyA.ToString(),
            SaveManager.s1keyB.ToString(),
            SaveManager.s1keyC.ToString(),
            SaveManager.s1keyD.ToString(),
            SaveManager.s1keyE.ToString(),
            SaveManager.s1keyF.ToString(),
            SaveManager.s2keyA.ToString(),
            SaveManager.s2keyB.ToString(),
            SaveManager.s2keyC.ToString(),
            SaveManager.s2keyD.ToString(),
            SaveManager.s2keyE.ToString(),
            SaveManager.s2keyF.ToString(),
            SaveManager.s5keyA.ToString(),
            SaveManager.s5keyB.ToString(),
            SaveManager.s5keyC.ToString(),
            SaveManager.s5keyD.ToString(),
            SaveManager.s5keyE.ToString(),
            SaveManager.s5keyF.ToString(),
            SaveManager.keyCount.ToString(),
            SaveManager.achievementA.ToString(),
            SaveManager.achievementB.ToString(),
            SaveManager.achievementC.ToString(),
            SaveManager.achievementD.ToString(),
            SaveManager.achievementE.ToString(),
            SaveManager.achievementF.ToString(),
            SaveManager.achievementG.ToString(),
            SaveManager.playerViolation.ToString(),
            SaveManager.riddleA.ToString(),
            SaveManager.riddleB.ToString(),
            SaveManager.riddleC.ToString(),
            SaveManager.riddleD.ToString(),
            SaveManager.riddleE.ToString(),
            SaveManager.stage1Preview.ToString(),
            SaveManager.stage2Preview.ToString(),
            SaveManager.stage3Preview.ToString(),
            SaveManager.stage4Preview.ToString(),
            SaveManager.stage5Preview.ToString(),
            SaveManager.stageACompleted.ToString(),
            SaveManager.stageBCompleted.ToString(),
            SaveManager.stageCCompleted.ToString(),
            SaveManager.stageDCompleted.ToString(),
            SaveManager.stageECompleted.ToString(),
            SaveManager.characterHP.ToString(),
            SaveManager.isCharacterInfected.ToString(),
            SaveManager.currentStage.ToString(),
            SaveManager.currentCharacter.ToString(),
            SaveManager.currentImmunity.ToString(),
            SaveManager.currentLife.ToString(),
            SaveManager.currentCoin.ToString()
        );
    }

    public void LoadDataToPrefs(LockDawnData lockdawndata)
    {
        SaveManager.SetContinueGame(int.Parse(lockdawndata.continueGame));
        SaveManager.SetGameDifficulty(int.Parse(lockdawndata.gameDifficulty));
        SaveManager.SetGraphicsQuality(int.Parse(lockdawndata.graphicsQuality));
        SaveManager.SetLightAnimation(int.Parse(lockdawndata.lightAnimation));
        SaveManager.SetShowFramerate(int.Parse(lockdawndata.frameRate));
        SaveManager.SetSoundVolume(int.Parse(lockdawndata.soundVolume));
        SaveManager.SetMusicVolume(int.Parse(lockdawndata.musicVolume));
        SaveManager.SetSoundMute(int.Parse(lockdawndata.soundMute));
        SaveManager.SetMusicMute(int.Parse(lockdawndata.musicMute));
        SaveManager.SetCameraDistance(float.Parse(lockdawndata.cameraDistance));
        SaveManager.SetLookSensitivity(float.Parse(lockdawndata.lookSensitivity));
        SaveManager.SetQuarantine(int.Parse(lockdawndata.isQuarantine));
        SaveManager.SetQuarantineTime(float.Parse(lockdawndata.quarantineTime));
        SaveManager.SetPremiumSkin(1, int.Parse(lockdawndata.premiumSkin1));
        SaveManager.SetPremiumSkin(2, int.Parse(lockdawndata.premiumSkin2));
        SaveManager.SetPremiumSkin(3, int.Parse(lockdawndata.premiumSkin3));
        SaveManager.SetPremiumSkin(4, int.Parse(lockdawndata.premiumSkin4));
        SaveManager.SetSpecialSyrupPlayFab(1, int.Parse(lockdawndata.specialSyrup1));
        SaveManager.SetSpecialSyrupPlayFab(2, int.Parse(lockdawndata.specialSyrup2));
        SaveManager.SetSpecialSyrupPlayFab(3, int.Parse(lockdawndata.specialSyrup3));
        SaveManager.SetSpecialSyrupPlayFab(4, int.Parse(lockdawndata.specialSyrup4));
        SaveManager.SetSpecialSyrupPlayFab(5, int.Parse(lockdawndata.specialSyrup5));
        SaveManager.SetShowSyrupEffect(int.Parse(lockdawndata.showSpecialSyrupEffect));
        SaveManager.SetMainItemPlayfab(1, int.Parse(lockdawndata.mainItem1));
        SaveManager.SetMainItemPlayfab(2, int.Parse(lockdawndata.mainItem2));
        SaveManager.SetMainItemPlayfab(3, int.Parse(lockdawndata.mainItem3));
        SaveManager.SetMainItemPlayfab(4, int.Parse(lockdawndata.mainItem4));
        SaveManager.SetMainItemPlayfab(5, int.Parse(lockdawndata.mainItem5));
        SaveManager.SetKeyNamePlayfab(1, "A", int.Parse(lockdawndata.stage1KeyA));
        SaveManager.SetKeyNamePlayfab(1, "B", int.Parse(lockdawndata.stage1KeyB));
        SaveManager.SetKeyNamePlayfab(1, "C", int.Parse(lockdawndata.stage1KeyC));
        SaveManager.SetKeyNamePlayfab(1, "D", int.Parse(lockdawndata.stage1KeyD));
        SaveManager.SetKeyNamePlayfab(1, "E", int.Parse(lockdawndata.stage1KeyE));
        SaveManager.SetKeyNamePlayfab(1, "F", int.Parse(lockdawndata.stage1KeyF));
        SaveManager.SetKeyNamePlayfab(2, "A", int.Parse(lockdawndata.stage2KeyA));
        SaveManager.SetKeyNamePlayfab(2, "B", int.Parse(lockdawndata.stage2KeyB));
        SaveManager.SetKeyNamePlayfab(2, "C", int.Parse(lockdawndata.stage2KeyC));
        SaveManager.SetKeyNamePlayfab(2, "D", int.Parse(lockdawndata.stage2KeyD));
        SaveManager.SetKeyNamePlayfab(2, "E", int.Parse(lockdawndata.stage2KeyE));
        SaveManager.SetKeyNamePlayfab(2, "F", int.Parse(lockdawndata.stage2KeyF));
        SaveManager.SetKeyNamePlayfab(5, "A", int.Parse(lockdawndata.stage5KeyA));
        SaveManager.SetKeyNamePlayfab(5, "B", int.Parse(lockdawndata.stage5KeyB));
        SaveManager.SetKeyNamePlayfab(5, "C", int.Parse(lockdawndata.stage5KeyC));
        SaveManager.SetKeyNamePlayfab(5, "D", int.Parse(lockdawndata.stage5KeyD));
        SaveManager.SetKeyNamePlayfab(5, "E", int.Parse(lockdawndata.stage5KeyE));
        SaveManager.SetKeyNamePlayfab(5, "F", int.Parse(lockdawndata.stage5KeyF));
        SaveManager.SetKeyCountPlayfab(int.Parse(lockdawndata.keyCount));
        SaveManager.SetAchievement(1, int.Parse(lockdawndata.achievement1));
        SaveManager.SetAchievement(2, int.Parse(lockdawndata.achievement2));
        SaveManager.SetAchievement(3, int.Parse(lockdawndata.achievement3));
        SaveManager.SetAchievement(4, int.Parse(lockdawndata.achievement4));
        SaveManager.SetAchievement(5, int.Parse(lockdawndata.achievement5));
        SaveManager.SetAchievement(6, int.Parse(lockdawndata.achievement6));
        SaveManager.SetAchievement(7, int.Parse(lockdawndata.achievement7));
        SaveManager.SetAchievementViolator(int.Parse(lockdawndata.playerViolation));
        SaveManager.SetRiddle(1, int.Parse(lockdawndata.riddle1));
        SaveManager.SetRiddle(2, int.Parse(lockdawndata.riddle2));
        SaveManager.SetRiddle(3, int.Parse(lockdawndata.riddle3));
        SaveManager.SetRiddle(4, int.Parse(lockdawndata.riddle4));
        SaveManager.SetRiddle(5, int.Parse(lockdawndata.riddle5));
        SaveManager.SetCompleteStagePlayfab(1, int.Parse(lockdawndata.stage1Completed));
        SaveManager.SetCompleteStagePlayfab(2, int.Parse(lockdawndata.stage2Completed));
        SaveManager.SetCompleteStagePlayfab(3, int.Parse(lockdawndata.stage3Completed));
        SaveManager.SetCompleteStagePlayfab(4, int.Parse(lockdawndata.stage4Completed));
        SaveManager.SetCompleteStagePlayfab(5, int.Parse(lockdawndata.stage5Completed));
        SaveManager.SetCharacterInfection(int.Parse(lockdawndata.isInfected));
        SaveManager.SetCharacterHealth(int.Parse(lockdawndata.currentHealthPoint));
        SaveManager.SetCurrentStage(int.Parse(lockdawndata.currentStage));
        SaveManager.SetCurrentCharacter(int.Parse(lockdawndata.currentCharacter));
        SaveManager.SetCurrrentImmunity(int.Parse(lockdawndata.currentImmunity));
        SaveManager.SetCurrentLife(int.Parse(lockdawndata.currentLife));
        SaveManager.SetCoinPlayfab(int.Parse(lockdawndata.coin));
    }
}
