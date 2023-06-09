using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyrupEffectUIController : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CanvasGroup overlay;
    [SerializeField] private Transform overlayObject;

    bool GamePaused = false;

    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void OnEnable()
    {
        overlay.alpha = 0;
        overlay.LeanAlpha(1, 0.5f);
        overlayObject.localPosition = new Vector2(0, -Screen.height);
        overlayObject.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().setOnComplete(OnEnableComplete).delay = 0f; // .delay = 0.1f
    }

    void OnEnableComplete()
    {
        GamePaused = true;
    }

    public void OnBack()
    {
        GamePaused = false;
        audioManager.StopAudio();
        overlay.LeanAlpha(0, 0.5f);
        overlayObject.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnBackComplete);
    }

    void OnBackComplete()
    {
        GamePaused = false;
        gameObject.SetActive(false);
    }
}
