using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// Charlie Dobson 
/// 
/// Sets the current Game state within the game
/// </summary>


// An enum of all the GameStates
public enum GameStates
{
    init, //Intialize
    MainMenu, //Main Menu
    Gameplay, //Gameplay
    Paused, // Paused
    Death //Death

}

public class GameStateManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    // To show what the gameStates are, in both string form and GameState form
    // to change them. 
    [SerializeField] private string _currentActiveState;
    [SerializeField] private string _previousActiveState;
    public GameStates _currentState { get; set; }
    public GameStates _previousState { get; set; }

    // The service hub manager
    public ServiceHubManager _manager;

    private void Start()
    {
        // Sets the state to intialize
        SetState(newState: GameStates.init);
    }

    // Changes the current state of the 
    public void SetState(GameStates newState)
    {
        _previousState = _currentState;
        _currentState = newState;

        _previousActiveState = _previousState.ToString();
        _currentActiveState = _currentState.ToString();

        OnGameStateChange(newState: _currentState);

    }

    private void OnGameStateChange(GameStates newState)
    {
        switch (newState)
        {
            default:
                break;

            case GameStates.init:
                SetState(newState: GameStates.MainMenu);
                break;
            case GameStates.MainMenu:
                Time.timeScale = 0;
                _manager.uiManager.ShowMainMenuUI();
                break;
            case GameStates.Gameplay:
                Time.timeScale = 1;
                _manager.uiManager.ShowGamePlayUI();
                break;
            case GameStates.Paused:
                Time.timeScale = 0;
                _manager.uiManager.ShowPausedUI();
                break;
            case GameStates.Death:
                _manager.uiManager.ShowDeathUI();
                Time.timeScale = 0;
                break;
        }
    }



}
