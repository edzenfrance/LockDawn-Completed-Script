using UnityEngine;
using UnityEngine.SceneManagement;


public class StageExitController : MonoBehaviour
{
    [SerializeField] private SurveyManager surveyManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SaveManager.replayStage == 1)
            {
                SaveManager.DeleteReplayStage();
                SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
            }
            else
            {
                SaveManager.GetCurrentStage();
                surveyManager.ProcessSurvey("Stage " + SaveManager.currentStage + " Survey");
                gameObject.SetActive(false);
            }
        }
    }
}
