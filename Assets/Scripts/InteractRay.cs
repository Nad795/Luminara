using UnityEngine;

public class InteractRay : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    [Header("UI Prompt")]
    public GameObject interactUI;

    private IInteractable currentTarget;

    void Update()
    {
        CheckForInteractable();

        if (currentTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            currentTarget.Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            currentTarget = hit.collider.GetComponent<IInteractable>();

            if (interactUI) interactUI.SetActive(true);
        }
        else
        {
            currentTarget = null;
            if (interactUI) interactUI.SetActive(false);
        }
    }
}
