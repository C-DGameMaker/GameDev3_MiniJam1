using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI gameScoreText;
    public TextMeshProUGUI endScoreText;
    public ServiceHubManager hubManager;

    private void Start()
    {
        score = 0;
        hubManager = ServiceHubManager.Instance;
    }
    private void FixedUpdate()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        if (hubManager.gameStateManager._currentState == GameStates.Gameplay) score++;
        gameScoreText.text = "Score: " + score;
        endScoreText.text = "Final Score: " + score;
    }
}
