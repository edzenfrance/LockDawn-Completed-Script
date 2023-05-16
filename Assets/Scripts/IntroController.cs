using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class IntroController : MonoBehaviour
{
    public AudioSource introVoiceOver;
    public GameObject skipButton;
    public GameObject introImageObj;
    public Image introImage;
    public GameObject[] introTexts;
    public Sprite[] introSprites;

    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private TextMeshProUGUI loadingUIText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressText;

    int currentTextNum;


    void Start()
    {
        //introVoiceOver.time = 64.70f;
        GameObject objMusic = GameObject.FindGameObjectWithTag("MainMenuBGM");
        GameObject objSound = GameObject.FindGameObjectWithTag("SFXManager");
        if (objMusic != null)
            Destroy(objMusic);
        if (objSound != null)
            Destroy(objSound);

        introVoiceOver.Play();
        StartCoroutine(showIntro());
    }

    IEnumerator showIntro()
    {
        introTexts[0].SetActive(true);
        introImage.sprite = introSprites[0];
        yield return new WaitForSecondsRealtime(8f);

        ProcessTextImage(1, 1);
        yield return new WaitForSecondsRealtime(5f);

        ProcessTextImage(2, 2);
        yield return new WaitForSecondsRealtime(1.5f);

        introImage.sprite = introSprites[3];
        yield return new WaitForSecondsRealtime(2.5f);

        introImage.sprite = introSprites[4];
        yield return new WaitForSecondsRealtime(4.5f);  // and the virus has been dubbed COVID-19 by the World Health Organization.

        ProcessTextImage(3, 5);
        yield return new WaitForSecondsRealtime(2.5f);  // An unexpected threat to all humanity,

        introImage.sprite = introSprites[6];
        yield return new WaitForSecondsRealtime(2f);    // people started to panic as the number of dead rises.

        introImage.sprite = introSprites[7];
        yield return new WaitForSecondsRealtime(1.8f);  // people started to panic as the number of dead rises.

        ProcessTextImage(4, 8);
        yield return new WaitForSecondsRealtime(5f);    // Other organizations started to fall and they thought it was the end of everything.

        ProcessTextImage(5, 9);
        yield return new WaitForSecondsRealtime(5f);    // Six months have passed, survivors abandoned the cities and lived underground.

        ProcessTextImage(6, 10);
        yield return new WaitForSecondsRealtime(9.5f);  // They managed to live by working together and making their own food, but they know they won't last long enough if this continues, not until the virus has a cure.

        ProcessTextImage(7, 11);
        yield return new WaitForSecondsRealtime(11f);   // They have to find a way to fix the situation,

        ProcessTextImage(8, 12);
        yield return new WaitForSecondsRealtime(3f);    // and she mentioned that there might..

        introImage.sprite = introSprites[13];
        yield return new WaitForSecondsRealtime(3.50f);

        ProcessTextImage(9, 14);
        yield return new WaitForSecondsRealtime(14f);   // that vaccine was made when the pandemic started ..

        ProcessTextImage(10, 15);
        yield return new WaitForSecondsRealtime(5.8f);  // Now they need someone to volunteer to go into the city and retrieve that vaccine.

        ProcessTextImage(11, 16);
        yield return new WaitForSecondsRealtime(6.50f);

        ProcessTextImage(12, 17);
        yield return new WaitForSecondsRealtime(7.50f);    // They have the experience to explore the city because Jack is a military personnel and Jill is a police officer.

        ProcessTextImage(13, 18);
        yield return new WaitForSecondsRealtime(6.80f);

        ProcessTextImage(14, 18);
        yield return new WaitForSecondsRealtime(9f);

        ProcessTextImage(15, 19);
        yield return new WaitForSecondsRealtime(9f);

        ProcessTextImage(16, 20);
        yield return new WaitForSecondsRealtime(12.50f);

        ProcessTextImage(17, 21);
        yield return new WaitForSecondsRealtime(19f);

        ProcessTextImage(18, 22);
        yield return new WaitForSecondsRealtime(6.50f);

        ProcessTextImage(19, 24);
        yield return new WaitForSecondsRealtime(9.50f);

        ProcessTextImage(20, 25);
        yield return new WaitForSecondsRealtime(7f);

        ProcessTextImage(21, 26);
        yield return new WaitForSecondsRealtime(10f);

        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
    }

    void ProcessTextImage(int textnum, int spritenum)
    {
        currentTextNum = textnum;
        textnum -= 1;
        introTexts[textnum].SetActive(false);
        textnum += 1;
        introTexts[textnum].SetActive(true);
        introImage.sprite = introSprites[spritenum];
    }

    public void SkipIntro()
    {
        introVoiceOver.Stop();
        introTexts[currentTextNum].SetActive(false);
        introImageObj.SetActive(false);
        skipButton.SetActive(false);
        loadingUI.SetActive(true);
        StartCoroutine(LoadAsynchronously("Stage1"));
    }

    IEnumerator LoadAsynchronously(string scenename)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
