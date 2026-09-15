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
    public GameStates _currentState { get; private set; }
    public GameStates _previousState { get; private set; }

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
                _manager.ShowMainMenuUI();
                break;
            case GameStates.Gameplay:
                _manager.ShowGamePlayUI();
                break;
            case GameStates.Paused:
                break;
            case GameStates.Death:
                break;
        }
    }

    public void StartGameButton()
    {
        SetState(newState: GameStates.Gameplay);
    }


}
