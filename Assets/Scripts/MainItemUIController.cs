using UnityEngine;

public class MainItemUIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup overlay;
    [SerializeField] private Transform overlayObject;
    [SerializeField] private ItemGet itemGet;

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
        overlay.LeanAlpha(0, 0.5f);
        overlayObject.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnBackComplete);
    }

    void OnBackComplete()
    {
        GamePaused = false;
        itemGet.ShowNoteAfteMrMainEffects();
        gameObject.SetActive(false);
    }

    public void MainItemVitaminURL()
    {
        Application.OpenURL("https://www.ifm.org/news-insights/boosting-immunity-functional-medicine-tips-prevention-immunity-boosting-covid-19-coronavirus-outbreak/");
    }

    public void MainItemSanitizerURL()
    {
        Application.OpenURL("https://www.indushealthplus.com/can-sanitizer-prevent-the-spread-of-coronavirus.html");
    }

    public void MainItemFacemaskURL()
    {
        Application.OpenURL("https://www.hopkinsmedicine.org/health/conditions-and-diseases/coronavirus/coronavirus-face-masks-what-you-need-to-know");
    }

    public void MainItemFaceshieldURL()
    {
        Application.OpenURL("https://doh.gov.ph/press-release/DOH-FACE-SHIELDS-PROVIDE-ADDED-LAYER-OF-PROTECTION-AGAINST-COVID-19");
    }

    public void MainItemVaccineURL()
    {
        Application.OpenURL("https://www.unicef.org/northmacedonia/what-you-need-know-about-covid-19-vaccine");
    }
}