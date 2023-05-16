using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class DoorAnimationEventPivotFix : MonoBehaviour
{
    [SerializeField] private GameObject animCollider;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject childObject;

    bool stopAnimating = false;
    float yRotation;
    float eulerAngleX;

    void EnableDoorHand()
    {
        SaveManager.SetDoorAccess(1);
        animCollider.SetActive(false);
        Debug.Log("<color=yellow>DoorAnimationEvent</color> - Animation Ended");
        stopAnimating = true;
    }

    void DisableDoorHand()
    {
        SaveManager.SetDoorAccess(0);
        Debug.Log("<color=yellow>DoorAnimationEvent</color> - Animation Started");
        eulerAngleX = childObject.transform.eulerAngles.x;
        StartCoroutine(ChangePosition());
    }

    IEnumerator ChangePosition()
    {
        while (true)
        {
            if (stopAnimating)
                yield break;
            yRotation = parentObject.transform.eulerAngles.y;
            Debug.Log(childObject.transform.eulerAngles + " - " + yRotation);
            childObject.transform.eulerAngles = new Vector3(eulerAngleX, yRotation, transform.eulerAngles.z);
            yield return new WaitForSeconds(0f);
        }
    }
}
