using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class CameraDistance : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Cinemachine3rdPersonFollow thirdPersonFollow;

    [Header("Slider Settings")]
    [SerializeField] private TMP_Text cameraDistanceText;
    [SerializeField] private Slider cameraDistanceSlider;
    [SerializeField] private float cameraDistanceValue;

    private void Start()
    {
        //virtualCamera = GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>();
        thirdPersonFollow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

        SaveManager.GetCameraDistance();
        cameraDistanceSlider.value = SaveManager.cameraDistance;
        cameraDistanceText.text = SaveManager.cameraDistance.ToString("f2");
        thirdPersonFollow.CameraDistance = SaveManager.cameraDistance;

        /*
        cameraDistanceValue = PlayerPrefs.GetFloat("Camera Distance", 1.75f);
        cameraDistanceSlider.value = cameraDistanceValue;
        cameraDistanceText.text = cameraDistanceValue.ToString("f2");
        thirdPersonFollow.CameraDistance = cameraDistanceValue;
        */
    }

    public void SetCameraDistance(float distance)
    {
        //distance = Mathf.Round(distance * 10f) * 0.1f;
        thirdPersonFollow.CameraDistance = distance;
        SaveManager.SetCameraDistance(distance);
        cameraDistanceText.text = distance.ToString("f2");
    }
}