using UnityEngine;
using System.Collections;

public class PulseReveal : MonoBehaviour
{
    public float pulseRadius = 8f;
    public KeyCode pulseKey = KeyCode.Q;
    public float revealDuration = 1f;

    private bool isPulsing = false;

    void Update()
    {
        if (Input.GetKeyDown(pulseKey) && !isPulsing)
        {
            StartCoroutine(DoPulse());
        }
    }

    IEnumerator DoPulse()
    {
        isPulsing = true;
        Debug.Log("Pulse activated!");

        Collider[] hits = Physics.OverlapSphere(transform.position, pulseRadius);

        foreach (var h in hits)
        {
            Spirit spirit = h.GetComponent<Spirit>();
            if (spirit != null)
            {
                spirit.FlashReveal(revealDuration);
            }
        }
        yield return new WaitForSeconds(0.3f);
        isPulsing = false;
    }
}
