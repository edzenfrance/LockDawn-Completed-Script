using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryView;
    [SerializeField] private GameObject objectives;
    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private GameObject useSyrupButton;
    [SerializeField] private HealthController healthController;
    [SerializeField] private CharacterObjectController charObjController;
    [SerializeField] private Sprite[] spriteList;
    [SerializeField] private Sprite[] spriteListSyrup;
    [SerializeField] private Sprite[] spriteListMainItem;
    [SerializeField] private GameObject[] buttonObject;

    int num;
    int iObj = 0;
    string syrupName;

    public void AccessInventory()
    {
#if UNITY_EDITOR
        Debug.Log(inventoryView.activeSelf ? "<color=white>Inventory</color> - Inventory is Active" : "<color=white>Inventory</color> - Inventory is Inactive");
#endif
        if (inventoryView.activeSelf == false)
        {
            ClearInventory();
            LoadItemImage();
            inventoryView.SetActive(true);
            objectives.SetActive(false);
        }
        else if (inventoryView.activeSelf == true)
        {
            inventoryView.SetActive(false);
            objectives.SetActive(true);
            inventoryText.text = "";
            useSyrupButton.SetActive(false);
        }
    }

    void ClearInventory()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>Inventory</color> - Clearing Inventory");
#endif
        inventoryText.text = "";
        useSyrupButton.SetActive(false);
        foreach (GameObject fObj in buttonObject)
        {
            fObj.GetComponent<Button>().image.sprite = null;
            fObj.SetActive(false);
        }
    }

    void LoadItemImage()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>Inventory</color> - Loading Item Images");
