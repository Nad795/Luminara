using System.Collections;
using UnityEngine;

public class Spirit : MonoBehaviour, IInteractable
{
    public enum SpiritState {Revealed, Following, Purified }
    public SpiritState currentState = SpiritState.Revealed;

    public Transform player;
    public float followSpeed = 3f;

    public GameObject visualObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (currentState)
        {
            case SpiritState.Revealed:
                break;

            case SpiritState.Following:
                FollowPlayer();
                break;
        }
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
}
