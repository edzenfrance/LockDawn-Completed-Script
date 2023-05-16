using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

// https://learn.unity.com/tutorial/customizing-urp-asset-settings-2019-3#6000f83fedbc2a3cabece473

public class GraphicsQuality : MonoBehaviour
{
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] private Toggle toggleLow, toggleMedium, toggleHigh;
    [SerializeField] private RenderPipelineAsset[] qualityLevels;


    private void Awake()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void Start()
    {
        SaveManager.GetGraphicsQuality();
        if (SaveManager.graphicsQuality == 1) toggleLow.isOn = true;
        if (SaveManager.graphicsQuality == 2) toggleMedium.isOn = true;
        if (SaveManager.graphicsQuality == 3) toggleHigh.isOn = true;
    }

    public void GraphicsQualitySelect()
    {
        foreach (Toggle toggle in toggleGroup.ActiveToggles())
        {
            if (toggle.name == "Low")
            {
                SaveManager.SetGraphicsQuality(1);
                QualitySettings.SetQualityLevel(0);
                QualitySettings.renderPipeline = qualityLevels[0];
            }
            if (toggle.name == "Medium")
            {
                SaveManager.SetGraphicsQuality(2);
                QualitySettings.SetQualityLevel(1);
                QualitySettings.renderPipeline = qualityLevels[1];
            }
            if (toggle.name == "High")
            {
                SaveManager.SetGraphicsQuality(3);
                QualitySettings.SetQualityLevel(2);
                QualitySettings.renderPipeline = qualityLevels[2];
            }
        }
    }
}
