using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public int totalSpirits = 5;
    public int purifiedCount = 0;

    public GameObject portal;

    void Start()
    {
        if (portal != null)
        {
            portal.SetActive(false);
        }
    }

    public void SpiritPurified()
    {
        purifiedCount++;
        Debug.Log("Total purified spirits: " + purifiedCount + " / " + totalSpirits);

        if (purifiedCount >= totalSpirits)
        {
            {
                ActivatePortal();
            }
        }
    }

    void ActivatePortal()
    {
        Debug.Log("All spirits purified! The portal is now active.");
        
        if (portal != null)
        {
            portal.SetActive(true);
        }
    }
}