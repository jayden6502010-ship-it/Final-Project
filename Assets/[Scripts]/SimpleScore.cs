using UnityEngine;
using UnityEngine.UI; // Changed from TMPro to UnityEngine.UI

public class SimpleScore : MonoBehaviour
{
    public Text scoreText; // Changed from TextMeshProUGUI to Text
    private int score = 0;

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Basketball"))
    {
        // Automatically finds the bootstrap on the player and adds points
        FindObjectOfType<VRScoreboardBootstrap>().AddPoint(2);
    }
}

}
