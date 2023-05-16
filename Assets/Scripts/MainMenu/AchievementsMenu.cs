using UnityEngine;
using TMPro;

public class AchievementsMenu : MonoBehaviour
{
    public TMP_FontAsset FontAssetA;
    public TMP_FontAsset FontAssetB;
    public GameObject[] textObjs;

    void Start()
    {
      //  tmpText.font = tmpAssetA;
    }

    public void ChangeFontTest()
    {
        textObjs = GameObject.FindGameObjectsWithTag("AchievementsText");
        foreach (GameObject TMPtextObj in textObjs)
        {
            TMPtextObj.GetComponent<TMP_Text>().font = FontAssetB;
            //button.interactable = false ;
        }
    }

    public void changeFont()
    {
       // tmpText.font = tmpAssetB;
    }
}
