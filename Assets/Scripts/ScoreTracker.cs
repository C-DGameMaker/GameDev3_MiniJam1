using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;
    ServiceHubManager hubManager;

    private void Start()
    {
        score = 0;
        hubManager = ServiceHubManager.Instance;
    }
    private void Update()
    {
        while(hubManager.gameStateManager._currentState == GameStates.Gameplay)
        {
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }
}
