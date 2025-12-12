using UnityEngine;

public class InteractRay : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public Camera camera;

    [Header("UI Prompt")]
    public GameObject interactUI;

    private IInteractable currentTarget;

    void Update()
    {
        CheckForInteractable();

        if (currentTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("[INTERACT] E pressed → calling Interact() on " + currentTarget);
            currentTarget.Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            currentTarget = hit.collider.GetComponent<IInteractable>();

            if (currentTarget != null)
            Debug.Log("[INTERACT] Target IS interactable");
            else
            Debug.Log("[INTERACT] Target NOT interactable");

            if (interactUI) interactUI.SetActive(true);
        }
        else
        {
            Debug.Log("[INTERACT] Ray hit NOTHING");
            currentTarget = null;
            if (interactUI) interactUI.SetActive(false);
        }
    }
}
