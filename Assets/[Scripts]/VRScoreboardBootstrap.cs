using UnityEngine;
using TMPro;

// The class name must match the renamed VRScoreboardBootstrap.cs file exactly
public class VRScoreboardBootstrap : MonoBehaviour
{
    [Header("Settings")]
    public string basketballTag = "Basketball";
    public Vector3 hudOffset = new Vector3(0f, -0.4f, 1.5f); 

    private int score = 0;
    private TextMeshProUGUI scoreTextComponent;

    void Start()
    {
        CreateHUDScoreboard();
    }

    void CreateHUDScoreboard()
    {
        Camera mainCam = Camera.main;
        if (mainCam == null)
        {
            Debug.LogError("No Main Camera found in the scene! Make sure your camera is tagged 'MainCamera'.");
            return;
        }

        GameObject canvasGO = new GameObject("Runtime_HUD_Canvas");
        canvasGO.transform.SetParent(mainCam.transform); 
        
        canvasGO.transform.localPosition = hudOffset;
        canvasGO.transform.localRotation = Quaternion.identity;

        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        RectTransform canvasRect = canvasGO.GetComponent<RectTransform>();
        canvasRect.sizeDelta = new Vector2(1.5f, 0.5f); 
        canvasGO.transform.localScale = new Vector3(1f, 1f, 1f);

        GameObject textGO = new GameObject("HUDScoreText");
        textGO.transform.SetParent(canvasGO.transform, false);

        scoreTextComponent = textGO.AddComponent<TextMeshProUGUI>();
        scoreTextComponent.text = "Score: 0";
        scoreTextComponent.fontSize = 0.35f; 
        scoreTextComponent.alignment = TextAlignmentOptions.Center;
        
        RectTransform textRect = textGO.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = Vector2.zero;
    }

    public void AddPoint(int points)
    {
        score += points;
        if (scoreTextComponent != null)
        {
            scoreTextComponent.text = "Score: " + score;
        }
    }
}
