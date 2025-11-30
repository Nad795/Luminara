using System.Collections;
using UnityEngine;

public class Spirit : MonoBehaviour, IInteractable
{
    public enum SpiritState { Hidden, Revealed, Following, Purified }
    public SpiritState currentState = SpiritState.Hidden;

    public Transform player;
    public float revealDistance = 4f;
    public float followSpeed = 3f;

    public GameObject visualObject;

    void Start()
    {
        if (visualObject != null)
        {
            visualObject.SetActive(false);
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case SpiritState.Hidden:
                CheckReveal();
                break;

            case SpiritState.Revealed:
                break;

            case SpiritState.Following:
                FollowPlayer();
                break;
        }
    }

    void CheckReveal()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        Debug.Log($"[SPIRIT] Distance: {dist}");
        if (dist < revealDistance)
        {
            Debug.Log("[SPIRIT] REVEALED!");
            currentState = SpiritState.Revealed;

            if (visualObject != null)
            {
                visualObject.SetActive(true);
            }
        }
        Debug.Log($"[SPIRIT] Current State: {currentState}");
    }

    public void Interact()
    {
        Debug.Log("[SPIRIT] Interact() called");
        if (currentState == SpiritState.Revealed)
        {
            currentState = SpiritState.Following;
            Debug.Log("Spirit is now following the player");
        }
        else 
        {
            Debug.Log("[SPIRIT] Interact failed. CurrentState = " + currentState);
        }
    }

    void FollowPlayer()
    {
        Vector3 targetPos = player.position + (player.forward * -1.5f);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    public void FlashReveal(float duration)
    {
        if (visualObject != null)
        {
            StartCoroutine(FlashRoutine(duration));
        }
    }

    IEnumerator FlashRoutine(float duration)
    {
        visualObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        if (currentState != SpiritState.Following)
        {
            visualObject.SetActive(false);
        }
    }
}
