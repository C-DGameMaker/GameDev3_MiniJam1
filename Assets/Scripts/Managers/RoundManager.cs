using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private bool ActiveRound = false;
    void Start()
    {
        EventBus.RequestEvent("RequestRoundStart", true).ping += BeginNewRun;
        EventBus.RequestEvent("PlayerDied", true).ping += EndRun;
    }

    void BeginNewRun()
    {
        if(ActiveRound) return;

        ActiveRound = true;
        EventBus.RequestEvent("StartGameplay", true).ping += BeginNewRun;
    }

    void EndRun()
    {
        if (ServiceHubManager.Instance.gameStateManager._currentState != GameStates.Gameplay) return;
        ServiceHubManager.Instance.gameStateManager.SetState(newState: GameStates.Death);

        
    }

    void PingMapReset()
    {
        
    }

    void SaveScore()
    {
        
    }

    void LoadScore()
    {
        
    }
}
