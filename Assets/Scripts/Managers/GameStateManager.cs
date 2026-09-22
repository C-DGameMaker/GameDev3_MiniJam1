using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum GameStates
{
    init,
    MainMenu,
    Gameplay,
    Paused,
    Death

}


public class GameStateManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem; 
    [SerializeField] private string _currentActiveState;
    [SerializeField] private string _previousActiveState;
    public GameStates _currentState { get; set; }
    public GameStates _previousState { get; set; }

    public ServiceHubManager _manager;

    private void Start()
    {
        SetState(newState: GameStates.init);
    }

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
