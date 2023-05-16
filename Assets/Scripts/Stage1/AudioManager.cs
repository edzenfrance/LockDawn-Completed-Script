using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSource;
    public AudioSource sounds;
    public AudioSource soundsLoop;
    public AudioSource ambience;

    [Header("Sounds")]
    public AudioClip footstep;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorLockedKey;
    public AudioClip doorLockedNoKey;
    public AudioClip zombieAttack;
    public AudioClip heartBeat;
    public AudioClip dead;
    public AudioClip pickUpItem;
    public AudioClip pickUpKey;
    public AudioClip pickUpBottle;
    public AudioClip pickUpPaper;
    public AudioClip pickUpCoin;
    public AudioClip woodBreak;

    [Header("Stage Objective Voice Over")]
    public AudioClip objectiveVoiceA;
    public AudioClip objectiveVoiceB;
    public AudioClip objectiveVoiceC;
    public AudioClip objectiveVoiceD;
    public AudioClip objectiveVoiceE;
    public AudioClip quarantineStart;
    public AudioClip quarantineFinish;

    [Header("Main Item Voice Over")]
    public AudioClip informationVitamins;
    public AudioClip informationAlcohol;
    public AudioClip informationFaceMask;
    public AudioClip informationFaceShield;
    public AudioClip informationVaccine;
    public AudioClip informationSpecialSyrup;

    [Header("Stage Ambience")]
    public AudioClip ambienceA;
    public AudioClip ambienceB;
    public AudioClip ambienceC;
    public AudioClip ambienceD;
    public AudioClip ambienceE;
    public AudioClip ambienceF;

    void Awake()
    {
        audioSource = GetComponents<AudioSource>();
        sounds = audioSource[0];
        soundsLoop = audioSource[1];
        ambience = audioSource[2];

        SaveManager.GetSoundMusicVolume();

        if (SaveManager.musicMute == 1)
            ambience.mute = true;
        if (SaveManager.soundMute == 1)
        {
            soundsLoop.mute = true;
            sounds.mute = true;
        }

        sounds.volume = SaveManager.soundVolume;
        soundsLoop.volume = SaveManager.soundVolume;
        ambience.volume = SaveManager.musicVolume;
    }

    public void PlayAudioVoiceOverA()
    {
        PlayVoiceOver(informationVitamins);
    }

    public void PlayAudioVoiceOverB()
    {
        PlayVoiceOver(informationAlcohol);
    }

    public void PlayAudioVoiceOverC()
    {
        PlayVoiceOver(informationFaceMask);
    }
    public void PlayAudioVoiceOverD()
    {
        PlayVoiceOver(informationFaceShield);
    }
    public void PlayAudioVoiceOverE()
    {
        PlayVoiceOver(informationVaccine);
    }

    public void PlayAudioVoiceOverF()
    {
        sounds.Stop();
        PlayVoiceOver(informationSpecialSyrup);
    }

    public void PlayAmbienceA()
    {
        PlayAmbience(ambienceA);
    }

    public void PlayAmbienceB()
    {
        PlayAmbience(ambienceB);
    }

    public void PlayAmbienceC()
    {
        PlayAmbience(ambienceC);
    }

    public void PlayAmbienceD()
    {
        PlayAmbience(ambienceD);
    }

    public void PlayAmbienceE()
    {
        PlayAmbience(ambienceE);
    }

    public void PlayAmbienceF()
    {
        PlayAmbience(ambienceF);
    }

    public void PlayAudioFootstep()
    {
        PlayOneShot(footstep);
    }

    public void PlayAudioDoorOpen()
    {
        PlaySounds(doorOpen);
    }

    public void PlayAudioDoorClose()
    {
        PlaySounds(doorClose);
    }

    public void PlayAudioDoorLockedKey()
    {
        PlaySounds(doorLockedKey);
    }

    public void PlayAudioDoorLockedNoKey()
    {
        PlaySounds(doorLockedNoKey);
    }

    public void PlayAudioZombieAttack()
    {
        PlaySounds(zombieAttack);
    }

    public void PlayAudioHeartBeat()
    {
        PlaySoundsLoop(heartBeat);
    }

    public void PlaySoundsLoop(AudioClip aClip)
    {
        soundsLoop.loop = true;
        soundsLoop.clip = aClip;
        soundsLoop.Play();
    }

    public void PlayAudioDeadCharacter()
    {
        PlaySoundsLoopX(dead);
    }

    public void PlaySoundsLoopX(AudioClip aClip)
    {
        soundsLoop.clip = null;
        soundsLoop.loop = true;
        soundsLoop.clip = aClip;
        soundsLoop.Play();
    }

    public void PlayAudioObjectiveA()
    {
        PlaySounds(objectiveVoiceA);
    }

    public void PlayAudioObjectiveB()
    {
        PlaySounds(objectiveVoiceB);
    }

    public void PlayAudioObjectiveC()
    {
        PlaySounds(objectiveVoiceC);
    }

    public void PlayAudioObjectiveD()
    {
        PlaySounds(objectiveVoiceD);
    }

    public void PlayAudioObjectiveE()
    {
        PlaySounds(objectiveVoiceE);
    }

    public void PlayAudioQuarantineVoiceStart()
    {
        PlaySounds(quarantineStart);
    }

    public void PlayAudioQuarantineVoiceFinish()
    {
        PlaySounds(quarantineFinish);
    }

    public void PlayAudioPickUpItem()
    {
        PlaySounds(pickUpItem);
    }

    public void PlayAudioPickUpKey()
    {
        PlaySounds(pickUpKey);
    }

    public void PlayAudioPickUpBottle()
    {
        PlaySounds(pickUpBottle);
    }

    public void PlayAudioPickUpPaper()
    {
        PlaySounds(pickUpPaper);
    }

    public void PlayAudioPickUpCoin()
    {
        PlaySounds(pickUpCoin);
    }

    public void PlayAudioWoodBreak()
    {
        PlaySounds(woodBreak);
    }

    public void PlayVoiceOver(AudioClip aClip)
    {
        if (!sounds.isPlaying)
        {
            sounds.clip = aClip;
            sounds.Play();
        }
        else
        {
            sounds.Pause();
        }
    }

    public void Psounds(AudioClip aClip)
    {
        sounds.clip = aClip;
        sounds.Play();
    }

    public void PlaySounds(AudioClip aClip)
    {
        sounds.clip = aClip;
        sounds.Play();
    }

    public void PlayAmbience(AudioClip aClip)
    {
        ambience.clip = aClip;
        ambience.Play();
    }

    public void StopAmbience()
    {
        ambience.Stop();
    }

    public void PlayOneShot(AudioClip aClip)
    {
        sounds.PlayOneShot(aClip);
    }

    public void StopAudioLoop()
    {
        soundsLoop.Stop();
    }

    public void PauseAudio()
    {
        sounds.Pause();
    }

    public void UnpauseAudio()
    {
        sounds.UnPause();
    }

    public void PlayAudio()
    {
        sounds.Play();
    }

    public void StopAudio()
    {
        sounds.Stop();
    }
}
