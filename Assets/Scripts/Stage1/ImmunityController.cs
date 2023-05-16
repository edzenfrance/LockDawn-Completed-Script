using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ImmunityController : MonoBehaviour
{
    [SerializeField] private Slider immunityBar;
    [SerializeField] private GameObject immunityFill;
    [SerializeField] private TextMeshProUGUI immunityText;

    public void SetImmunity()
    {
        SaveManager.GetCurrentImmunity();
        immunityFill.SetActive(true);
        immunityBar.value = SaveManager.currentImmunity;
        immunityText.text = SaveManager.currentImmunity.ToString();
    }

    public void SetImmunityReplay()
    {
        SaveManager.GetReplayCurrentImmunity();
        immunityFill.SetActive(true);
        immunityBar.value = SaveManager.replayCurrentImmunity;
        immunityText.text = SaveManager.replayCurrentImmunity.ToString();
    }
}