#endif
        SaveManager.GetCurrentStageScene();
        SaveManager.GetReplayStage();

        iObj = 0;
        if (SaveManager.replayStage == 1)
        {
            SaveManager.GetReplayMainItem();
            if (SaveManager.replayMainItemA == 1) LoadSpriteMainItem(0);
            if (SaveManager.replayMainItemB == 1) LoadSpriteMainItem(1);
            if (SaveManager.replayMainItemC == 1) LoadSpriteMainItem(2);
            if (SaveManager.replayMainItemD == 1) LoadSpriteMainItem(3);
            if (SaveManager.replayMainItemE == 1) LoadSpriteMainItem(4);

            if (SaveManager.currentStage == 1)
            {
                SaveManager.GetReplayS1Keys();
                if (SaveManager.replayS1keyA == 1) LoadSprite(1);
                if (SaveManager.replayS1keyB == 1) LoadSprite(2);
                if (SaveManager.replayS1keyC == 1) LoadSprite(3);
                if (SaveManager.replayS1keyD == 1) LoadSprite(4);
                if (SaveManager.replayS1keyE == 1) LoadSprite(5);
                if (SaveManager.replayS1keyF == 1) LoadSprite(6);

            }
            if (SaveManager.currentStage == 2)
            {
                SaveManager.GetReplayS2Keys();
                if (SaveManager.replayS2keyA == 1) LoadSprite(1);
                if (SaveManager.replayS2keyB == 1) LoadSprite(2);
                if (SaveManager.replayS2keyC == 1) LoadSprite(3);
                if (SaveManager.replayS2keyD == 1) LoadSprite(4);
                if (SaveManager.replayS2keyE == 1) LoadSprite(5);
                if (SaveManager.replayS2keyF == 1) LoadSprite(6);
            }
            if (SaveManager.currentStage == 5)
            {
                SaveManager.GetReplayS5Keys();
                if (SaveManager.replayS5keyA == 1) LoadSprite(1);
                if (SaveManager.replayS5keyB == 1) LoadSprite(2);
                if (SaveManager.replayS5keyC == 1) LoadSprite(3);
                if (SaveManager.replayS5keyD == 1) LoadSprite(4);
                if (SaveManager.replayS5keyE == 1) LoadSprite(5);
                if (SaveManager.replayS5keyF == 1) LoadSprite(6);
            }

            SaveManager.GetReplaySpecialSyrup();
            if (SaveManager.replaySyrupA == 1) LoadSpriteSyrup(0);
            if (SaveManager.replaySyrupB == 1) LoadSpriteSyrup(1);
            if (SaveManager.replaySyrupC == 1) LoadSpriteSyrup(2);
            if (SaveManager.replaySyrupD == 1) LoadSpriteSyrup(3);
            if (SaveManager.replaySyrupE == 1) LoadSpriteSyrup(4);
        }
        else
        {
            SaveManager.GetMainItem();
            if (SaveManager.mainItemA == 1) LoadSpriteMainItem(0);
            if (SaveManager.mainItemB == 1) LoadSpriteMainItem(1);
            if (SaveManager.mainItemC == 1) LoadSpriteMainItem(2);
            if (SaveManager.mainItemD == 1) LoadSpriteMainItem(3);
            if (SaveManager.mainItemE == 1) LoadSpriteMainItem(4);

            if (SaveManager.currentStage == 1)
            {
                SaveManager.GetS1Keys();
                if (SaveManager.s1keyA == 1) LoadSprite(1);
                if (SaveManager.s1keyB == 1) LoadSprite(2);
                if (SaveManager.s1keyC == 1) LoadSprite(3);
                if (SaveManager.s1keyD == 1) LoadSprite(4);
                if (SaveManager.s1keyE == 1) LoadSprite(5);
                if (SaveManager.s1keyF == 1) LoadSprite(6);

            }
            if (SaveManager.currentStage == 2)
            {
                SaveManager.GetS2Keys();
                if (SaveManager.s2keyA == 1) LoadSprite(1);
                if (SaveManager.s2keyB == 1) LoadSprite(2);
                if (SaveManager.s2keyC == 1) LoadSprite(3);
                if (SaveManager.s2keyD == 1) LoadSprite(4);
                if (SaveManager.s2keyE == 1) LoadSprite(5);
                if (SaveManager.s2keyF == 1) LoadSprite(6);
            }
            if (SaveManager.currentStage == 5)
            {
                SaveManager.GetS5Keys();
                if (SaveManager.s5keyA == 1) LoadSprite(1);
                if (SaveManager.s5keyB == 1) LoadSprite(2);
                if (SaveManager.s5keyC == 1) LoadSprite(3);
                if (SaveManager.s5keyD == 1) LoadSprite(4);
                if (SaveManager.s5keyE == 1) LoadSprite(5);
                if (SaveManager.s5keyF == 1) LoadSprite(6);
            }

            SaveManager.GetSpecialSyrup();
            if (SaveManager.syrupA == 1) LoadSpriteSyrup(0);
            if (SaveManager.syrupB == 1) LoadSpriteSyrup(1);
            if (SaveManager.syrupC == 1) LoadSpriteSyrup(2);
            if (SaveManager.syrupD == 1) LoadSpriteSyrup(3);
            if (SaveManager.syrupE == 1) LoadSpriteSyrup(4);
        }
        SaveManager.GetCoin();
        if (SaveManager.currentCoin >= 10) LoadSprite(0);
    }

    void LoadSpriteMainItem(int num)
    {
        buttonObject[iObj].SetActive(true);
        buttonObject[iObj].GetComponent<Button>().image.sprite = spriteListMainItem[num];
        iObj++;
    }

    void LoadSpriteSyrup(int num)
    {
        buttonObject[iObj].SetActive(true);
        buttonObject[iObj].GetComponent<Button>().image.sprite = spriteListSyrup[num];
        iObj++;
    }

    void LoadSprite(int num)
    {
        buttonObject[iObj].SetActive(true);
        buttonObject[iObj].GetComponent<Button>().image.sprite = spriteList[num];
        iObj++;
    }

    public void ReloadInventory()
    {
        ClearInventory();
        LoadItemImage();
    }

    public void GetInventoryText()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>Inventory</color> - Getting Inventory Texts");
