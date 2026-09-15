using UnityEngine;

public class ServiceHubManager : MonoBehaviour
{
   public static ServiceHubManager Instance { get; private set; }

    [Header("System References")]
    public GameStateManager gameStateManager;
    public UIManager uiManager;

    private void Awake()
    {
        #region Singleton Pattern

        // Simple singleton setup for a single-scene game
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        #endregion
    }

}

