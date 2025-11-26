using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public ObjectiveManager objectiveManager;
    public TextMeshProUGUI progressText;

    void Update()
    {
        progressText.text = objectiveManager.purifiedCount + " / " + objectiveManager.totalSpirits + " Spirits";
    }
}