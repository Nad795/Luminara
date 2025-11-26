using UnityEngine;

public class Shrine : MonoBehaviour, IInteractable
{
    public Transform spiritDropPoint;
    public float interactDistance = 3f;
    public ObjectiveManager objectiveManager;

    public void Interact()
    {
        Spirit[] spirits = FindObjectsByType<Spirit>(FindObjectsSortMode.None);

        foreach (var sp in spirits)
        {
            if (sp.currentState == Spirit.SpiritState.Following)
            {
                sp.transform.position = spiritDropPoint.position;
                sp.currentState = Spirit.SpiritState.Purified;

                if (sp.visualObject != null)
                {
                    sp.visualObject.SetActive(false);
                }

                Debug.Log("Shrine purified!");

                if (objectiveManager != null)
                {
                    objectiveManager.SpiritPurified();
                }

                return;
            }
        }

        Debug.Log("No spirit is following to purify.");
    }
}

