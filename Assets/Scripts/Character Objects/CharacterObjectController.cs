using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObjectController : MonoBehaviour
{
    [SerializeField] private GameObject faceMaskObject;
    [SerializeField] private GameObject faceShieldObject;
    [SerializeField] private GameObject particleStar;

    void Start()
    {
        SaveManager.GetReplayStage();
        SaveManager.GetReplayMainItem();
        // Load Character Objects
        faceMaskObject = GameObject.FindGameObjectWithTag("FaceMask");
        faceShieldObject = GameObject.FindGameObjectWithTag("FaceShield");
        particleStar = GameObject.FindGameObjectWithTag("ParticleStar");

        if (faceMaskObject != null)
        {
            if (SaveManager.replayStage == 1)
                if (SaveManager.replayMainItemC == 1)
                    faceMaskObject.SetActive(true);
            if (SaveManager.mainItemC == 1)
                faceMaskObject.SetActive(true);
            else
                faceMaskObject.SetActive(false);
        }

        if (faceShieldObject != null)
        {
            if (SaveManager.replayStage == 1)
                if (SaveManager.replayMainItemC == 1)
                    faceMaskObject.SetActive(true);
            if (SaveManager.mainItemD == 1)
                faceShieldObject.SetActive(true);
            else
                faceShieldObject.SetActive(false);
        }

        if (particleStar != null)
            particleStar.SetActive(false);

    }

    public void EnableFaceMask()
    {
        if (faceMaskObject != null)
            faceMaskObject.SetActive(true);
    }

    public void EnableFaceShield()
    {
        if (faceShieldObject != null)
            faceShieldObject.SetActive(true);
    }

    public void EnableParticleStar()
    {
        if (particleStar != null)
        {
            particleStar.SetActive(true);
            StartCoroutine(DisableParticleStar());
        }
    }

    IEnumerator DisableParticleStar()
    {
        yield return new WaitForSeconds(3f);
        if (particleStar != null)
            particleStar.SetActive(false);
    }

}
