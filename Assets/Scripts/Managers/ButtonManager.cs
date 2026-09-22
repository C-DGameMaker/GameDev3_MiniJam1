using UnityEditor.Search;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public ServiceHubManager serviceHub;

    private void Start()
    {
        if(serviceHub == null)
        {
            serviceHub = GetComponent<ServiceHubManager>();
        }
        
    }


    public void StartGameButton()
    {
        serviceHub.gameStateManager.SetState(newState: GameStates.Gameplay);
    }

    public void InstructionButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PauseToggle()
    {
        if (serviceHub.gameStateManager._currentState == GameStates.Gameplay)
        {
            if (serviceHub.gameStateManager._currentState == GameStates.Paused) return;
            serviceHub.gameStateManager.SetState(newState: GameStates.Paused);

        }
        else if(serviceHub.gameStateManager._currentState == GameStates.Paused)
        {
            if (serviceHub.gameStateManager._currentState == GameStates.Gameplay) return;
            serviceHub.gameStateManager.SetState(newState: GameStates.Gameplay);
        }
    }

    public void BackToGameButton()
    {
        serviceHub.gameStateManager.SetState
            (newState: serviceHub.gameStateManager._previousState);

        if(serviceHub.gameStateManager._currentState 
            == GameStates.Paused)
        {
            serviceHub.gameStateManager._previousState = GameStates.Gameplay;
        }
    }

    public void BackToMenuButton()
    {
        serviceHub.gameStateManager.SetState
            (newState: GameStates.MainMenu);
    }

    public void DeathButton()
    {
        if (serviceHub.gameStateManager._currentState != GameStates.Gameplay) return;

        serviceHub.gameStateManager.SetState(newState: GameStates.Death);
    }
}
