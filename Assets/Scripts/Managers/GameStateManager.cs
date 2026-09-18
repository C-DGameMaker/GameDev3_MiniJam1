using UnityEngine;

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
    [SerializeField] private string _currentActiveState;
    [SerializeField] private string _previousActiveState;
    public GameStates _currentState { get; set; }
    public GameStates _previousState { get; set; }

    public UIManager _manager;

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
                _manager.ShowMainMenuUI();
                break;
            case GameStates.Gameplay:
                Time.timeScale = 1;
                _manager.ShowGamePlayUI();
                break;
            case GameStates.Paused:
                Time.timeScale = 0;
                _manager.ShowPausedUI();
                break;
            case GameStates.Death:
                Time.timeScale = 0;
                break;
        }
    }



}
