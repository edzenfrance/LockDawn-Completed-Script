using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NPCAlmanac : MonoBehaviour
{

	[SerializeField] private int currentNonPlayerCharacter;
	[SerializeField] private GameObject useNonPlayerCharacter;
	[SerializeField] private TextMeshProUGUI zombieNameText;
	[SerializeField] private GameObject[] nonPlayerCharacter;

	private void Start()
	{
		zombieNameText.text = TextManager.npcName[currentNonPlayerCharacter];
	}

	public void NextCharacter()
	{
		nonPlayerCharacter[currentNonPlayerCharacter].SetActive(false);
		currentNonPlayerCharacter = (currentNonPlayerCharacter + 1) % nonPlayerCharacter.Length;
		UseCharacter();
		nonPlayerCharacter[currentNonPlayerCharacter].SetActive(true);
	}

	public void PreviousCharacter()
	{
		nonPlayerCharacter[currentNonPlayerCharacter].SetActive(false);
		currentNonPlayerCharacter--;
		if (currentNonPlayerCharacter < 0)
			currentNonPlayerCharacter += nonPlayerCharacter.Length;
		UseCharacter();
		nonPlayerCharacter[currentNonPlayerCharacter].SetActive(true);
	}

	void UseCharacter()
	{
		useNonPlayerCharacter.SetActive(true);
		zombieNameText.text = TextManager.npcName[currentNonPlayerCharacter];
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
