using UnityEngine;

public class AudioManagerCollectors : MonoBehaviour
{
    public AudioSource voiceOver;

    public AudioSource BGM;
    public GameObject BGMObject;


    [Header("Voice Over")]
    public AudioClip informationAlcohol;
    public AudioClip informationVitamins;
    public AudioClip informationFaceMask;
    public AudioClip informationFaceShield;
    public AudioClip informationVaccine;


    void Awake()
    {
        BGMObject = GameObject.FindGameObjectWithTag("MainMenuBGM");
        if (BGMObject != null)
            BGM = BGMObject.GetComponent<AudioSource>();
    }

    public void PlayVoiceOverA()
    {
        PlayVoiceOver(informationAlcohol);
    }

    public void PlayVoiceOverB()
    {
        PlayVoiceOver(informationVitamins);
    }

    public void PlayVoiceOverC()
    {
        PlayVoiceOver(informationFaceMask);
    }
    public void PlayVoiceOverD()
    {
        PlayVoiceOver(informationFaceShield);
    }
    public void PlayVoiceOverE()
    {
        PlayVoiceOver(informationVaccine);
    }


    public void PlayVoiceOver(AudioClip aClip)
    {
        if (!voiceOver.isPlaying)
        {
            if (BGM != null) BGM.mute = true;
            voiceOver.clip = aClip;
            voiceOver.Play();
        }
        else
        {
            if (BGM != null) BGM.mute = false;
            voiceOver.Pause();
        }
    }

    public void PauseAudio()
    {
        voiceOver.Pause();
    }

    public void UnpauseAudio()
    {
        voiceOver.UnPause();
    }

    public void PlayAudio()
    {
        voiceOver.Play();
    }

    public void StopAudio()
    {
        voiceOver.Stop();
    }
}
