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

    // Changes the current state of the game
    public void SetState(GameStates newState)
    {
        _previousState = _currentState;
        _currentState = newState;

        _previousActiveState = _previousState.ToString();
        _currentActiveState = _currentState.ToString();

        OnGameStateChange(newState: _currentState);

    }

    // Actually does all the techincal parts of changing the GameState
    private void OnGameStateChange(GameStates newState)
    {
        // A switch is used to determined from the new state to determine what to do. 
        switch (newState)
        {
            // Default does nothing
            default:
                break;

                // Intializes only sets the state back to the main Menu
            case GameStates.init:
                SetState(newState: GameStates.MainMenu);
                break;
                // Main menu opens the main menu ui
            case GameStates.MainMenu:
                Time.timeScale = 0;
                _manager.uiManager.ShowMainMenuUI();
                break;
                // Gameplay starts time and shows the gameplay UI
            case GameStates.Gameplay:
                Time.timeScale = 1;
                _manager.uiManager.ShowGamePlayUI();
                break;
                // Paused stops time and shows the paused UI
            case GameStates.Paused:
                Time.timeScale = 0;
                _manager.uiManager.ShowPausedUI();
                break;
                // Death also stops time and shows the death UI
            case GameStates.Death:
                _manager.uiManager.ShowDeathUI();
                Time.timeScale = 0;
                break;
        }
    }



}