#endif
        string name = EventSystem.current.currentSelectedGameObject.name;
        string getNum = name.Replace("InvButton", "");
        if (int.TryParse(getNum, out num))
        {
            LoadText();
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("<color=white>Inventory</color> - <color=red>ERROR!</color> Not a valid int");
#endif
        }

    }

    public void UseSpecialSyrup()
    {
        healthController.StopInfection();
        if (healthController.useSyrup == 1)
        {
            SaveManager.SetSpecialSyrup(syrupName, 0);
            PlayerPrefs.SetInt(syrupName, 2);
            ReloadInventory();
            charObjController.EnableParticleStar();
        }
    }

    void LoadText()
    {
#if UNITY_EDITOR
        Debug.Log("<color=white>Inventory</color> - Sprite Name [<color=green>" + num + "</color>]: " + buttonObject[num].GetComponent<Image>().sprite.name);
#endif
        string imageName = buttonObject[num].GetComponent<Image>().sprite.name;
        syrupName = imageName;
        inventoryText.text = "";
        useSyrupButton.SetActive(false);
        SaveManager.GetCurrentStageScene();

        if (imageName == "S1 Inventory Alcohol") inventoryText.text = TextManager.inventoryAlcohol;
        if (imageName == "S2 Inventory Vitamin") inventoryText.text = TextManager.inventoryVitamin;
        if (imageName == "S3 Inventory Face Mask") inventoryText.text = TextManager.inventoryFaceMask;
        if (imageName == "S4 Inventory Face Shield") inventoryText.text = TextManager.inventoryFaceShield;
        if (imageName == "S5 Inventory Vaccine") inventoryText.text = TextManager.inventoryVaccine;

        if (SaveManager.currentStage == 1)
        {
            if (imageName == "S1 Inventory Key A") inventoryText.text = TextManager.S1_Inventory_A;
            if (imageName == "S1 Inventory Key B") inventoryText.text = TextManager.S1_Inventory_B;
            if (imageName == "S1 Inventory Key C") inventoryText.text = TextManager.S1_Inventory_C;
            if (imageName == "S1 Inventory Key D") inventoryText.text = TextManager.S1_Inventory_D;
            if (imageName == "S1 Inventory Key E") inventoryText.text = TextManager.S1_Inventory_E;
            if (imageName == "S1 Inventory Key F") inventoryText.text = TextManager.S1_Inventory_F;

        }
        if (SaveManager.currentStage == 2)
        {
            if (imageName == "S1 Inventory Key A") inventoryText.text = TextManager.S2_Inventory_A;
            if (imageName == "S1 Inventory Key B") inventoryText.text = TextManager.S2_Inventory_B;
            if (imageName == "S1 Inventory Key C") inventoryText.text = TextManager.S2_Inventory_C;
            if (imageName == "S1 Inventory Key D") inventoryText.text = TextManager.S2_Inventory_D;
            if (imageName == "S1 Inventory Key E") inventoryText.text = TextManager.S2_Inventory_E;
            if (imageName == "S1 Inventory Key F") inventoryText.text = TextManager.S2_Inventory_F;

        }
        if (SaveManager.currentStage == 5)
        {
            if (imageName == "S1 Inventory Key A") inventoryText.text = TextManager.S5_Inventory_A;
            if (imageName == "S1 Inventory Key B") inventoryText.text = TextManager.S5_Inventory_B;
            if (imageName == "S1 Inventory Key C") inventoryText.text = TextManager.S5_Inventory_C;
            if (imageName == "S1 Inventory Key D") inventoryText.text = TextManager.S5_Inventory_D;
            if (imageName == "S1 Inventory Key E") inventoryText.text = TextManager.S5_Inventory_E;
            if (imageName == "S1 Inventory Key F") inventoryText.text = TextManager.S5_Inventory_F;
        }

        if (imageName == "S1 Special Syrup")
        {
            inventoryText.text = TextManager.inventorySyrup;
            useSyrupButton.SetActive(true);
        }
        if (imageName == "S2 Special Syrup")
        {
            inventoryText.text = TextManager.inventorySyrup;
            useSyrupButton.SetActive(true);
        }
        if (imageName == "S3 Special Syrup")
        {
            inventoryText.text = TextManager.inventorySyrup;
            useSyrupButton.SetActive(true);
        }
        if (imageName == "S4 Special Syrup")
        {
            inventoryText.text = TextManager.inventorySyrup;
            useSyrupButton.SetActive(true);
        }
        if (imageName == "S5 Special Syrup")
        {
            inventoryText.text = TextManager.inventorySyrup;
            useSyrupButton.SetActive(true);
        }
        if (imageName == "Inventory Coin")
        {
            int coinCount = PlayerPrefs.GetInt("Coin");
            inventoryText.text = "[" + coinCount + "] " + TextManager.inventoryCoin;
        }
    }
}
