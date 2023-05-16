using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterShop : MonoBehaviour
{
#if UNITY_EDITOR
    [Help("Instructions for adding new character\n\n"
    + "1. Add the new character to Hierarchy [TAB] > Characters [OBJECT] \n"
    + "2. Change the Tag and Layer\n"
	+ "     - Tag: Player\n"
	+ "     - Layer: Controlled Character (NOTE: Select 'no, this object only')\n"
    + "3. Change the Animator component\n"
	+ "      - Controller: StarterAssetsThirdPerson.controller\n"
    + "      - Apply Root Motion: Uncheck (NOTE: Character cannot walk if this is check)\n"
	+ "      - Update Mode: Normal\n"
	+ "      - Culling Mode: Cull Update Transforms\n"
    + "4. Create empty GameObject inside the new character\n"
	+ "5. Rename the empty GameObject to PlayerCameraRoot\n"
    + "6. Change the PlayerCameraRoot Tag\n"
	+ "     - Tag: CinemachineTarget\n"
    + "6. Open the Scene in 3D view\n"
	+ "7. Move the PlayerCameraRoot object to the chest of new character\n"
    + "8. Copy the Components from other character to the new character\n"
	+ "     - Character Controller\n"
	+ "     - Starter Assets Inputs\n"
	+ "     - Basic Rigid Body\n"
	+ "     - Third Person Controller (NOTE: Enable this component in Prefab)\n"
	+ "     - Player Input\n"
	+ "9. Drag the PlayerCameraRoot object to Third Person Controller 'Cinemachine Camera Target'\n"
    + "10. Modify the 'Character Controller' component based on the size of new character\n"
	+ "     - Center Y\n"
	+ "     - Radius\n"
	+ "     - Height\n"
    + "11. Change the Player Input component\n"
	+ "     - Actions: StarterAssets.inputactions\n"
    + "12. Create new Prefab in Prefabs folder\n"
	+ "13. Drag the new character to the new Prefab and save\n\n"
	+ "Instructions for adding the new character in Character Selection scene\n\n"
	+ "1. Click Hierarchy [TAB] > Characters [OBJECT]\n"
	+ "2. Add new Element [+] in 'Character' list (NOTE: Below this Instructions)\n"
	+ "3. Drag the new character from Hierachy [TAB] to new Element of Character list\n"
	+ "4. Change the Animator component of new character prefab\n"
	+ "     - Controller: Look Around-Nervous-A.controller (NOTE: This can be change to any controller)\n"
	+ "5. Disable the 'Third Person Controller' component\n\n"
	+ "IMPORTANT NOTES:\n\n"
	+ "1. Change Rig > Animation Type to Humanoid before adding the character\n"
	+ "2. Default Animator > Controller of all character Prefab must be StarterAssetsThirdPerson\n"
    + "3. Character prefab must be added in Load Character Prefabs List in Stage 1-5 scene\n"
	+ "4. If character is floating, modify the 'Grounded Offset' and 'Grounded Radius' in ThirdPersonController Script component of character\n"
	+ "5. Disable the ThirdPersonController Script component in Character Selection scene", UnityEditor.MessageType.None)]
#endif

	[SerializeField] private TextMeshProUGUI skinInfo;
	[SerializeField] private TextMeshProUGUI coinText;
	[SerializeField] private GameObject[] skin;
	[SerializeField] private int[] skinPrice;

	[SerializeField] private GameObject[] particleStar;
	[SerializeField] private GameObject[] faceMask;
	[SerializeField] private GameObject[] faceShield;

	int currentSkin = 0;
	int skinName;
	int coinCount;


	void Awake()
    {
		foreach (GameObject particleObj in particleStar)
		{
			particleObj.SetActive(false);
		}
		foreach (GameObject maskObj in faceMask)
		{
			maskObj.SetActive(false);
		}
		foreach (GameObject shieldObj in faceShield)
		{
			shieldObj.SetActive(false);
		}

		int coinCount = PlayerPrefs.GetInt("Coin");
		coinText.text = "<color=yellow>Coins: " + coinCount;
		SkinNamePrice();
	}

    public void NextCharacter()
	{
		skin[currentSkin].SetActive(false);
		currentSkin = (currentSkin + 1) % skin.Length;
		skin[currentSkin].SetActive(true);
		SkinNamePrice();
	}

	public void PreviousCharacter()
	{
		skin[currentSkin].SetActive(false);
		currentSkin--;
		if (currentSkin < 0)
		{
			currentSkin += skin.Length;
		}
		skin[currentSkin].SetActive(true);
		SkinNamePrice();
	}

	void SkinNamePrice()
	{
		SaveManager.GetCoin();
		coinText.text = "Coins: " + SaveManager.currentCoin;
		currentSkin += 1; // Add 1 because premium skin playerprefs starts with 1 in SaveManager
		int skinCheck = PlayerPrefs.GetInt("Premium Skin " + currentSkin);
		skinName = currentSkin + 1; // Add 1 because premium skin character name starts with 2 in TextManager 
		currentSkin -= 1;
		if (skinCheck == 1)
        {
			skinInfo.text = TextManager.characterName[skinName];
		}
		else
        {
			skinInfo.text = "Buy " + TextManager.characterName[skinName] + "\nfor <color=yellow>" + skinPrice[currentSkin] + " Coins";
		}
		skinName = 0;
	}

	public void BuyCharacter()
	{
		SaveManager.GetCoin();
		if (SaveManager.currentCoin >= skinPrice[currentSkin])
        {
			int newCoin = SaveManager.currentCoin;
			newCoin -= skinPrice[currentSkin];
			coinText.text = "Coins: " + newCoin;
			SaveManager.SetCoinFromShop(newCoin);
			currentSkin += 1;
			SaveManager.SetPremiumSkin(currentSkin, 1);
			skinName = currentSkin + 1; // Add 1 because premium skin character name starts with 2 in TextManager 
			currentSkin -= 1;
			skinInfo.text = TextManager.characterName[skinName];
		}
		else
        {
			int neededCoin = skinPrice[currentSkin] - coinCount;
			coinText.text = "<color=yellow>Coins: " + coinCount + "</color>  <  You need <color=yellow>" + neededCoin + "</color> more coins to buy " + TextManager.characterName[currentSkin] + " skin.";
			StartCoroutine(ClearCoinNeed());
        }
	}

	IEnumerator ClearCoinNeed()
    {
		yield return new WaitForSeconds(3);
		coinText.text = "Coins: " + coinCount;
    }

	public void GoToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
