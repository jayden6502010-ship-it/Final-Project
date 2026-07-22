using UnityEngine;
using UnityEngine.UI; 

public class SimpleScore : MonoBehaviour 
{
    public Text scoreText; 
    private int score = 0; 

    private void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Basketball")) 
        { 
            // Fix: Added Global. prefix to find the bootstrap wrapped in the namespace
            Global.VRScoreboardBootstrap scoreboard = FindObjectOfType<Global.VRScoreboardBootstrap>();

            if (scoreboard != null)
            {
                scoreboard.AddPoint(2);
            }
            else
            {
                Debug.LogWarning("SimpleScore: VRScoreboardBootstrap could not be found in the scene!");
            }
        } 
    } 
}
